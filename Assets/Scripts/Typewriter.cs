using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{
    public GameObject MonologuePanel;
    public Text targetText;
    public float letterDelay;

    public GameObject enterinfo;

    private bool canclose;

    public PlayerMovement pm;
    public PlayerLook pl;
    public Pickup pk;

    private bool blocker1;

    private int currentMonologue = 0;

    // Start is called before the first frame update
    void Start()
    {
        blocker1 = true;
        StartCoroutine(DelayedMessage());
    }

    //public AudioSource voice1;
    //public AudioSource voice2;
    //public AudioSource voice3; //using a list from now

    public List<AudioSource> voiceovers = new List<AudioSource>();

    public IEnumerator DelayedMessage()
    {
        yield return new WaitForSecondsRealtime(26);
        if(blocker1 == true)
        {
            StartCoroutine(ShowMonologue("Oh FI_IC|<, the power is down", false));
            currentMonologue = 1;
            //voice1.Play();
            voiceovers[0].Play(); //voiceover1 sound
            blocker1 = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Return) && canclose)
        {
            MonologuePanel.SetActive(false);
            CoroutineStopper();

            if (currentMonologue == 1)
            {
                StartCoroutine(ShowMonologue("I think the fuses have blown", false));
                voiceovers[1].Play(); //voiceover1 sound
                currentMonologue += 1;
            }
            else if (currentMonologue == 2)
            {
                StartCoroutine(ShowMonologue("Well, i think i just have to replace them and i'll be back here", false));
                voiceovers[2].Play(); //voiceover1 sound
                currentMonologue += 1;
            }


        }

        if(Input.GetKey(KeyCode.Backspace) & blocker1 == true)
        {
            StartCoroutine(DelayedMessageSkip());
            blocker1 = false;
        }
    }

    public void CoroutineStopper()
    {
        this.StopAllCoroutines();
    }

    public IEnumerator DelayedMessageSkip()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(ShowMonologue("Oh FI_IC|<, the power is down", false));
        currentMonologue = 1;
        voiceovers[0].Play(); //voiceover1 sound
    }

    public IEnumerator ShowMonologue(string phrase, bool skippable)
    {
        if(MonologuePanel.activeInHierarchy == true)
        {
            yield return null;
        }

        MonologuePanel.SetActive(true);
        enterinfo.SetActive(false);

        targetText.text = "";

        if (skippable == false)
            canclose = false;
        else
            canclose = true;


        

        foreach(char c in phrase)
        {
            yield return new WaitForSeconds(letterDelay);
            targetText.text += c;
        }

        enterinfo.SetActive(true);
        canclose = true;
        StartCoroutine(autoclose());
    }

    public IEnumerator autoclose()
    {
        if(MonologuePanel.activeInHierarchy == true)
        {
            enterinfo.gameObject.GetComponent<Text>().text = "[ENTER TO CLOSE (" + 6 + ")]";
        }
        yield return new WaitForSeconds(1);
        if (MonologuePanel.activeInHierarchy == true)
        {
            enterinfo.gameObject.GetComponent<Text>().text = "[ENTER TO CLOSE (" + 5 + ")]";
        }
        yield return new WaitForSeconds(1);
        if (MonologuePanel.activeInHierarchy == true)
        {
            enterinfo.gameObject.GetComponent<Text>().text = "[ENTER TO CLOSE (" + 4 + ")]";
        }
        yield return new WaitForSeconds(1);
        if (MonologuePanel.activeInHierarchy == true)
        {
            enterinfo.gameObject.GetComponent<Text>().text = "[ENTER TO CLOSE (" + 3 + ")]";
        }
        yield return new WaitForSeconds(1);
        if (MonologuePanel.activeInHierarchy == true)
        {
            enterinfo.gameObject.GetComponent<Text>().text = "[ENTER TO CLOSE (" + 2 + ")]";
        }
        yield return new WaitForSeconds(1);
        if (MonologuePanel.activeInHierarchy == true)
        {
            enterinfo.gameObject.GetComponent<Text>().text = "[ENTER TO CLOSE (" + 1 + ")]";
        }
        yield return new WaitForSeconds(1);
        if (MonologuePanel.activeInHierarchy == true)
        {
            MonologuePanel.SetActive(false);
        }

        //copy the currentmonolugue check here
        if (currentMonologue == 1)
        {
            StartCoroutine(ShowMonologue("I think the fuses have blown", false));
            voiceovers[1].Play(); //voiceover1 sound
            currentMonologue += 1;
        }
        else if (currentMonologue == 2)
        {
            StartCoroutine(ShowMonologue("Well, i think i just have to replace them and i'll be back here", false));
            voiceovers[2].Play(); //voiceover1 sound
            currentMonologue += 1;
        }
    }
}
