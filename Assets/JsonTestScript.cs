using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class JsonTestScript : MonoBehaviour
{
    public JsonTest jsonTest;
    public TextAsset json;

    void Start()
    {
        var test = JSON.Parse(json.ToString());
        Debug.Log(test["test"]);
        Debug.Log(json.ToString());
    }
}
