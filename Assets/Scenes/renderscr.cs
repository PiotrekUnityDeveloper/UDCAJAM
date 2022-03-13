using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class renderscr : MonoBehaviour
{
    public Text sourcetext;
    private bool canLoad = false;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("Done1", UnityEngine.Random.Range(0.6f, 3.1f)); //yes! this rendering screen is fake, haha! :D
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && canLoad == true)
        {
            //RedirectScenes();
            sourcetext.text = "";
            FakeRedirect();
            canLoad = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canLoad == true)
        {
            //RedirectScenes();
            sourcetext.text = "";
            //FakeRedirect();
            StartCoroutine(ReloadDelay());
            canLoad = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && canLoad == true)
        {
            //RedirectScenes();
            sourcetext.text = "";
            //FakeRedirect();
            StartCoroutine(ExitGame());
            canLoad = false;
        }
    }

    public void Done1()
    {
        sourcetext.text = "Rendering finished " + Environment.NewLine + Environment.NewLine + "[PRESS ENTER TO LOAD GAME]" + Environment.NewLine + "[PRESS SPACE TO LOAD MAIN MENU]" + Environment.NewLine + "[PRESS ESCAPE TO UNLOAD THE GAME]";
        canLoad = true;
    }

    public void RedirectScenes()
    {
        sourcetext.text = "Loading...";
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void FakeRedirect()
    {
        sourcetext.text += "Nope bro, u go to menu :)";
        Invoke("LoadMenu", 2f);
    }

    public void LoadMenu()
    {
        StartCoroutine(ReloadDelay());
    }

    private IEnumerator ReloadDelay()
    {
        sourcetext.text += Environment.NewLine + "loading starts in.. 3";
        yield return new WaitForSecondsRealtime(1f);
        sourcetext.text += Environment.NewLine + "loading starts in.. 2";
        yield return new WaitForSecondsRealtime(1f);
        sourcetext.text += Environment.NewLine + "loading starts in.. 1";
        yield return new WaitForSecondsRealtime(1f);
        sourcetext.text += Environment.NewLine + "Please wait...";
        SceneManager.LoadSceneAsync("Menu");
    }

    private IEnumerator ExitGame()
    {
        sourcetext.text += Environment.NewLine + "leaving in.. 3";
        yield return new WaitForSecondsRealtime(1f);
        sourcetext.text += Environment.NewLine + "leaving in.. 2";
        yield return new WaitForSecondsRealtime(1f);
        sourcetext.text += Environment.NewLine + "leaving in.. 1";
        yield return new WaitForSecondsRealtime(1f);
        sourcetext.text += Environment.NewLine + "Byo!...";
        SceneManager.LoadSceneAsync("No");
        Application.Quit();
    }

}
