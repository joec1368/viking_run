using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    private bool turnleft, turnright;
    public float speed = 0.1f;
    private CharacterController characterController;
    private int judge = 0;
    [SerializeField] float JumpingForce = 10f;
    Rigidbody rb;
    public float timeOffset = 1000f;
    private float startTime;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        y = transform.position.y;
        road road = GetComponent<road>();

    }

    // Update is called once per frame
    void Update()
    {
        turnleft = Input.GetKeyDown(KeyCode.A);
        turnright = Input.GetKeyDown(KeyCode.D);

        if (turnleft) transform.Rotate(new Vector3(0f, -90f, 0f));
        else if(turnright) transform.Rotate(new Vector3(0f, 90f, 0f));

        
        //float y = transform.position.y;

        //  Vector3 myVector = new Vector3(0, 0, 0);
        //  transform.localPosition += speed * Time.deltaTime * myVector;

        transform.Translate(new Vector3(0f, 0f, Time.deltaTime* speed));

        if (Input.GetKey(KeyCode.Space))
        {
         
            if (transform.position.y - y <= 1 && transform.position.y - y >= -1)
            {
                rb.AddForce(JumpingForce * Vector3.up);
                judge = 1;
            
            }
        }
    }
 
}
