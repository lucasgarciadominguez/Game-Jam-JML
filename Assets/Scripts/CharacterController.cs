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
            if (transform.position.x >= -8 &&  transform.position.x<=8)
            {
                float pos = transform.position.x+h*speedHorizontal;
                transform.Translate(new Vector3(h * speedHorizontal, -speedVertical, 0) * Time.deltaTime);
                Debug.Log("as");
            }
            else
            {
                if (transform.position.x>8)
                {
                    transform.position = new Vector3(8,transform.position.y,transform.position.z);

                }
                else if (transform.position.x<-8)
                {
                    transform.position = new Vector3(-8, transform.position.y, transform.position.z);

                }
                {

                }
            }
        }


    }
    public void BlockMovementInDirection(bool check)
    {
        if (check)  //right
        {

        }
        else
        {

        }
    }
    public void ChangeColliderItemPosition()
    {
        gameManager.sceneManager.ChangeBackgroundTile();
    }
    public void SetActualModifier(TypeItem typeItem)
    {
        gameManager.actualTypeItemAffecting = typeItem;
        gameManager.EffectModifier();
    }
    public void ApplySpeedMultiplier(float multiplier)
    {
        speedVertical += multiplier;
        speedHorizontal += multiplier;
    }
}
