using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject canvasRestart;
    [SerializeField]
    TextMeshProUGUI amountTimeRestart;
    [SerializeField]
    Canvas canvasDiorama;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowDioramaUI()
    {

    }
    public void ShowRestartUI(float timeRestart)
    {
        canvasRestart.SetActive(true);
        //float time = 0;
        //for (float i =time; i < timeRestart; time+=Time.deltaTime)
        //{
        //    i = Convert.ToInt32(i);
        //    amountTimeRestart.text = i.ToString();
        //}

    }
}
