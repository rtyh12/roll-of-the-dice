using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public TextAsset json;

    public JSONNode sceneJson;

    public int love;
    public int lastLoveChange;
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
    public LoveChangeScript loveChangeScript;

    static float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    void GoToNextDate()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
            int loveChange = sceneJson[currentNode]["answers"][option]["emotions"][emotion]["love"];
            love += loveChange;
            lastLoveChange = loveChange;
            StatsManager.setLoveScore(love);

            currentNode = sceneJson[currentNode]["answers"][option]["emotions"][emotion]["goto"];
            if (currentNode == "end")
            {
                GoToNextDate();
                return;
            }
        }
        catch
        {
            Debug.LogError("DIALOG MISSING");
        }

    }

    void SwitchPlayerAnswerGUIText(int option)
    {
        var playerText = sceneJson[currentNode]["answers"][option]["text"];

        button0.GetComponentInChildren<TextMeshProUGUI>().alpha = 0;
        button1.GetComponentInChildren<TextMeshProUGUI>().alpha = 0;
        button2.GetComponentInChildren<TextMeshProUGUI>().alpha = 0;
        button3.GetComponentInChildren<TextMeshProUGUI>().alpha = 0;

        // HACK UGH
        if (option == 0)
            button0.GetComponentInChildren<TextMeshProUGUI>().alpha = 1;
        else if (option == 1)
            button1.GetComponentInChildren<TextMeshProUGUI>().alpha = 1;
        else if (option == 2)
            button2.GetComponentInChildren<TextMeshProUGUI>().alpha = 1;
        else
            button3.GetComponentInChildren<TextMeshProUGUI>().alpha = 1;

        Debug.Log("Player says \"" + playerText + "\"");
    }

    void SwitchDialogGUIText(bool dontTriggerLoveChangeAnimation = false)
    {
        heartImage.fillAmount = Remap((float)love, -18f, 30f, 0f, 1f);

        if (!dontTriggerLoveChangeAnimation)
            loveChangeScript.TriggerAnimation(lastLoveChange);

        var question = sceneJson[currentNode]["question"];
        var answersJson = sceneJson[currentNode]["answers"];
        var answers = new List<string>();
        for (int i = 0; i < answersJson.Count; i++)
            answers.Add(answersJson[i]["text"]);

        questionText.text = question;

        button0.GetComponentInChildren<TextMeshProUGUI>().alpha = 1;
        button1.GetComponentInChildren<TextMeshProUGUI>().alpha = 1;
        button2.GetComponentInChildren<TextMeshProUGUI>().alpha = 1;
        button3.GetComponentInChildren<TextMeshProUGUI>().alpha = 1;
        
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
        love = StatsManager.getLoveScore();
        SwitchDialogGUIText(dontTriggerLoveChangeAnimation: true);
    }
}
