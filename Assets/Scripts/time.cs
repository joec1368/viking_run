using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    public Text m_MyText;
    float time_start;
    public float ans;
    public timer timer;
    

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
      
        ans = timer.ans;
        m_MyText.text = "Survive Time : " + ans;
    }
   
}
