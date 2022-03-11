using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public GameObject mission1endscreenobj;
    public GameObject mission2endscreenobj;

    public List<GameObject> missionEndMarks = new List<GameObject>();

    public GameObject missionMarkPrefab;

    public int currentMission;
    public Transform missionmarkinstantiator;

    public GameObject currentMissionArrow;

    public GameObject missionMarkParent;
    // Start is called before the first frame update
    void Start()
    {
        currentMission = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextMission()
    {
        currentMission += 1;
        currentMissionArrow.SetActive(true);
        print(currentMission);

        switch (currentMission)
        {
            case 1:
                //mission1endscreenobj.SetActive(true);
                missionEndMarks[currentMission].SetActive(true);
                currentMissionArrow.transform.position = new Vector2(currentMissionArrow.transform.position.x, missionEndMarks[currentMission].transform.position.y); ;
                GameObject g = Instantiate(missionMarkPrefab, missionmarkinstantiator.position, Quaternion.identity);
                g.transform.SetParent(missionMarkParent.transform, false);
                g.transform.GetChild(0).GetComponent<Text>().text = "Go to the basement";
                break;
            case 2:
                //mission2endscreenobj.SetActive(true);
                missionEndMarks[currentMission].SetActive(true);
                currentMissionArrow.transform.position = new Vector2(currentMissionArrow.transform.position.x, missionEndMarks[currentMission].transform.position.y); ;
                GameObject h = Instantiate(missionMarkPrefab, missionmarkinstantiator.position, Quaternion.identity);
                h.transform.SetParent(missionMarkParent.transform, false);
                h.transform.GetChild(0).GetComponent<Text>().text = "Find keys to the basement";
                break;
            case 3:
                //mission2endscreenobj.SetActive(true);
                missionEndMarks[currentMission].SetActive(true);
                currentMissionArrow.transform.position = new Vector2(currentMissionArrow.transform.position.x, missionEndMarks[currentMission].transform.position.y); ;
                GameObject j = Instantiate(missionMarkPrefab, missionmarkinstantiator.position, Quaternion.identity);
                j.transform.SetParent(missionMarkParent.transform, false);
                j.transform.GetChild(0).GetComponent<Text>().text = "Open the basement";
                break;
            case 4:
                //mission2endscreenobj.SetActive(true);
                //nothing :)
                missionEndMarks[currentMission].SetActive(true);
                break;
            case 5:
                //mission2endscreenobj.SetActive(true);
                missionEndMarks[currentMission].SetActive(true);
                currentMissionArrow.transform.position = new Vector2(currentMissionArrow.transform.position.x, missionEndMarks[currentMission].transform.position.y); ;
                GameObject k = Instantiate(missionMarkPrefab, missionmarkinstantiator.position, Quaternion.identity);
                k.transform.SetParent(missionMarkParent.transform, false);
                k.transform.GetChild(0).GetComponent<Text>().text = "Find the distribution boxes";
                break;
        }

    }
}
