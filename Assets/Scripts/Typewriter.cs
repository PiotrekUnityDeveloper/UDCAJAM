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
                voiceovers[1].Play(); //voiceover2 sound //too lazy to update these comments up :/
                currentMonologue += 1;
            }
            else if (currentMonologue == 2)
            {
                StartCoroutine(ShowMonologue("Well, i think i just have to replace them and i'll be back here", false));
                voiceovers[2].Play(); //voiceover3 sound
                this.gameObject.GetComponent<MissionManager>().NextMission();
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

    public void SecondMission()
    {
        CoroutineStopper();
        StartCoroutine(ShowMonologue("Oh $#|+, the basement is locked. Where did i put the keys?", false));
        voiceovers[3].Play(); //fourth
    }

    public void ThirdMission()
    {
        CoroutineStopper();
        StartCoroutine(ShowMonologue("Got em!", false));
        voiceovers[4].Play(); //fifth
    }

    public void FourthMission()
    {
        //CoroutineStopper();
        //StartCoroutine(ShowMonologue("Got em!", false));
        //voiceovers[5].Play(); //fifth
        
    }

    public void FifthMission()
    {
        CoroutineStopper();
        StartCoroutine(ShowMonologue("Bro why this basement looks like it hasn't been cleaned for I=/_/C|%G twelve centuries?", false));
        voiceovers[5].Play();
        
    }

    public GameObject FuseToFind;

    public void BeforeJumpscare()
    {
        CoroutineStopper();
        FuseToFind.SetActive(true);
        StartCoroutine(ShowMonologue("Oh no! I dont have a new fuse! There should be one in this basement tho", false));
        //voiceovers[6].Play(); //future voiceover
        StartCoroutine(AfterJumpscareMonologue());
    }

    public IEnumerator AfterJumpscareMonologue()
    {
        yield return new WaitForSeconds(5);
        CoroutineStopper();
        StartCoroutine(ShowMonologue("What was that?", false));
    }

    public void FoundFuse()
    {
        CoroutineStopper();
        currentMonologue = 5;
        StartCoroutine(ShowMonologue("I have to replace it now!", false));
    }

    public GameObject HouseLights;

    public void ReplacedFuse()
    {
        CoroutineStopper();
        StartCoroutine(ShowMonologue("Okay, lets get the fuck outta here quick", false));
        HouseLights.SetActive(true);
    }

    public void BacktoFuseBoxMission()
    {
        //stuff
        //CoroutineStopper();
        //StartCoroutine(ShowMonologue("AH, it finally works!", false));
        //voiceovers[8].Play(); //future voiceover (seventh voiceover is: "what was that?")
    }

    public GameObject BasementLocker;

    public void GotOutOfBasement()
    {
        CoroutineStopper();
        BasementLocker.SetActive(true);
        StartCoroutine(ShowMonologue("Oh my god that was scary, lets get back to gaming now!", false));
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
            this.gameObject.GetComponent<MissionManager>().NextMission();
            currentMonologue += 1;
        }
        else if (currentMonologue == 3)
        {
            //StartCoroutine(ShowMonologue("Well, i think i just have to replace them and i'll be back here", false));
            //voiceovers[3].Play(); //future voiceover
            //this.gameObject.GetComponent<MissionManager>().NextMission();
            //USE THIS (IT IS EMPTY RN PLS DONT IGNORE)
            currentMonologue += 1;
        }
        else if (currentMonologue == 4)
        {
            //StartCoroutine(ShowMonologue("Well, i think i just have to replace them and i'll be back here", false));
            //voiceovers[3].Play(); //future voiceover
            //this.gameObject.GetComponent<MissionManager>().NextMission();
            //USE THIS (IT IS EMPTY RN PLS DONT IGNORE)
            currentMonologue += 1;
        }
        else if(currentMonologue == 5)
        {
            currentMonologue += 1;
        }

        print("Current Monologue is: " + currentMonologue);

    }
}
