using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outbasementtrigg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public MissionManager missmanag;
    public Typewriter tpw;
    public AudioSource fasssstmusic;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(missmanag.currentMission == 8)
            {
                missmanag.NextMission();
                tpw.GotOutOfBasement();
                fasssstmusic.Stop();
            }
        }
    }
}
