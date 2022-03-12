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

    public AudioSource BasementDoor;
    public AudioSource Tension;
    public AudioSource AfterJumpscareAmbient;
    public AudioSource fthmission;
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
                BasementDoor.Play();
                Tension.Play();
                missionEndMarks[currentMission].SetActive(true);
                currentMissionArrow.transform.position = new Vector2(currentMissionArrow.transform.position.x, missionEndMarks[currentMission].transform.position.y); ;
                break;
            case 5:
                //mission2endscreenobj.SetActive(true);
                missionEndMarks[currentMission].SetActive(true);
                currentMissionArrow.transform.position = new Vector2(currentMissionArrow.transform.position.x, missionEndMarks[currentMission].transform.position.y); ;
                GameObject k = Instantiate(missionMarkPrefab, missionmarkinstantiator.position, Quaternion.identity);
                k.transform.SetParent(missionMarkParent.transform, false);
                k.transform.GetChild(0).GetComponent<Text>().text = "Find the distribution boxe";
                fthmission.Play();
                break;
            case 6:
                //mission2endscreenobj.SetActive(true);
                missionEndMarks[currentMission].SetActive(true);
                currentMissionArrow.transform.position = new Vector2(currentMissionArrow.transform.position.x, missionEndMarks[currentMission].transform.position.y); ;
                GameObject l = Instantiate(missionMarkPrefab, missionmarkinstantiator.position, Quaternion.identity);
                l.transform.SetParent(missionMarkParent.transform, false);
                l.transform.GetChild(0).GetComponent<Text>().text = "Search for a new fuse";
                AfterJumpscareAmbient.Play();
                break;
            case 7:
                //mission2endscreenobj.SetActive(true);
                missionEndMarks[currentMission].SetActive(true);
                currentMissionArrow.transform.position = new Vector2(currentMissionArrow.transform.position.x, missionEndMarks[currentMission].transform.position.y); ;
                GameObject x = Instantiate(missionMarkPrefab, missionmarkinstantiator.position, Quaternion.identity);
                x.transform.SetParent(missionMarkParent.transform, false);
                x.transform.GetChild(0).GetComponent<Text>().text = "Replace the fuse in the box";
                //AfterJumpscareAmbient.Play();
                break;
            case 8:
                //mission2endscreenobj.SetActive(true);
                missionEndMarks[currentMission].SetActive(true);
                currentMissionArrow.transform.position = new Vector2(currentMissionArrow.transform.position.x, missionEndMarks[currentMission].transform.position.y); ;
                GameObject z = Instantiate(missionMarkPrefab, missionmarkinstantiator.position, Quaternion.identity);
                z.transform.SetParent(missionMarkParent.transform, false);
                z.transform.GetChild(0).GetComponent<Text>().text = "GET OUT OF THE BASEMENT";
                //AfterJumpscareAmbient.Play();
                break;
            case 9:
                //mission2endscreenobj.SetActive(true);
                missionEndMarks[currentMission].SetActive(true);
                currentMissionArrow.transform.position = new Vector2(currentMissionArrow.transform.position.x, missionEndMarks[currentMission].transform.position.y); ;
                GameObject c = Instantiate(missionMarkPrefab, missionmarkinstantiator.position, Quaternion.identity);
                c.transform.SetParent(missionMarkParent.transform, false);
                c.transform.GetChild(0).GetComponent<Text>().text = "Go back to ur ultra hd RTX pc";
                //AfterJumpscareAmbient.Play();
                break;
        }

    }
}
