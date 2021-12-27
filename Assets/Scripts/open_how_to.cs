using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class open_how_to : MonoBehaviour , IPointerClickHandler
{
    public GameObject text;
    public Canvas can;
    // Start is called before the first frame update
    void Start()
    {
       // text.transform
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject temp = Instantiate(text);
        temp.transform.SetParent(can.transform, true);
    }
}
