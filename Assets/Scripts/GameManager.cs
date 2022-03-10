using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public ForwardRendererData frwrdRenderer;
    public GameObject postfxObj;
    public bool PostfxOn;
    ScriptableRendererFeature AmbientOclussion;

    //pause stuff
    public bool canPause;

    //public GameObject poweroff; <-- unused
    AudioSource[] sources;

    public bool isPaused;
    public GameObject PauseMenu;

    public PlayerMovement playermove;
    public PlayerLook playerlook;
    public Pickup pickup;

    private void Awake()
    {
        sources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        UpdateAudioVolume();
        UpdateExperimentalPhysics();
    }

    // Start is called before the first frame update
    void Start()
    {
        canPause = false;
        StartCoroutine(DelayPauseMenu());
        StartCoroutine(blocker());
        snakemusic.Play();
    }

    public IEnumerator blocker()
    {
        yield return new WaitForSecondsRealtime(22);
        snakeblocker.SetActive(true);
        
    }

    public IEnumerator DelayPauseMenu()
    {
        yield return new WaitForSecondsRealtime(23);
        canPause = true;
    }

    public AudioSource snakemusic;
    public GameObject snakeblocker;

    // Update is called once per frame
    void Update()
    {
        //print("test");

        if(Input.GetKey(KeyCode.Backspace))
        {
            canPause = true;
            //enable snake blockviewer and stop snake music here
            snakemusic.Stop();
            snakeblocker.SetActive(true);
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("isPaused = " + isPaused);
            Debug.Log("canPause = " + canPause);

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

        AmbientOclussion = frwrdRenderer.rendererFeatures.Find(x => x.name == "AO");
        AmbientOclussion.SetActive(PostfxOn);
        postfxObj.SetActive(PostfxOn);

        if (isPaused == true)
        {

            playermove.canmove = false;
            playerlook.canlook = false;
            pickup.candrag = false;
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            //isPaused = true;
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
            settingsdialog.SetActive(false);
            howtoplay.SetActive(false);
            credits.SetActive(false);
            Menudialog.SetActive(false);
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
            settingsdialog.SetActive(false);
            howtoplay.SetActive(false);
            credits.SetActive(false);
            Menudialog.SetActive(false);
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

    public GameObject settingsdialog;

    public void ToggleSettigs()
    {
        if (settingsdialog.activeInHierarchy == true)
        {
            settingsdialog.SetActive(false);
        }
        else if (settingsdialog.activeInHierarchy == false)
        {
            settingsdialog.SetActive(true);
        }

        if (settingsdialog.activeInHierarchy == true)
        {
            restartask.SetActive(false);
            Exitdialog.SetActive(false);
            howtoplay.SetActive(false);
            credits.SetActive(false);
            Menudialog.SetActive(false);
            //add more stuff here
        }
    }

    public Slider ambientVol;
    public Slider musicVol;
    public Slider SFXvol;

    public Toggle expphysics;
    public Pickup expphysicsswtich;


    public void SettingsDialogDone()
    {
        PlayerPrefs.SetFloat("ambient", ambientVol.value);
        PlayerPrefs.SetFloat("music", musicVol.value);
        PlayerPrefs.SetFloat("sfx", SFXvol.value);

        expphysicsswtich.ExperimentalPhysics = expphysics.isOn;

        if(expphysics.isOn == true)
        {
            PlayerPrefs.SetInt("expphy", 1);
        }
        else
        {
            PlayerPrefs.SetInt("expphy", 0);
        }
    }

    public void UpdateExperimentalPhysics()
    {
        if(PlayerPrefs.GetInt("expphy", 0) == 0)
        {
            expphysicsswtich.ExperimentalPhysics = false;
        }
        else
        {
            expphysicsswtich.ExperimentalPhysics = true;
        }
    }

    public void UpdateAudioVolume()
    {
        foreach(AudioSource audiosrc in sources)
        {
            if(audiosrc.gameObject.tag == "music")
            {
                audiosrc.volume = PlayerPrefs.GetFloat("music", 0.7f);
            }
            else if (audiosrc.gameObject.tag == "sfx")
            {
                audiosrc.volume = PlayerPrefs.GetFloat("sfx", 0.8f);
            }
            else if (audiosrc.gameObject.tag == "ambient")
            {
                audiosrc.volume = PlayerPrefs.GetFloat("ambient", 0.5f);
            }
        }

        ambientVol.value = PlayerPrefs.GetFloat("ambient", 0.5f);
        SFXvol.value = PlayerPrefs.GetFloat("sfx", 0.8f);
        musicVol.value = PlayerPrefs.GetFloat("music", 0.7f);
    }

    public GameObject howtoplay;

    public void ToggleHowtoPlay()
    {
        if (howtoplay.activeInHierarchy == true)
        {
            howtoplay.SetActive(false);
        }
        else if (howtoplay.activeInHierarchy == false)
        {
            howtoplay.SetActive(true);
        }

        if (howtoplay.activeInHierarchy == true)
        {
            restartask.SetActive(false);
            Exitdialog.SetActive(false);
            settingsdialog.SetActive(false);
            credits.SetActive(false);
            Menudialog.SetActive(false);
            //add more stuff here
        }
    }

    public Text copybtntext;
    public void CopyMusicGuyTag()
    {
        EditorGUIUtility.systemCopyBuffer = "iceBRG#3251";
        copybtntext.text = "Copied to clipboard!"; 
    }

    public void OpenPiotre4Website()
    {
        Application.OpenURL("https://piotrekunitydeveloper.github.io/piotrek4.games-page-files-download-backup-ctth-malicious-security-leak-scam-prototype/");
    }

    public GameObject credits;
    public GameObject Menudialog;

    public void ToggleCredits()
    {
        if (credits.activeInHierarchy == true)
        {
            credits.SetActive(false);
        }
        else if (credits.activeInHierarchy == false)
        {
            credits.SetActive(true);
        }

        if (credits.activeInHierarchy == true)
        {
            restartask.SetActive(false);
            Exitdialog.SetActive(false);
            settingsdialog.SetActive(false);
            howtoplay.SetActive(false);
            Menudialog.SetActive(false);
            //add more stuff here
        }
    }

    public void ToggleMenuDialog()
    {
        if (Menudialog.activeInHierarchy == true)
        {
            Menudialog.SetActive(false);
        }
        else if (Menudialog.activeInHierarchy == false)
        {
            Menudialog.SetActive(true);
        }

        if (Menudialog.activeInHierarchy == true)
        {
            restartask.SetActive(false);
            Exitdialog.SetActive(false);
            settingsdialog.SetActive(false);
            howtoplay.SetActive(false);
            //Menudialog.SetActive(false);
            credits.SetActive(false);
            //add more stuff here
        }
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
