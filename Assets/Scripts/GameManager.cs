using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum States
{
    None,
    Play,
    Pause,
    Menu
}
public class GameManager : MonoBehaviour
{
    public States stateGame = States.None;
    public float time;
    public Transform targetDiorama;
    public Transform targetPlayer;
    public CameraFollow CameraFollow;
    public UIController uIController;
    public bool check=false;
    [SerializeField]
    float timeTillRestart;
    [SerializeField]
    float timeOfShowingDiorama;
    // Start is called before the first frame update
    void Start()
    {
        stateGame = States.Play;
        CameraFollow.ChangeTarget(targetPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (check==false)
        {
            if (time > 10)
            {
                check = true;

                Transition2Dto3D();

                StartCoroutine(WatchDiorama());
            }
        }

    }
    public void Transition2Dto3D()
    {
        stateGame = States.Pause;
        //CameraFollow.cam.
    }
    public IEnumerator WatchDiorama()
    {
        CameraFollow.ChangeTarget(targetDiorama);
        yield return new WaitForSeconds(timeOfShowingDiorama);
        Debug.Log("");
        CameraFollow.ChangeTarget(targetPlayer);
        StartCoroutine(CountDown());

    }
    public IEnumerator CountDown()
    {
        Debug.Log("Countdown...");
        uIController.ShowRestartUI(timeTillRestart);
        yield return new WaitForSeconds(timeTillRestart);
        stateGame = States.Play;

    }
}
