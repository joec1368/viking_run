using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class close_text : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
   public GameObject text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(text);
    }
}
