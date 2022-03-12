using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Cinemachine;
public class CinemachineCameraToggle : MonoBehaviour
{
    public CinemachineVirtualCamera[] vcam;
    public int vcamIndex;

    public Pickup pickup;
    public PlayerLook look;
    public PlayerMovement movement;

    public GameObject crosshairobj;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayCamera());

        if(PlayerPrefs.GetInt("skip", 0) == 1)
        {
            //skipping the cutscene
            //vcamIndex = 0;
            //pickup.candrag = true;
            //look.canlook = true;
            //movement.canmove = true;
            PlayerPrefs.DeleteKey("skip");
        }
    }

    public IEnumerator DelayCamera()
    {
        yield return new WaitForSecondsRealtime(22);
        vcamIndex = 0;
        crosshairobj.SetActive(true);
    }

    private bool loopdisabler;

    private bool canRetire = true;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < vcam.Length; i++) //foreach would fit better :o
        {
            if(i != vcamIndex)
            {
                vcam[i].Priority = 0;
            }
            else
            {
                vcam[i].Priority = 10;
            }
        }

        if(Input.GetKey(KeyCode.Backspace) && canRetire == true)
        {
            vcamIndex = 0;
            pickup.candrag = true;
            look.canlook = true;
            movement.canmove = true;
            crosshairobj.SetActive(true);
            canRetire = false;
        }

        if(PlayerPrefs.GetInt("skip", 0) == 1 && loopdisabler == false)
        {
            /*
            vcamIndex = 0;
            pickup.candrag = true;
            look.canlook = true;
            movement.canmove = true;

            loopdisabler = true;
            */
        }
    }
}
