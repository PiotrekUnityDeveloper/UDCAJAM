using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainbowUI : MonoBehaviour
{
    private float debugF;

    // Start is called before the first frame update
    void Start()
    {
        debugF = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(this.gameObject.GetComponent<Image>().color == Color.HSVToRGB(1, 1, 1))
        {
            this.gameObject.GetComponent<Image>().color = Color.HSVToRGB(0, 1, 1);
            debugF = 0;
        }
        */
        

        this.gameObject.GetComponent<Image>().color = Color.HSVToRGB(debugF, 1, 1);
        debugF += 0.01f;

        if (debugF >= 1)
        {
            debugF = 0;
        }

        print("HSV should be equal to: " + debugF);
    }
}
