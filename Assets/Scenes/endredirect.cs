using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endredirect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("OpenSnakeInfo", 12);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    [DllImport("__Internal")]
    private static extern void OpenNewTab(string url);

    public void openIt(string url)
    {
#if !UNITY_EDITOR && UNITY_WEBGL
             OpenNewTab(url);
#endif
    }

    void OpenSnakeInfo()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            openIt("https://www.google.com/search?q=when+snake+game+was+created&oq=when+snake+game+was+created&aqs=chrome.0.69i59j0i22i30.4132j0j7&sourceid=chrome&ie=UTF-8");
        }
        else
        {
            Application.OpenURL("https://www.google.com/search?q=when+snake+game+was+created&oq=when+snake+game+was+created&aqs=chrome.0.69i59j0i22i30.4132j0j7&sourceid=chrome&ie=UTF-8");
        }
    }
}
