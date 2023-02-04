using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float speedHorizontal;
    public float speedVertical;
    public Rigidbody rb;
    public Rigidbody rbTail;
    [SerializeField]
    GameManager gameManager;
    public float2 dimensionsScreenClamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.stateGame==States.Play)
        {
            float h = Input.GetAxisRaw("Horizontal");
            Vector3 tempVect = new Vector3(-h, -speedVertical, 0);
            tempVect = tempVect.normalized * speedHorizontal * Time.deltaTime;
            Vector3 finalPosition =transform.position + tempVect;
            rb.MovePosition(new Vector3(Mathf.Clamp(finalPosition.x,dimensionsScreenClamp.x,dimensionsScreenClamp.y),finalPosition.y,finalPosition.z));
            //Vector3 tempVectTail = new Vector3(0, -h, 0);
            //tempVect = tempVect.normalized * speed * Time.deltaTime;
            //rbTail.MovePosition(transform.position + tempVect);
        }


    }
    public void ChangeColliderItemPosition()
    {
        gameManager.sceneManager.ChangeBackgroundTile();
    }
    public void SetActualModifier(TypeItem typeItem)
    {
        gameManager.actualTypeItemAffecting = typeItem;
    }
}
