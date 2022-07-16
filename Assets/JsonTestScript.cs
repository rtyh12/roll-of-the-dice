using UnityEngine;
using SimpleJSON;

public class JsonTestScript : MonoBehaviour
{
    public JsonTest jsonTest;
    public TextAsset json;

    void Start()
    {
        var test = JSON.Parse(json.ToString());

        var answers = test["are you dice"]["answers"];
        for (int i = 0; i < answers.Count; i++)
        {
            Debug.Log(answers[i]["text"]);
        };
    }
}
