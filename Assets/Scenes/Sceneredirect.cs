using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneredirect : MonoBehaviour
{
    public string newScenename;
    
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(newScenename);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
