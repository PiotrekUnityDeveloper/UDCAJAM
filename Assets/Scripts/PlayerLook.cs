using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity;
    public Transform playerbean;
    public float xrot;

    public bool key1; //i know i could make a list but we have only 2 keys so no, na, nah thanks
    public bool key2;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        RenderSettings.fog = false;
        
    }

    [SerializeField] private LayerMask pickable;

    //RaycastHit hit;
    public Text raycastInfo;
    public Text raycastsubInfo;
    [SerializeField] private LayerMask raytarget;

    public GameObject rayshooterobj;
    

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

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
        if (Physics.Raycast(rayshooterobj.transform.position, rayshooterobj.transform.forward, out checker, 1500))
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
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            
            RaycastHit hit;
            //hit.distance = 15;
            if (Physics.Raycast(rayshooterobj.transform.position, rayshooterobj.transform.forward, out hit, 1500))
            {
                //Destroy(hit.transform.gameObject);
                if(hit.collider.tag == "key1")
                {
                    //pickup animation or smth here idk
                    key1 = true;
                    raycastInfo.text = "";
                    Destroy(hit.transform.gameObject);
                }
                else if (hit.collider.tag == "door" && hit.transform.gameObject.GetComponent<Door>() != null)
                {
                    if(hit.transform.gameObject.GetComponent<Door>().isOpened == true)
                    {
                        //close
                        hit.transform.gameObject.GetComponent<Door>().CloseDoor(this.gameObject.transform);
                    }
                    else if (hit.transform.gameObject.GetComponent<Door>().isOpened == false)
                    {
                        //open
                        hit.transform.gameObject.GetComponent<Door>().OpenDoor(this.gameObject.transform);
                    }
                }
            }


            
        }
    }
}
