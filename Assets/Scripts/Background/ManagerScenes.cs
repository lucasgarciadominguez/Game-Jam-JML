using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScenes : MonoBehaviour
{
    public int level;
    [SerializeField]
    GameObject scenePrefab;
    [SerializeField]
    GameObject gameObjectActual;
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject collisionChangeScene;
    [SerializeField]
    float distance;
    [SerializeField]
    float actualdistance;
    [SerializeField]
    float distanceCollision;
    [SerializeField]
    float actualdistanceCollision;
    int increaseValueMoreThan5=1;
    bool hasWaterThisTile=false;
    void Start()
    {
        gameObjectActual=Instantiate(scenePrefab,new Vector3(scenePrefab.transform.position.x, scenePrefab.transform.position.y - 10, scenePrefab.transform.position.z),Quaternion.identity);
        collisionChangeScene.transform.position=(new Vector3(collisionChangeScene.transform.position.x, collisionChangeScene.transform.position.y - distanceCollision, collisionChangeScene.transform.position.z));
    }
    public void ChangeBackgroundTile()
    {
        hasWaterThisTile = !hasWaterThisTile;
        actualdistance += distance;
        actualdistanceCollision += distanceCollision;
        gameObjectActual = Instantiate(scenePrefab, new Vector3(scenePrefab.transform.position.x, -actualdistance, scenePrefab.transform.position.z), Quaternion.identity);
        GetValuesOfTheScene(gameObjectActual, level);
        SetProbabilities(gameObjectActual, level);
        gameObjectActual.GetComponent<ManagerTile>().SetTileItems();
        collisionChangeScene.transform.position = new Vector3(collisionChangeScene.transform.position.x, -actualdistanceCollision, collisionChangeScene.transform.position.z);

    }
    public void SetLevelsOfTheScene(Levels level)
    {
        switch (level)
        {
            case Levels.Zero:
                this.level = 0;
                break;
            case Levels.One:
                this.level = 1;
                break;
            case Levels.Two:
                this.level = 2;
                break;
            case Levels.Three:
                this.level = 3;
                break;
            case Levels.Four:
                this.level = 4;
                break;
            case Levels.Five:
                this.level = 5;
                break;
            case Levels.More:
                this.level = 6;
                break;
            default:
                break;
        }
    }
    public void GetValuesOfTheScene(GameObject tile,int level)
    {

        switch (level)
        {
            case 0:
                tile.GetComponent<ManagerTile>().SetLevel(1, hasWaterThisTile, 1, 2, 5);
                break;
            case 1:
                tile.GetComponent<ManagerTile>().SetLevel(2, hasWaterThisTile, 5, 6, 4);
                break;
            case 2:
                tile.GetComponent<ManagerTile>().SetLevel(2, hasWaterThisTile, 5, 3, 4);
                break;
            case 3:
                tile.GetComponent<ManagerTile>().SetLevel(2, hasWaterThisTile, 5, 3, 4);
                break;
            case 4:
                tile.GetComponent<ManagerTile>().SetLevel(2, hasWaterThisTile, 5, 3, 4);
                break;
            case 5:
                tile.GetComponent<ManagerTile>().SetLevel(2, hasWaterThisTile, 5, 3, 4);
                break;
            case 6:
                tile.GetComponent<ManagerTile>().SetLevel(increaseValueMoreThan5 + 2, hasWaterThisTile, increaseValueMoreThan5 + 5, increaseValueMoreThan5 + 3, increaseValueMoreThan5 + 4);
                break;
            default:
                break;
        }
    }
    public void SetProbabilities(GameObject tile, int level)
    {

        switch (level)
        {
            case 0:
                tile.GetComponent<ManagerTile>().SetProbabilities(0f, 0.6f, 1f, 1f, 0.2f);
                break;
            case 1:
                tile.GetComponent<ManagerTile>().SetProbabilities(0f, 1f, 0f, 1f, 0f);
                break;
            case 2:
                tile.GetComponent<ManagerTile>().SetProbabilities(0f, 0f, 0f, 0f, 0f);
                //tile.GetComponent<ManagerTile>().SetProbabilities(0.5f, 0.6f, 0.2f, 0f, 0.9f);
                break;
            case 3:
                tile.GetComponent<ManagerTile>().SetProbabilities(0f, 0f, 0f, 0f, 0f);
                //tile.GetComponent<ManagerTile>().SetProbabilities(0.2f, 0.6f, 0.2f, 0f, 0.9f);
                break;
            case 4:
                tile.GetComponent<ManagerTile>().SetProbabilities(0f, 0f, 0f, 0f, 0f);
                //tile.GetComponent<ManagerTile>().SetProbabilities(0.2f, 0.6f, 0.2f, 0f, 0.9f);
                break;
            case 5:
                tile.GetComponent<ManagerTile>().SetProbabilities(0f, 0f, 0f, 0f, 0f);
                //tile.GetComponent<ManagerTile>().SetProbabilities(0.2f, 0.6f, 0.2f, 0f, 0.9f);
                break;
            case 6:
                tile.GetComponent<ManagerTile>().SetProbabilities(0.2f, 0.6f, 0.2f, 0f, 0.9f);
                break;
            default:
                break;
        }
    }
}
