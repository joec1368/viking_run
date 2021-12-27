using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class show_last : MonoBehaviour
{
    float ans;
    public timer timer;
    public Text m_MyText;
    // Start is called before the first frame update
    void Start()
    {
        ans = timer.ans;
    }

    // Update is called once per frame
    private void Update()
    {



        m_MyText.text = "Survive Time : " + ans ;
      //  Debug.Log(ans);
    }

}
