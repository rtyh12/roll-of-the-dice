using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ending : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    public GameObject placeholder;
    public GameObject sphere;
    public GameObject D20;
    public GameObject plane;
    public GameObject cone;
    public GameObject moebius;
    public GameObject prism;


    private string text = "Congratulations! You scored a second date with ";

    // Start is called before the first frame update
    void Start()
    {
        int winner = StatsManager.getWinnerID();
        if (winner == 0)
        {
            text = text + "Sphere";
            textMesh.text = text;
            Instantiate(sphere,placeholder.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
