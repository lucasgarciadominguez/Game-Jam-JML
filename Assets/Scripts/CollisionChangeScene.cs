using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionChangeScene : MonoBehaviour
{
    public ManagerScenes sceneManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        sceneManager.ChangeBackgroundTile();
    }



}
