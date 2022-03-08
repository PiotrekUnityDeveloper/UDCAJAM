using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController charcontrol;
    public float movementspeed;
    public float gravity = -9.81f;

    public Vector3 velocity;
    [SerializeField] private Transform groundCheckObj;
    public float checkRadius = 0.4f;
    public LayerMask groundLayer;
    public bool isGrounded;

    public float jumpHeight;

    public bool canmove;

    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        canmove = false;
        StartCoroutine(DelayMovement());
    }

    private IEnumerator DelayMovement()
    {
        yield return new WaitForSecondsRealtime(24);
        canmove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canmove == false)
        {
            return;
        }

        isGrounded = Physics.CheckSphere(groundCheckObj.position, checkRadius, groundLayer);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = /*Input.GetAxis("Horizontal")*/0;
        float z = /*Input.GetAxis("Vertical")*/0;

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerObject.transform.localScale = new Vector3(playerObject.transform.localScale.x, 0.55f, playerObject.transform.localScale.z);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerObject.transform.localScale = new Vector3(playerObject.transform.localScale.x, 1.3f, playerObject.transform.localScale.z);
        }

        Vector3 movedir = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.W)) //go up
        {
            z = 1;
        }

        if (Input.GetKey(KeyCode.S)) //go down
        {
            z = -1;
        }

        if (Input.GetKey(KeyCode.A)) //go left
        {
            x = -1;
        }

        if (Input.GetKey(KeyCode.D)) //go right
        {
            x = 1;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            x = 0;
            z = 0; //PLAYER CANNOT MOVE WITH ARROWS (they are supposed to work with snake game only)
            goto tap1;
        }

        movedir = transform.right * x + transform.forward * z;
        charcontrol.Move(movedir * movementspeed * Time.deltaTime);

        tap1:

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpHeight;
        }

        velocity.y += gravity * Time.deltaTime;

        charcontrol.Move(velocity * Time.deltaTime);
    }
}
