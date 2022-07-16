using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class StateManager : MonoBehaviour
{
    public TextAsset json;

    public JSONNode sceneJson;

    public int love;
    public string currentNode;

    public RollScript rollScript;

    public float timeSinceYeetEnd;
    public bool timeSinceYeetEndTimerStopped;
    public float switchDialogGUITextDelay;

    void ChooseDialogOption(int option)
    {
        Debug.Log("Player chooses answer no. " + option);
        
        rollScript.GenerateNewFace();
        rollScript.SwitchToRotating();
        int face = rollScript.currentFace;

        string emotion = new[] {
            "NONE",
            "love",
            "happy",
            "surprised",
            "uwu",
            "angry",
            "sad"
        }[face];

        SwitchPlayerAnswerGUIText(option);

        currentNode = sceneJson[currentNode]["answers"][option]["emotions"][emotion]["goto"];
        love += sceneJson[currentNode]["answers"][option]["emotions"][emotion]["love"];
    }

    [ContextMenu("Do Something")]
    void DoSomething()
    {
        ChooseDialogOption(0);
    }

    void SwitchPlayerAnswerGUIText(int option)
    {
        var playerText = sceneJson[currentNode]["answers"][option]["text"];
        Debug.Log("Player says \"" + playerText + "\"");
    }

    void SwitchDialogGUIText()
    {
        var question = sceneJson[currentNode]["question"];
        var answersJson = sceneJson[currentNode]["answers"];
        var answers = new List<string>();
        for (int i = 0; i < answersJson.Count; i++)
            answers.Add(answersJson[i]["text"]);

        // Debug.Log(question);
        // for (int i = 0; i < answers.Count; i++)
        //     Debug.Log(answers[i]);
        Debug.Log("Switch dialog to \"" + currentNode + "\"");
    }

    public void MessageDiceStopped()
    {
        timeSinceYeetEnd = 0;
        timeSinceYeetEndTimerStopped = false;
    }

    void Update()
    {
        if (!timeSinceYeetEndTimerStopped)
            timeSinceYeetEnd += Time.deltaTime;

        if (timeSinceYeetEnd >= switchDialogGUITextDelay)
        {
            SwitchDialogGUIText();
            timeSinceYeetEndTimerStopped = true;
            timeSinceYeetEnd = 0;
        }
    }

    void Start()
    {
        sceneJson = JSON.Parse(json.ToString());
    }
}
