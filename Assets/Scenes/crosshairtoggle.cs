using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshairtoggle : MonoBehaviour
{
    [SerializeField] private GameObject crosshairObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            crosshairObject.SetActive(!crosshairObject.activeInHierarchy);
        }
    }
}
