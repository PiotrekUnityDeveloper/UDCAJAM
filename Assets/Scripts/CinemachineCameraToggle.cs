using UnityEngine;
using Cinemachine;
public class CinemachineCameraToggle : MonoBehaviour
{
    public CinemachineVirtualCamera[] vcam;
    public int vcamIndex;
    // Start is called before the first frame update
    void Start()
    {
        
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
