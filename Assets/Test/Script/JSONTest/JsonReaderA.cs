using UnityEngine;

[System.Serializable]
public class JsonDataA
{

    public string[] ID = new string[0];
    public string[] CategoryA = new string[0];
    public string[] CategoryB = new string[0];
    public string[] CategoryC = new string[0];
    public string[] CategoryD = new string[0];
}

public class JsonReaderA : MonoBehaviour
{
    private void Start()
    {
        //Resourcesからdocument.jsonを読み込み、string型にキャスト
        string json = Resources.Load<TextAsset>("JsonTestData").ToString();

        //JsonDataA型のインスタンスを作成
        JsonDataA jsonData = new JsonDataA();

        //jsonのデータをjsonDataに格納
        JsonUtility.FromJsonOverwrite(json, jsonData);

        //出力
//        foreach(var item in jsonData){
            Debug.Log("ID: " + jsonData.ID);
            Debug.Log("CategoryA: " + jsonData.CategoryA);
            Debug.Log("CategoryB: " + jsonData.CategoryB);
            Debug.Log("CategoryC: " + jsonData.CategoryC);
            Debug.Log("CategoryD: " + jsonData.CategoryD);
//        }
    }
}