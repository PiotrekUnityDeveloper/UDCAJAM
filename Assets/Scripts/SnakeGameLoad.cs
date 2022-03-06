using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SnakeGameLoad : MonoBehaviour
{
    public int snakegameBuildindex;
    private List<GameObject> activeScenes = new List<GameObject>(); //not used at all


    
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(snakegameBuildindex, LoadSceneMode.Additive);
    }

    public void ReloadGame()
    {
        SceneManager.UnloadSceneAsync(snakegameBuildindex);
        GameObject[] stufffromsnake = GameObject.FindGameObjectsWithTag("snakeobj");
        foreach(GameObject g in stufffromsnake)
        {
            Destroy(g);
        }
        SceneManager.LoadScene(snakegameBuildindex, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
