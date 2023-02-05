using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeItem
{
    None,
    IncreaseLife,
    DefKill,
    IncreaseSpeed,
    DecreaseSpeed,
    KillStroot,
    KillPlant
}
public class Item : MonoBehaviour
{
    public TypeItem type= TypeItem.None;
    // Start is called before the first frame update
    void Start()
    {
        //manager = GetComponentInParent<ManagerLevels>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public TypeItem GetTypeItem()
    {
        return type;
    }
    public void DestroyItems()
    {

        Destroy(gameObject);
    }
}
