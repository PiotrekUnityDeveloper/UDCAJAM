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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedMessage());
    }

    public IEnumerator DelayedMessage()
    {
        yield return new WaitForSecondsRealtime(26);
        StartCoroutine(ShowMonologue("Hello, this is a clean looking test message which you can edit in any way you want :)", false, false, false, false));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Return) && canclose)
        {
            MonologuePanel.SetActive(false);
            /*
            pm.canmove = true;
            pl.canlook = true;
            pk.candrag = true;
            */
        }
    }

    public IEnumerator ShowMonologue(string phrase, bool skippable, bool cannmove, bool canlook, bool canpickup)
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

        /*
        if(cannmove == false)
        {
            pm.canmove = false;
        }

        if(canlook == false)
        {
            pl.canlook = false;
        }

        if (canpickup == false)
        {
            pk.candrag = false;
        }
        */

        

        foreach(char c in phrase)
        {
            yield return new WaitForSecondsRealtime(letterDelay);
            targetText.text += c;
        }

        enterinfo.SetActive(true);
        canclose = true;
    }
}
