using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity;
    public Transform playerbean;
    public GameObject newPlayer;
    public float xrot;

    public bool key1; //i know i could make a list but we have only 2 keys so no, na, nah thanks
    public bool key2;


    public bool canlook;

    public float pickuprange;

    public MissionManager mm;
    public Typewriter tw;

    public AudioSource MainAmient;
    public AudioSource BasementAmbient1;
    public AudioSource BasementAmbient2;

    public GameObject TargetKey;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        RenderSettings.fog = false;
        canlook = false;
        StartCoroutine(DelayLook());
    }

    private IEnumerator DelayLook()
    {
        yield return new WaitForSecondsRealtime(24);
        canlook = true;
    }

    [SerializeField] private LayerMask pickable;

    //RaycastHit hit;
    public Text raycastInfo;
    public Text raycastsubInfo;
    [SerializeField] private LayerMask raytarget;

    public GameObject rayshooterobj;

    public GameObject jumpscareobj;
    public AudioSource jumpscaresound;

    public GameObject bloodyOverlay;

    public IEnumerator JumpscarePlayer()
    {
        yield return new WaitForSeconds(7);
        jumpscareobj.SetActive(true);
        jumpscaresound.Play();
        bloodyOverlay.SetActive(true);
        StartCoroutine(Hidebloodyoverlay());
        BasementAmbient2.Play();
    }

    private IEnumerator Hidebloodyoverlay()
    {
        yield return new WaitForSeconds(15);
        bloodyOverlay.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        if(canlook == false)
        {
            return;
        }

        float mousex = Input.GetAxis("Mouse X") * sensitivity;
        float mousey = Input.GetAxis("Mouse Y") * sensitivity;

        xrot -= mousey;
        xrot = Mathf.Clamp(xrot, -90f, 90);
        transform.localRotation = Quaternion.Euler(xrot, 0f ,0f);
        playerbean.Rotate(Vector3.up * mousex);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        /*
        RaycastHit check;
        //check = 15f;
        if (Physics.Raycast(ray, out check, pickable, 15))
        {
            if (check.collider.tag == "door")
            {
                raycastInfo.text = "toggle doors";
            }
        }
        */

        raycastInfo.text = "";

        RaycastHit checker;
        //hit.distance = 15;
        if (Physics.Raycast(rayshooterobj.transform.position, rayshooterobj.transform.forward, out checker, 3))
        {
            if(checker.collider.tag == "key1")
            {
                raycastInfo.text = "Basement keys";
            }
            else if (checker.collider.tag == "key2")
            {
                raycastInfo.text = "Attic keys";
            }
            else if (checker.collider.tag == "lockeddoor1")
            {
                raycastInfo.text = "Basement Doors";
            }
            else if (checker.collider.tag == "door")
            {
                raycastInfo.text = "Doors";
            }
            else if (checker.collider.tag == "candle")
            {
                raycastInfo.text = "Candle";
            }
            else if (checker.collider.tag == "fusebox")
            {
                raycastInfo.text = "Fuse box thing [E]";
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            
            RaycastHit hit;
            //hit.distance = 15;
            if (Physics.Raycast(rayshooterobj.transform.position, rayshooterobj.transform.forward, out hit, 3))
            {
                raycastsubInfo.text = "";

                //Destroy(hit.transform.gameObject);
                if(hit.collider.tag == "key1")
                {
                    //pickup animation or smth here idk
                    key1 = true;
                    raycastInfo.text = "";
                    Destroy(hit.transform.gameObject);
                    raycastsubInfo.text = "You found the basement key!";
                    StartCoroutine(delaySubText());
                    if(mm.currentMission == 2)//mission called: "find the basement key"
                    {
                        mm.NextMission();
                        tw.ThirdMission();
                    }
                }
                else if (hit.collider.tag == "fusebox")
                {
                    tw.BeforeJumpscare();
                    if (mm.currentMission == 5)
                    {
                        mm.NextMission();
                        StartCoroutine(JumpscarePlayer()); //jumpscare occurs after like 4 seconds or smth i dont remember sry
                    }

                }
                else if (hit.collider.tag == "door" && hit.transform.gameObject.GetComponent<Door>() != null)
                {
                    if(hit.transform.gameObject.GetComponent<DoorTest>().IsOpen == true)
                    {
                        //close
                        hit.transform.gameObject.GetComponent<DoorTest>().Close();
                        //hit.transform.gameObject.GetComponent<Door>().CloseDoor(this.gameObject.transform);
                    }
                    else if (hit.transform.gameObject.GetComponent<DoorTest>().IsOpen == false)
                    {
                        //open
                        hit.transform.gameObject.GetComponent<DoorTest>().Open(newPlayer.transform.position);
                        //hit.transform.gameObject.GetComponent<Door>().OpenDoor(this.gameObject.transform);
                    }
                }
                else if (hit.collider.tag == "lockeddoor1" && hit.transform.gameObject.GetComponent<Door>() != null)
                {

                    if(key1 == true)
                    {
                        if (hit.transform.gameObject.GetComponent<DoorTest>().IsOpen == true)
                        {
                            //close
                            hit.transform.gameObject.GetComponent<DoorTest>().Close();
                            //hit.transform.gameObject.GetComponent<Door>().CloseDoor(this.gameObject.transform);
                        }
                        else if (hit.transform.gameObject.GetComponent<DoorTest>().IsOpen == false)
                        {
                            //open
                            hit.transform.gameObject.GetComponent<DoorTest>().Open(newPlayer.transform.position);
                            //hit.transform.gameObject.GetComponent<Door>().OpenDoor(this.gameObject.transform);
                            if (mm.currentMission == 3)///mission called: "find the basement key"
                            {
                                mm.NextMission();
                                tw.FourthMission(); //umm...
                            }
                        }

                        //old code
                        /*
                        if (hit.transform.gameObject.GetComponent<Door>().isOpened == true)
                        {
                            //close
                            hit.transform.gameObject.GetComponent<Door>().CloseDoor(this.gameObject.transform);
                        }
                        else if (hit.transform.gameObject.GetComponent<Door>().isOpened == false)
                        {
                            //open
                            hit.transform.gameObject.GetComponent<Door>().OpenDoor(this.gameObject.transform);
                            if (mm.currentMission == 2)//mission called: "find the basement key"
                            {
                                mm.NextMission();
                                tw.FourthMission();
                            }
                        }
                        */
                    }
                    else
                    {
                        raycastsubInfo.text = "The basement is locked";
                        if(mm.currentMission == 1)
                        {
                            mm.NextMission();
                            tw.SecondMission();
                            TargetKey.SetActive(true);

                            BasementAmbient1.Play();

                        }
                        StartCoroutine(delaySubText());
                    }
                }
            }


            
        }


        
    }

    public IEnumerator delaySubText()
    {
        yield return new WaitForSecondsRealtime(1);
        raycastsubInfo.text = "";
    }


}
