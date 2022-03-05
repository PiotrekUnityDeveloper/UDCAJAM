using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeStuff : MonoBehaviour
{
    public int xSize, ySize;
    public GameObject block;

    GameObject head;
    public Material headmat, tailmat, foodmat;
    List<GameObject> tail;

    

    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        timebetweenmovements = 0.5f;
        dir = Vector2.right;
        createGrid();
        createPlayer();
        spawnFood();
        block.SetActive(false);

        //coroutine trigger here
    }

    GameObject food;

    private void spawnFood()
    {
        Vector3 spawnpos = getRandomPos();
        while (containedInSnake(spawnpos))
        {
            spawnpos = getRandomPos();
        }
        food = Instantiate(block);
        food.transform.position = new Vector3(spawnpos.x, spawnpos.y, 1);
        food.GetComponent<SpriteRenderer>().material = foodmat;
        food.SetActive(true);
    }

    private Vector3 getRandomPos()
    {
        return new Vector3(Random.Range(-xSize / 2 + 1, xSize / 2), Random.Range(-ySize / 2 + 1, ySize / 2), 1);
    }

    private bool containedInSnake(Vector3 spawnpos)
    {
        bool isInHead = spawnpos.x == head.transform.position.x && spawnpos.y == head.transform.position.y;
        bool isInTail = false;
        foreach(var item in tail)
        {
            if(item.transform.position.x == spawnpos.x && item.transform.position.y == spawnpos.y)
            {
                isInTail = true;
            }
        }
        return isInHead || isInTail;
    }

    private void createPlayer()
    {
        head = Instantiate(block) as GameObject;
        head.GetComponent<SpriteRenderer>().material = headmat;
        tail = new List<GameObject>();
    }

    public void createGrid()
    {
        for(int x = 0; x <= xSize; x++)
        {
            GameObject borderBottom = Instantiate(block) as GameObject;
            borderBottom.GetComponent<Transform>().position = new Vector3(x - xSize / 2, -ySize / 2, 1);

            GameObject borderTop = Instantiate(block) as GameObject;
            borderTop.GetComponent<Transform>().position = new Vector3(x - xSize / 2, ySize-ySize / 2, 1);

        }

        for (int y = 0; y <= ySize; y++)
        {
            GameObject borderRight = Instantiate(block) as GameObject;
            borderRight.GetComponent<Transform>().position = new Vector3(-xSize/2, y-(ySize/2), 1);

            GameObject borderLeft = Instantiate(block) as GameObject;
            borderLeft.GetComponent<Transform>().position = new Vector3(xSize-(xSize/2), y-(ySize/2), 1);


        }
    }

    float passedtime, timebetweenmovements;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }

        passedtime += Time.deltaTime;
        if(timebetweenmovements < passedtime)
        {
            passedtime = 0;
            //Move
            Vector3 newposition = head.GetComponent<Transform>().position + new Vector3(dir.x, dir.y, 1);

            if(newposition.x >= xSize/2 
                || newposition.x <= -xSize/2
                || newposition.y >= ySize/2
                || newposition.y <= -ySize/2)
            {
                //gameover
                Gameover();
            }

            foreach(var item in tail)
            {
                if(item.transform.position == newposition)
                {
                    //game over
                    Gameover();
                }
            }

            if(newposition.x == food.transform.position.x && newposition.y == food.transform.position.y)
            {
                GameObject newTile = Instantiate(block);
                newTile.SetActive(true);
                newTile.transform.position = food.transform.position;
                DestroyImmediate(food);
                head.GetComponent<SpriteRenderer>().material = tailmat;
                tail.Add(head);
                head = newTile;
                head.GetComponent<SpriteRenderer>().material = headmat;
                spawnFood();
            }
            else
            {
                if (tail.Count == 0)
                {
                    head.transform.position = newposition;
                }
                else
                {
                    head.GetComponent<SpriteRenderer>().material = tailmat;
                    tail.Add(head);
                    head = tail[0];
                    head.GetComponent<SpriteRenderer>().material = headmat;
                    tail.RemoveAt(0);
                    head.transform.position = newposition;
                }
            }

            
        }
    }

    public void Gameover()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //done :)
    }
}
