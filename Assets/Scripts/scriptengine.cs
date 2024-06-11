using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptengine : MonoBehaviour
{
    public string FileName;
    public ScenarioEngine engine;

    // Start is called before the first frame update
    void Start()
    {
            

    }

  
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            string script = Resources.Load<TextAsset>(FileName).ToString();
            StartCoroutine(engine.PlayScript(script));
        }
    }
}

