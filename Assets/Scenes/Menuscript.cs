using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuscript : MonoBehaviour
{
    AudioSource[] sources1;

    // Start is called before the first frame update
    void Start()
    {
        sources1 = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        VolUpdate1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGameonceagain()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void VolUpdate1()
    {
        foreach (AudioSource audiosrc in sources1)
        {
            if (audiosrc.gameObject.tag == "music")
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

    }
}
