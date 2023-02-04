using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum States
{
    None,
    Play,
    Pause,
    Finished,
    Menu
}
public enum Levels
{
    Zero,
    One,
    Two,
    Three,
    Four,
    Five,
    More
}
public class GameManager : MonoBehaviour
{
    public States stateGame = States.None;
    public TypeItem actualTypeItemAffecting;
    public Levels actualLevel;
    public int actualLevelNum=0;
    [SerializeField]
    public float timeToPassLevel;
    [SerializeField]
    public float lifeValueMax;
    [SerializeField]
    public float lifeValue;
    public float time;
    public Transform targetDiorama;
    public Transform targetPlayer;
    public CameraFollow CameraFollow;
    public UIController uIController;
    public ManagerScenes sceneManager;
    public bool checkChange2Dto3D=false;
    [SerializeField]
    float timeTillRestart;
    [SerializeField]
    float timeOfShowingDiorama;
    // Start is called before the first frame update
    private void Awake()
    {
        lifeValue = lifeValueMax;
        SwitchLevel(actualLevelNum);
    }
    void Start()
    {
        stateGame = States.Play;
        CameraFollow.ChangeTarget(targetPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (stateGame==States.Play)
        {
            CheckGameLoop();
        }


    }
    public void CheckGameLoop()
    {
        ManageLifeValue();
        time += Time.deltaTime;
        if (checkChange2Dto3D == false)
        {
            if (time > timeToPassLevel)
            {
                checkChange2Dto3D = true;

                Transition2Dto3D();

                StartCoroutine(WatchDiorama());
                SwitchLevel(actualLevelNum);

            }
        }
        else if (lifeValue<=0)
        {
            GameOver();
        }
    }
    public void ManageLifeValue()
    {
        lifeValue -= Time.deltaTime;
        uIController.UpdateLifeValueBar(lifeValue);

    }
    public void Transition2Dto3D()
    {
        stateGame = States.Pause;
        CameraFollow.cam.orthographic = false;
    }
    public void Transition3Dto2D()
    {

        CameraFollow.cam.orthographic = true;
    }
    public IEnumerator WatchDiorama()
    {
        CameraFollow.ChangeTarget(targetDiorama);
        uIController.ShowOrDisableDioramaUI(true);
        yield return new WaitForSeconds(timeOfShowingDiorama);
        Debug.Log("");
        CameraFollow.ChangeTarget(targetPlayer);
        uIController.ShowOrDisableDioramaUI(false);
        StartCoroutine(CountDown());

    }
    public IEnumerator CountDown()
    {
        Transition3Dto2D();
        Debug.Log("Countdown...");
        uIController.ShowOrDisableRestartUI(true,timeTillRestart);
        yield return new WaitForSeconds(timeTillRestart);
        stateGame = States.Play;
        uIController.ShowOrDisableRestartUI(false, timeTillRestart);



    }
    public void GameOver()
    {
        stateGame = States.Finished;
        uIController.ShowGameOverUI();
        
    }
    public void SwitchLevel(int num)
    {
        actualLevelNum++;
        if (num>5)
        {
            actualLevel = Levels.More;
        }
        switch (num)
        {
            case 0:
                actualLevel = Levels.One;
                break;
            case 2:
                actualLevel = Levels.Two;
                break;
            case 3:
                actualLevel = Levels.Three;
                break;
            case 4:
                actualLevel = Levels.Four;
                break;
            case 5:
                actualLevel = Levels.Five;
                break;
            default:
                actualLevel = Levels.Zero;
                break;
        }
    }
}
