using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキスト使うなら必要？
using static ScoreTest;

public class ResultJudgeTest : MonoBehaviour
{

    public GameObject resultComboObj;
    public GameObject resultScoreObj;


    public Text resulComboText;
    public Text resultScoreText;



    // Start is called before the first frame update
    public void Start()
    {
        resultComboObj = GameObject.Find("ResultComboCount");
        resulComboText = resultComboObj.GetComponent<Text>();

        resultScoreObj = GameObject.Find("ResultScore");
        resultScoreText = resultScoreObj.GetComponent<Text>();


        Debug.Log(resulComboText);
        Debug.Log(resultScoreText);


        ShowResult();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowResult()
    {
        

    }



}
