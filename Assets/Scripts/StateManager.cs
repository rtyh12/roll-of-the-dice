using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI answerText;
    public Button button0;
    public Button button1;
    public Button button2;
    public Button button3;
    public Image heartImage;

    static float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    public void ChooseDialogOption(int option)
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

        try
        {
            SwitchPlayerAnswerGUIText(option);
            currentNode = sceneJson[currentNode]["answers"][option]["emotions"][emotion]["goto"];
            love += sceneJson[currentNode]["answers"][option]["emotions"][emotion]["love"];
        }
        catch
        {
            Debug.LogError("DIALOG MISSING");
        }

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

        questionText.text = question;
        button0.GetComponentInChildren<TextMeshProUGUI>().text = answers[0];
        button1.GetComponentInChildren<TextMeshProUGUI>().text = answers[1];
        button2.GetComponentInChildren<TextMeshProUGUI>().text = answers[2];
        button3.GetComponentInChildren<TextMeshProUGUI>().text = answers[3];
    }

    public void MessageDiceStopped()
    {
        timeSinceYeetEnd = 0;
        timeSinceYeetEndTimerStopped = false;
    }

    void Update()
    {
        heartImage.fillAmount = Remap((float)love, -18f, 30f, 0f, 1f);

        if (!timeSinceYeetEndTimerStopped)
            timeSinceYeetEnd += Time.deltaTime;

        if (timeSinceYeetEnd >= switchDialogGUITextDelay)
        {
            try
            {
                SwitchDialogGUIText();
            }
            catch
            {
                Debug.LogError("DIALOG MISSING");
            }
            timeSinceYeetEndTimerStopped = true;
            timeSinceYeetEnd = 0;
        }
    }

    void Start()
    {
        sceneJson = JSON.Parse(json.ToString());
        SwitchDialogGUIText();
    }
}
