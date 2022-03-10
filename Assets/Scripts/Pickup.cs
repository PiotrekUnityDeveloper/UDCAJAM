using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public float pickuprange;
    private GameObject heldobj;
    public float moveForce = 280f;

    public GameObject playerobj;

    public GameObject objHolder;

    public bool ExperimentalPhysics;
    public LayerMask GroundLayer;
    private bool wasground = false;

    public GameObject testObj;

    public Text MainRay;
    public Text SubRay;

    public bool candrag;
    // Start is called before the first frame update
    void Start()
    {
        candrag = false;
        StartCoroutine(DelayDrag());
    }

    private IEnumerator DelayDrag()
    {
        yield return new WaitForSecondsRealtime(22);
        candrag = true;
    }

    private Vector3 savedForce;

    // Update is called once per frame
    void Update()
    {

        if(candrag == false)
        {
            return;
        }

        RaycastHit hit1;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit1, pickuprange))
        {
            if(hit1.transform.gameObject.GetComponent<Rigidbody>() != null)
            {
                if(hit1.transform.gameObject.GetComponent<Rigidbody>().isKinematic == false)
                {
                    //SubRay.text = ""; maybe better not :/
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickuprange))
            {
                PickupObject(hit.transform.gameObject);
            }

        }

        if(Input.GetMouseButtonUp(0) && heldobj != null)
        {
            //drop obj
            DropObject();
        }

        if(Input.GetMouseButton(1) && heldobj != null)
        {
            ThrowObject();
        }



        if(heldobj != null)
        {
            MoveObject();
        }
    }

    public void MoveObject()
    {
        if(Vector3.Distance(heldobj.transform.position, objHolder.transform.position) > .1f)
        {
            Vector3 moveDir = (objHolder.transform.position - heldobj.transform.position);
            heldobj.GetComponent<Rigidbody>().AddForce(moveDir * moveForce);
            //heldobj.GetComponent<Rigidbody>().useGravity = true;
            //savedForce = heldobj.GetComponent<Rigidbody>().velocity;
            //heldobj.GetComponent<Rigidbody>().useGravity = false;
        }

        Vector3 moveDir2 = (objHolder.transform.position - heldobj.transform.position);
        testObj.GetComponent<Rigidbody>().AddForce(moveDir2 * moveForce);

        savedForce = testObj.GetComponent<Rigidbody>().velocity;
    }

    public void PickupObject(GameObject pickobj)
    {
        if(pickobj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickobj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = objHolder.transform;
            heldobj = pickobj;

            //Physics.IgnoreCollision(playerobj.GetInstanceID<Collider>(), heldobj.get) use layers instead

            //heldobj.tag = "nocollision";

            testObj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            if(heldobj.gameObject.layer == 6)
            {
                wasground = true;
                heldobj.gameObject.layer = 0;

                foreach(Transform t in heldobj.transform)
                {
                    t.gameObject.layer = 0;
                }
            }
            else
            {
                wasground = false;
            }

            print("heldobj layer: " + heldobj.layer);
        }
    }

    void DropObject()
    {
        if(heldobj.GetComponent<Rigidbody>())
        {
            Rigidbody heldRig = heldobj.GetComponent<Rigidbody>();
            heldobj.GetComponent<Rigidbody>().useGravity = true;
            heldRig.drag = 1;
            heldobj.transform.parent = null;
            if(ExperimentalPhysics == true)
            {
                heldobj.GetComponent<Rigidbody>().velocity = savedForce; //restores force that was applied when dragging the obj (so player can throw items without right mouse button.... and with less force)
            }

            if(wasground == true)
            {
                heldobj.gameObject.layer = 6;

                foreach (Transform t in heldobj.transform)
                {
                    t.gameObject.layer = 6;
                }

                wasground = false;
            }
            //else dont add the layer

            heldobj = null;
        }

        
    }

    void DropObjectforThrowing()
    {
        if (heldobj.GetComponent<Rigidbody>())
        {
            Rigidbody heldRig = heldobj.GetComponent<Rigidbody>();
            heldobj.GetComponent<Rigidbody>().useGravity = true;
            heldRig.drag = 1;
            heldobj.transform.parent = null;
            //heldobj = null;

            if (wasground == true)
            {
                heldobj.gameObject.layer = 6;

                foreach (Transform t in heldobj.transform)
                {
                    t.gameObject.layer = 6;
                }

                wasground = false;
            }
        }
    }

    void ThrowObject()
    {
        
        DropObjectforThrowing();
        heldobj.GetComponent<Rigidbody>().AddForce(this.transform.forward * 925f);
        heldobj = null;
    }
}
