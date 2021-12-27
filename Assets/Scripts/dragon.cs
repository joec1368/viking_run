using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class dragon : MonoBehaviour
{
    float new_time;
    float time;
    public float miles = 10f;
    GameObject camera;
    public GameObject end;
    public Canvas can;
    // Start is called before the first frame update
    void Start()
    {
        float time = Time.time;
        

    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.name == "Viking_Axes")
        {
            
            Debug.Log("die");
            GameObject temp = Instantiate(end);
            temp.transform.SetParent(can.transform, true);
            Destroy(this);
        }
    }
    

}
