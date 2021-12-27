using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judge : MonoBehaviour
{
    public float die = 2.5f;
    public GameObject end;
    public Canvas can;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < die)
        {
           // Application.Quit();
            Debug.Log("die");
            GameObject temp = Instantiate(end);
            temp.transform.SetParent(can.transform, true);
           Destroy(this);
        }

    }
}
