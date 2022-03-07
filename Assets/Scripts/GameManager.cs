using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;

[ExecuteAlways]
public class GameManager : MonoBehaviour
{
    public ForwardRendererData frwrdRenderer;
    public GameObject postfxObj;
    public bool PostfxOn;
    ScriptableRendererFeature AmbientOclussion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AmbientOclussion = frwrdRenderer.rendererFeatures.Find(x => x.name == "AO");
        AmbientOclussion.SetActive(PostfxOn);
        postfxObj.SetActive(PostfxOn);
    }
}
