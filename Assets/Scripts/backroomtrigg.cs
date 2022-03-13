using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backroomtrigg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject endSubtitles;
    public MissionManager missmanager1;
    public CinemachineCameraToggle cct;
    public AudioSource endDialog;
    public GameManager gm;
    public GameObject SNakeBlocker;
    public AudioSource SnakeMusic;

    public GameObject Secondpowerdown;
    public AudioSource PowerDownSound;

    public AudioSource fastmusicsrc;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(missmanager1.currentMission == 9)
            {
                endDialog.Play();
                cct.vcamIndex = 1;
                endSubtitles.SetActive(true);
                gm.canPause = false;
                SnakeMusic.Play();
                SNakeBlocker.SetActive(false);
                missmanager1.currentMission = 10; // done! :)
                StartCoroutine(countdownEnd());
            }
        }
    }

    private IEnumerator countdownEnd()
    {
        yield return new WaitForSeconds(5.4f);
        Secondpowerdown.SetActive(true);
        PowerDownSound.Play();
        SNakeBlocker.SetActive(true);
        fastmusicsrc.Stop();
        yield return new WaitForSecondsRealtime(3.0f);
        SceneManager.LoadScene("End");
    }
}
