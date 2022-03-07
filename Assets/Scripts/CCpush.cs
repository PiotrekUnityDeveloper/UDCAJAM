using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCpush : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [SerializeField] private float pushPower;
    [SerializeField] private float weight;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        var body = rb;

        Vector3 force;

        /*
        // no rigidbody
        if (body == null || body.isKinematic) { return; }
        // We dont want to push objects below us
        if (hit.moveDirection.y & lt; -0.3) { return; }
        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        var pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.
        // Apply the push
        body.velocity = pushDir * pushPower;
        */
        // no rigidbody
        if (body == null || body.isKinematic) { return; }

        // We use gravity and weight to push things down, we use
        // our velocity and push power to push things other directions
        if (hit.moveDirection.y < -0.3)
        {
            force = new Vector3(0, -0.5f, 0) * -9.81f * weight;
        }
        else
        {
            force = hit.controller.velocity * pushPower;
        }

        // Apply the push
        body.AddForceAtPosition(force, hit.point);
    }



}
