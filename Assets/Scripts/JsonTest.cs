using UnityEngine;

[System.Serializable]
public class JsonTest
{
    public int test;
    public int test2;
    
    public static JsonTest CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<JsonTest>(jsonString);
    }
}