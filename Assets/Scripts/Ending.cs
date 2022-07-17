using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ending : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    public GameObject placeholder;

    public List<GameObject> prefabs = new List<GameObject>();
    public List<string> names = new List<string>();

    private string text = "Congratulations! You scored a second date with ";

    void Start()
    {
        int winner = StatsManager.getWinnerID();
        textMesh.text = text + names[winner];
        Instantiate(prefabs[winner], placeholder.transform);
    }
}
