using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeGameLoad : MonoBehaviour
{
    public int snakegameBuildindex;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(snakegameBuildindex, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
