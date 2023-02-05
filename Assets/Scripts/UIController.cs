using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject canvasGameOver;
    [SerializeField]
    GameObject canvasRestart;
    [SerializeField]
    TextMeshProUGUI amountTimeRestart;
    [SerializeField]
    TextMeshProUGUI amountDistance;
    [SerializeField]
    GameObject canvasDiorama;
    public LifeValueBar lifeValueBar;
    float time=0;
    public float timeValueRestart;
    bool restartControl = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (restartControl)
        {
            time += Time.deltaTime;
            
            if (time < timeValueRestart)
                UpdateTimeCountdownRestart(timeValueRestart-time);
            else
                restartControl = false;
            
        }

    }
    public void UpdateLifeValueBar(float lifeRemaining)
    {
        lifeValueBar.lifeValueBar= lifeRemaining;
    }
    public void ShowOrDisableDioramaUI(bool control)
    {
        canvasDiorama.SetActive(control);

    }
    public void SetValueRestartUI()
    {
        time=0;

    }
    public void ShowOrDisableRestartUI(bool control,float time)
    {
        canvasRestart.SetActive(control);
        if (control)
        {
            timeValueRestart = time;
            restartControl = true;  

        }

    }
    public void UpdateTimeCountdownRestart(float time)
    {
        int timeInt = Convert.ToInt32(time);
        amountTimeRestart.text = timeInt.ToString();

    }
    public void ShowGameOverUI()
    {
        canvasGameOver.SetActive(true);
    }
    public void ChangeValueDistance(float distance)
    {
        amountDistance.text=Convert.ToInt32(distance).ToString();
    }
}
