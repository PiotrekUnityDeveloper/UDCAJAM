using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using System.Collections;
using UnityEngine.SceneManagement;

[ExecuteAlways]
public class GameManager : MonoBehaviour
{
    public ForwardRendererData frwrdRenderer;
    public GameObject postfxObj;
    public bool PostfxOn;
    ScriptableRendererFeature AmbientOclussion;

    //pause stuff
    public bool canPause;

    public bool isPaused;
    public GameObject PauseMenu;

    public PlayerMovement playermove;
    public PlayerLook playerlook;
    public Pickup pickup;
    // Start is called before the first frame update
    void Start()
    {
        canPause = false;
        StartCoroutine(DelayPauseMenu());
    }

    public IEnumerator DelayPauseMenu()
    {
        yield return new WaitForSecondsRealtime(23);
        canPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        AmbientOclussion = frwrdRenderer.rendererFeatures.Find(x => x.name == "AO");
        AmbientOclussion.SetActive(PostfxOn);
        postfxObj.SetActive(PostfxOn);

        if(Input.GetKey(KeyCode.Backspace))
        {
            canPause = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false && canPause == true)
            {
                
                playermove.canmove = false;
                playerlook.canlook = false;
                pickup.candrag = false;
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
        }

        if (isPaused == true)
        {

            playermove.canmove = false;
            playerlook.canlook = false;
            pickup.candrag = false;
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }

        if (isPaused == true && Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if(isPaused == false && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void UnPauseGame()
    {
        if (isPaused == true)
        {
            playermove.canmove = true;
            playerlook.canlook = true;
            pickup.candrag = true;
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            isPaused = false;
        }
    }

    public GameObject restartask;
    public void RestartDialog(bool state)
    {
        restartask.SetActive(state);

        if(state == true)
        {
            Exitdialog.SetActive(false);
        }
    }

    public void RestartGame(bool skipcutscene)
    {
        if(skipcutscene == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            PlayerPrefs.SetInt("skip", 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public GameObject Exitdialog;

    public void ToggleRestart()
    {
        if(restartask.activeInHierarchy == true)
        {
            restartask.SetActive(false);
        }
        else if (restartask.activeInHierarchy == false)
        {
            restartask.SetActive(true);
        }

        if (restartask.activeInHierarchy == true)
        {
            Exitdialog.SetActive(false);
            //add more stuff here
        }
    }

    public void ToggleExit()
    {
        if(Exitdialog.activeInHierarchy == true)
        {
            Exitdialog.SetActive(false);
        }
        else if (Exitdialog.activeInHierarchy == false)
        {
            Exitdialog.SetActive(true);
        }

        if(Exitdialog.activeInHierarchy == true)
        {
            restartask.SetActive(false);
            //add more stuff here
        }
    }

    public void ExitDialog(bool state)
    {
        Exitdialog.SetActive(state);

        if(state == true)
        {
            restartask.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
