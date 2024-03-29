using TMPro;
using UnityEngine;

public class LoveChangeScript : MonoBehaviour
{
    private float time;
    
    private float current;
    public float start, end;
    public float duration;

    private float currentAlpha;
    public float startAlpha, endAlpha;
    public float durationAlpha;

    public Color colorInitial;
    public RectTransform rectTransform;
    public TextMeshProUGUI textMeshPro;

    [ContextMenu("TriggerAnimation")]
    public void TriggerAnimation(int value)
    {
        string strValue = value.ToString();
        if (strValue[0] != '-')
            strValue = '+' + strValue;
        textMeshPro.text = strValue;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        current = ((time / duration) * end) + ((1 - (time / duration)) * start);
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x,
                                                  current,
                                                  rectTransform.localPosition.z);
        textMeshPro.alpha = ((time / durationAlpha) * endAlpha) + ((1 - (time / durationAlpha)) * startAlpha);
    }

    void Start() {
        textMeshPro.alpha = 0;
    }
}
