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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedMessage());
    }

    public IEnumerator DelayedMessage()
    {
        yield return new WaitForSecondsRealtime(26);
        if(blocker1 == true)
        {
            StartCoroutine(ShowMonologue("Oh FI_IC|<, the power is down", false));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Return) && canclose)
        {
            MonologuePanel.SetActive(false);
        }

        if(Input.GetKey(KeyCode.Backspace) & blocker1 == true)
        {
            StartCoroutine(DelayedMessageSkip());
            blocker1 = false;
        }
    }

    public IEnumerator DelayedMessageSkip()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(ShowMonologue("Oh FI_IC|<, the power is down", false));
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
    }
}
