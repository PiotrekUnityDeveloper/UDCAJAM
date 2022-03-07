using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float pickuprange;
    private GameObject heldobj;
    public float moveForce = 280f;

    public GameObject objHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
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
        }
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
        }
    }

    void ThrowObject()
    {
        
        DropObjectforThrowing();
        heldobj.GetComponent<Rigidbody>().AddForce(this.transform.forward * 925f);
        heldobj = null;
    }
}