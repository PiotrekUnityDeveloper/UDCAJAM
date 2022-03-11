using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frthmissiontrig : MonoBehaviour 
{
    //actually, fifth


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Typewriter typewriter;
    public MissionManager missionmanager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(missionmanager.currentMission == 4)
            {
                missionmanager.NextMission();
                typewriter.FifthMission();
            }
        }
    }
}
