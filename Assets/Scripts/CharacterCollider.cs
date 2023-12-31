using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    public CharacterController characterController;
    public Item itemCollision;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CollisionBack")
        {
            characterController.ChangeColliderItemPosition();
        }
        if (other.tag=="Item")
        {
            itemCollision = other.GetComponentInParent<Item>();
            MakeChangesWithTheItemCollision();
        }
        if (other.tag=="ColliderBackgroundR")
        {
            characterController.BlockMovementInDirection(true);
        }
        if (other.tag == "ColliderBackgroundL")
        {
            characterController.BlockMovementInDirection(false);

        }

    }
    public void MakeChangesWithTheItemCollision()
    {
        characterController.SetActualModifier(itemCollision.GetTypeItem());

        itemCollision.DestroyItems();

    }
}
