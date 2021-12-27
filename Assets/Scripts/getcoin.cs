using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getcoin : MonoBehaviour
{
    public countcoin coin;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Viking_Axes")
        {
            coin.count++;
            Destroy(gameObject);
        }
    }
}
