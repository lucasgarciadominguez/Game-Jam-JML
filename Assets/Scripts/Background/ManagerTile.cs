using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ManagerTile : MonoBehaviour
{
    public float2 maxminValuesX;
    public float2 maxminValuesY;
    public float2 valuesPipeline;
    float zdistance = -0.11f;
    public GameObject sand;
    public GameObject water;
    public GameObject pipelinesLeft;
    public GameObject pipelinesRight;
    public GameObject radioactive;
    public List<GameObject> rocks;
    public float speedRadioactiveEffect;
    int numSand=0;
    bool hasWater = false;
    int numPipelines=0;
    int numRadioactive=0;
    int numRocks=0;

    float probSand = 0;
    float probWater = 0;
    float probPipelines = 0;
    float probRadioactive = 0;
    float probRocks = 0;
    public void Start()
    {

    }
    public void SetTileItems()
    {
        for (int i = 0; i < numSand; i++)
        {
            float numFloat = UnityEngine.Random.Range(0f, 1.1f);
            if(numFloat < probSand)
            {
                GameObject go = Instantiate(sand, transform.position, Quaternion.identity, transform);
                go.transform.localPosition = new Vector3(0, UnityEngine.Random.Range(maxminValuesY.x, maxminValuesY.y), zdistance);
            }

        }
        if (hasWater)
        {
            float numFloat = UnityEngine.Random.Range(0f, 1.1f);
            if (numFloat < probWater)
            {
                GameObject go = Instantiate(water, transform.position, Quaternion.identity, transform);
                go.transform.localPosition = new Vector3(0, UnityEngine.Random.Range(maxminValuesY.x, maxminValuesY.y), zdistance);
            }
        }
        for (int i = 0; i < numPipelines; i++)
        {
            float numFloat = UnityEngine.Random.Range(0f, 1.1f);
            if (numFloat < probPipelines)
            {
                int num=UnityEngine.Random.Range(0,2);
                if (num==1)
                {
                    GameObject go = Instantiate(pipelinesLeft, transform.position, Quaternion.identity, transform);
                    go.transform.Rotate(new Vector3(0, 90, 0));
                    go.transform.localPosition = new Vector3(-9.83f, UnityEngine.Random.Range(maxminValuesY.x, maxminValuesY.y), -2.39f);
                }
                else
                {
                    GameObject go = Instantiate(pipelinesRight, transform.position, Quaternion.identity, transform);
                    go.transform.Rotate(new Vector3(0, -90, 0));
                    go.transform.localPosition = new Vector3(9.83f, UnityEngine.Random.Range(maxminValuesY.x, maxminValuesY.y),2.3f);
                }
            }
        }
        Debug.Log(numRadioactive);

        for (int i = 0; i < numRadioactive; i++)
        {
            float numFloat = UnityEngine.Random.Range(0f, 1.1f);
            if (numFloat < probRadioactive)
            {
                GameObject go = Instantiate(radioactive, transform.position, Quaternion.identity, transform);
                go.transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(0, 90f)));
                go.transform.localPosition = new Vector3(UnityEngine.Random.Range(maxminValuesX.x, maxminValuesX.y), UnityEngine.Random.Range(maxminValuesY.x, maxminValuesY.y), -3.14f);
            }
        }
        for (int i = 0; i < numRocks; i++)
        {
            Debug.Log(probRocks);
            float numFloat = UnityEngine.Random.Range(0f, 1.1f);
            if (numFloat < probRocks)
            {
                int numPrefab = UnityEngine.Random.Range(0, rocks.Count);

                GameObject go = Instantiate(rocks[numPrefab] ,transform.position, Quaternion.identity, transform);
                go.transform.localPosition = new Vector3(UnityEngine.Random.Range(maxminValuesX.x, maxminValuesX.y), UnityEngine.Random.Range(maxminValuesY.x, maxminValuesY.y), zdistance);
            }
        }
    }
    public void SetLevel(int numSand,bool hasWater, int numPipelines, int numRadioactive, int numRocks)
    {
        this.numSand = numSand;
        this.hasWater = hasWater;
        this.numPipelines = numPipelines;
        this.numRadioactive = numRadioactive;
        this.numRocks = numRocks;

    }
    public void SetProbabilities(float probSand, float probWater, float probPipelines, float probRadioactive, float probRocks)
    {
        this.probSand = probSand;
        this.probWater = probWater;
        this.probPipelines = probPipelines;
        this.probRadioactive = probRadioactive;
        this.probRocks = probRocks;

    }

}
