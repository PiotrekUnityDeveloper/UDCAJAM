using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ineractionui : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string buttonText;
    public Text btntxt;
    public void OnPointerEnter(PointerEventData eventData)
    {
        ///throw new System.NotImplementedException();
        btntxt.text = (">" + buttonText + "<");

        if (btntxt.gameObject.activeInHierarchy == true)
        {
            btntxt.text = (">" + buttonText + "<");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ///throw new System.NotImplementedException();
        

        if(btntxt.gameObject.activeInHierarchy == true)
        {
            btntxt.text = ("> " + buttonText + " <");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
