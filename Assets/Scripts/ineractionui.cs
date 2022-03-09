using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ineractionui : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string buttonText;
    public void OnPointerEnter(PointerEventData eventData)
    {
        ///throw new System.NotImplementedException();
        this.gameObject.GetComponent<Text>().text = (">" + buttonText + "<");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ///throw new System.NotImplementedException();
        this.gameObject.GetComponent<Text>().text = ("> " + buttonText + " <");
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
