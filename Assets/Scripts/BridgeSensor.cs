using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]


public class BridgeSensor : MonoBehaviour
{
    float time = 0;
    public float number = 10;
    public GameObject camera;
    float new_time = 0;
    public float timedecide = 1f;
    private new Vector3 miles ;
    public GameObject dragon;
    public GameObject end;
    public Canvas can;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(dragon);

       // miles = dragon.transform.localPosition - camera.transform.localPosition;
        miles = new Vector3(0f, -3.5f, -2.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Viking_Axes")
        {
            time = Time.time;
            Debug.Log("enter");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.name == "Viking_Axes")
        {
            new_time = Time.time;
            Debug.Log("stay");
            if (new_time - time > timedecide)
            {
                // Application.Quit();
                GameObject temp = Instantiate(end);
                temp.transform.SetParent(can.transform, true);
                Destroy(this);
                Debug.Log("die");
            }

            dragon.transform.localPosition += new Vector3(0, 0, 0.1f);


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "Viking_Axes")
        {
            time = 0;
            Debug.Log("out");
            new_time = 0;
            dragon.transform.localPosition = camera.transform.localPosition + miles;
        }
    }
}
