using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
//[RequireComponent(typeof(Agent))]

public class controllers : MonoBehaviour
{
    public Vector3 MovingDirection;
    [SerializeField] float movingSpeed = 10f;


    // MeshRenderer mr;
    Rigidbody rb;
    int judge = 0;
    Animator animator;
    bool run;

    [SerializeField] float JumpingForce = 10f;




    void Awake()
    {
        Debug.Log("awake");
    }
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("Start");

        Transform tm = GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

       // mr = GetComponent<MeshRenderer>();

        //tm.position = Vector3.zero;
        
    }

    // Update is called once per frame
    void Update()
    {
        //mr.material.color = new Color((int)Time.time % 2 * 255f, 255f, 255f);
        run = false;
        
        if (Input.GetKey(KeyCode.W))
        {
            run = true;
            float x = transform.rotation.x;
            float y = transform.rotation.y;
            float z = transform.rotation.z;
            Vector3 myVector = new Vector3(x,0,z);
            transform.localPosition += movingSpeed * Time.deltaTime * myVector;
       
        }
        if (Input.GetKey(KeyCode.A))
        {
            run = true;
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            run = true;
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            run = true;
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.right;
        }
        if (Input.GetKey(KeyCode.Space)){
           // rb.AddForce(JumpingForce * Time.deltaTime * Vector3.up);
            //transform.localPosition += movingSpeed * Time.deltaTime * Vector3.up;
            if (judge == 0)
            {
                judge = 1;
                rb.AddForce(JumpingForce * Time.deltaTime * Vector3.up);
        //        Debug.Log(judge);
            }
        }
        //if (Input.GetKey(KeyCode.X))
        //{
        //    transform.localPosition += movingSpeed * Time.deltaTime * Vector3.down;
        //}
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0f, -2f, 0f));
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0f, 2f, 0f));
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit raycastHit;

            if (Physics.Raycast(r, out raycastHit))
            {
                Destroy(raycastHit.collider.gameObject);
            }
        }


        animator.SetBool("Run", run);
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        judge = 0;
        Debug.Log("en");
      //  Debug.Log(judge);
    }

    private void OnCollisionExit(Collision collision)
    {
        judge = 1;
        Debug.Log("ex");
       // Debug.Log(judge);
    }

    private void OnCollisionStay(Collision collision)
    {
        judge = 0;
    }


    
}
