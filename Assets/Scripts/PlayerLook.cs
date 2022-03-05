using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xrot -= mousey;
        xrot = Mathf.Clamp(xrot, -90f, 90);
        transform.localRotation = Quaternion.Euler(xrot, 0f ,0f);
        playerbean.Rotate(Vector3.up * mousex);
    }
}
