using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity;
    public Transform playerbean;
    public float xrot;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        RenderSettings.fog = false;
        
    }

    [SerializeField] private LayerMask pickable;

    //RaycastHit hit;
    public Text raycastInfo;

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

        RaycastHit check;
        //check = 15f;
        if (Physics.Raycast(ray, out check, pickable, 15))
        {
            if (check.collider.tag == "door")
            {
                raycastInfo.text = "toggle doors";
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            //hit.distance = 15;
            if (Physics.Raycast(ray, out hit, pickable, 15))
            {
                if(hit.collider.tag == "door")
                {
                    hit.transform.gameObject.GetComponent<Animator>().SetTrigger("open");
                }
            }
            
        }
    }
}
