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
    float increaseLifeItemEffect;
    [SerializeField]
    float increaseSpeedItemEffect;
    [SerializeField]
    float decreaseSpeedItemEffect;

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
    public CharacterController characterController;
    public bool checkChange2Dto3D=false;
    [SerializeField]
    float timeTillRestart;
    [SerializeField]
    float timeOfShowingDiorama;
    [SerializeField]
    public float speedMultiplier;
    public Animator animatorTree;
    [SerializeField]
    float distance;
    // Start is called before the first frame update
    private void Awake()
    {
        lifeValue = lifeValueMax;
        SwitchLevel();
    }
    void Start()
    {
        stateGame = States.Play;
        CameraFollow.ChangeTarget(targetPlayer);
        SetValuesLevel();
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
        CreateDistanceTraveled();
        time += Time.deltaTime;
        distance += Time.deltaTime;

        if (time > timeToPassLevel)
        {
            SetValuesLevel();
            checkChange2Dto3D = false;
            if (checkChange2Dto3D == false)
            {

                checkChange2Dto3D = true;

                Transition2Dto3D();

                StartCoroutine(WatchDiorama());
                SwitchLevel();
                time = 0;
                

            }
        }

        else if (lifeValue<=0)
        {
            GameOver();
        }
    }
    public void EffectModifier()
    {
        switch (actualTypeItemAffecting)
        {
            case TypeItem.None:
                break;
            case TypeItem.IncreaseLife:
                lifeValue += increaseLifeItemEffect;
                break;
            case TypeItem.DefKill:
                GameOver();
                break;
            case TypeItem.IncreaseSpeed:
                characterController.speedVertical += increaseSpeedItemEffect;
                break;
            case TypeItem.DecreaseSpeed:
                characterController.speedVertical -= decreaseSpeedItemEffect;
                break;
            case TypeItem.KillStroot:
                break;
            case TypeItem.KillPlant:
                break;
            default:
                break;
        }
    }
    public void SetValuesLevel()
    {
        sceneManager.SetLevelsOfTheScene(actualLevel);
    }
    public void ManageLifeValue()
    {
        lifeValue -= Time.deltaTime;
        uIController.UpdateLifeValueBar(lifeValue);

    }
    public void CreateDistanceTraveled()
    {
        uIController.ChangeValueDistance(distance * 10);

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
        animatorTree.SetInteger("int_PlantForm", actualLevelNum);
        CameraFollow.ChangeTarget(targetDiorama);
        uIController.ShowOrDisableDioramaUI(true);
        yield return new WaitForSeconds(timeOfShowingDiorama);
        CameraFollow.ChangeTarget(targetPlayer);
        uIController.ShowOrDisableDioramaUI(false);
        StartCoroutine(CountDown());

    }
    public IEnumerator CountDown()
    {
        Transition3Dto2D();
        uIController.ShowOrDisableRestartUI(true,timeTillRestart);
        yield return new WaitForSeconds(timeTillRestart);
        stateGame = States.Play;
        uIController.ShowOrDisableRestartUI(false, timeTillRestart);
        uIController.SetValueRestartUI();



    }
    public void GameOver()
    {
        stateGame = States.Finished;
        uIController.ShowGameOverUI();
        
    }
    public void SwitchLevel()
    {
        speedMultiplier += speedMultiplier;
        actualLevelNum++;
        if (actualLevelNum > 5)
        {
            actualLevel = Levels.More;
        }
        switch (actualLevelNum)
        {
            case 1:
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
        characterController.ApplySpeedMultiplier(speedMultiplier);
    }
}
