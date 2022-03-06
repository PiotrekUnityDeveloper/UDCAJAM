using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool Vertical;

    private bool canrotate;

    public bool isOpened;
    // Start is called before the first frame update
    void Start()
    {
        opened1 = new Quaternion(this.transform.rotation.x, this.transform.rotation.y + 60f, this.transform.rotation.z, this.transform.rotation.w);
        opened2 = new Quaternion(this.transform.rotation.x, this.transform.rotation.y - 60f, this.transform.rotation.z, this.transform.rotation.w);
        closed = this.transform.rotation;
    }

    int lerpcounter;
    public Quaternion opened1;
    public Quaternion opened2;
    public Quaternion closed;

    public int rotType;

    // Update is called once per frame
    void Update()
    {
        if(canrotate == true && rotType == 1)
        {
            transform.rotation = Quaternion.Lerp(this.transform.rotation, opened1, 0.1f * Time.deltaTime);
            lerpcounter += 1;

            if(lerpcounter >= 10)
            {
                //stop the animation
                canrotate = false;
                lerpcounter = 0;
                isOpened = true;
            }
        }
        else if (canrotate == true && rotType == 2)
        {
            transform.rotation = Quaternion.Lerp(this.transform.rotation, opened2, 0.1f * Time.deltaTime);
            lerpcounter += 1;

            if (lerpcounter >= 10)
            {
                //stop the animation
                canrotate = false;
                lerpcounter = 0;
                isOpened = true;
            }
        }
        else if (canrotate == true && rotType == 3)
        {
            transform.rotation = Quaternion.Lerp(this.transform.rotation, closed, 0.75f);
            lerpcounter += 1;

            if (lerpcounter >= 3)
            {
                //stop the animation
                canrotate = false;
                lerpcounter = 0;
                isOpened = false;
            }
        }
    }

    public void OpenDoor(Transform player)
    {
        lerpcounter = 0;
        //Vector3 enemyLocalDir = this.transform.InverseTransformPoint(player.transform.position); doesnt work :(

        //print(enemyLocalDir);
        /*
        if (enemyLocalDir.x < 0)
        {
            //left
            rotType = 1;
            canrotate = true;
        }
        else if (enemyLocalDir.x > 0)
        {
            rotType = 2;
            canrotate = true;
            //right
        }
        */

        if(Vertical == false)
        {

            print("Player pos: " + player.position.x + " || Door pos: " + this.transform.position.x);

            if (player.position.x > this.transform.position.x)
            {
                rotType = 1;
                canrotate = true;
                print("greater");
            }
            else if (player.position.x < this.transform.position.x)
            {
                rotType = 2;
                canrotate = true;
                print("smaller");
            }

            
        }
        else if(Vertical == true)
        {
            if (player.position.z > this.transform.position.z)
            {
                rotType = 1;
                canrotate = true;
            }
            else if (player.position.z < this.transform.position.z)
            {
                rotType = 2;
                canrotate = true;
            }
        }
        
    }

    public void CloseDoor(Transform player)
    {
        Vector3 enemyLocalDir = this.transform.InverseTransformPoint(player.transform.position);
        //print(enemyLocalDir);
        lerpcounter = 0;
        rotType = 3;
        canrotate = true;
    }
}
