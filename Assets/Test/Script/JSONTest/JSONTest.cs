using System;
using UnityEngine;

// 入力されるJSONに合わせてクラスを作成
[Serializable]
public class InputJson
{
    public string id;
    public string categoryA;
    public string categoryB;
    public string categoryC;
    public string categoryD;
}

public class JSONTest : MonoBehaviour
{
    void Start()
    {
        // 入力ファイルはAssets/Resources/input.json
        // input.jsonをテキストファイルとして読み取り、string型で受け取る
        string inputString = Resources.Load<TextAsset>("JsonTestData").ToString();
        // 上で作成したクラスへデシリアライズ
        InputJson inputJson = JsonUtility.FromJson<InputJson>(inputString);
        Debug.Log(inputJson.categoryA);  // abc
        Debug.Log(inputJson.categoryB);  // 150
        Debug.Log(inputJson.categoryC);  // 150
        Debug.Log(inputJson.categoryD);  // 150
    }
}