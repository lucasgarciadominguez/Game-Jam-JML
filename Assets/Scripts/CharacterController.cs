using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public Rigidbody rbTail;
    [SerializeField]
    GameManager gameManager;
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
            Vector3 tempVect = new Vector3(-h, -8, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
            Vector3 tempVectTail = new Vector3(0, -h, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rbTail.MovePosition(transform.position + tempVect);
        }


    }
}
