using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Cinemachine;
public class CinemachineCameraToggle : MonoBehaviour
{
    public CinemachineVirtualCamera[] vcam;
    public int vcamIndex;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayCamera());
    }

    public IEnumerator DelayCamera()
    {
        yield return new WaitForSecondsRealtime(22);
        vcamIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < vcam.Length; i++)
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
    }
}
