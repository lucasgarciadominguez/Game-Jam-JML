using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScenes : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        gameObjectActual=Instantiate(scenePrefab,new Vector3(scenePrefab.transform.position.x, scenePrefab.transform.position.y - 10, scenePrefab.transform.position.z),Quaternion.identity);
        collisionChangeScene.transform.position=(new Vector3(collisionChangeScene.transform.position.x, collisionChangeScene.transform.position.y - distanceCollision, collisionChangeScene.transform.position.z));
    }
    public void ChangeBackgroundTile()
    {
        actualdistance += distance;
        actualdistanceCollision += distanceCollision;
        gameObjectActual = Instantiate(scenePrefab, new Vector3(scenePrefab.transform.position.x, -actualdistance, scenePrefab.transform.position.z), Quaternion.identity);
        collisionChangeScene.transform.position = new Vector3(collisionChangeScene.transform.position.x, -actualdistanceCollision, collisionChangeScene.transform.position.z);

    }
}
