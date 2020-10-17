﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //テキスト使うなら必要
using UnityEngine;
using static UnityEngine.GameObject;

public class ScoreTest : MonoBehaviour
{
    public int comboCountNum = 0;
    const float baseScore = 100.0f;
    public float totalScore = 0.0f;

    public Text comboText;
    public Text scoreText;

    public float[] timeJudgeRange = new float[5]; //回答までの時間区分け
    public float[] timeJudgeValue = new float[6];　//回答までの時間による係数

    public CharacterTest at;

    public bool successResult;

    private GameObject ctj;

        

    /// <summary>
    /// 成功したか失敗したかを、ゲームを管理するクラスからこいつへ教えてあげる
    /// </summary>
    /// <param name="success"></param>
    /// 

    public void Start()
    {
        GameObject comboTextObj = GameObject.Find("comboCount");
        GameObject scoreTextObj = GameObject.Find("score");

        comboText = comboTextObj.GetComponentInChildren<Text>();
        scoreText = scoreTextObj.GetComponentInChildren<Text>();

        Debug.Log(comboText);
        Debug.Log(scoreText);

        at = GameObject.Find("CharacterAll").GetComponent<CharacterTest>();
        ctj = GameObject.Find("correctTimeJudge"); 

    }


    public void Update()
    {


    }

    public void AddResult(bool success)
     {

        successResult = success;

        float answerTimeRange = at.GetAnswerTime();

            if (success)
            {
                comboCountNum++;
               // Debug.Log(GetScore());
            }
            else if ((success)&&(answerTimeRange > timeJudgeRange[3]))  //成功だが3秒以上かかっててもだめ
            {
            comboCountNum = 0;

            }
            else
            {
                comboCountNum = 0;

            }
            
        scoreText.text = "スコア:" + GetScore(answerTimeRange);
        comboText.text = comboCountNum.ToString() + "コンボ";
        //Debug.Log(comboCountNum + "コンボ");
        //Debug.Log("スコア"+GetScore());
    }

    /// <summary>
    /// 現状でのスコアをゲッツ
    /// </summary>
    /// <returns>コンボによる倍率をかけた値を返す</returns>
    public float GetScore(float pastAnswerTime)
    {
        float coefficient = 0.0f;

       if ((pastAnswerTime <= timeJudgeRange[0]) && (successResult))
        {
            coefficient = timeJudgeValue[0];
            Debug.Log("Great!" + timeJudgeValue[0]);
            ctj.GetComponent<TextMesh>().text = "Great!";
        }
       else if ((pastAnswerTime > timeJudgeRange[0]) && (pastAnswerTime <= timeJudgeRange[1]) && (successResult))
        {
            coefficient = timeJudgeValue[1];
            Debug.Log("Good" + timeJudgeValue[1]);
            ctj.GetComponent<TextMesh>().text = "Good!";
        }
        else if ((pastAnswerTime > timeJudgeRange[1]) && (pastAnswerTime <= timeJudgeRange[2]) && (successResult))
        {
            coefficient = timeJudgeValue[2];
            Debug.Log("better" + timeJudgeValue[2]);
            ctj.GetComponent<TextMesh>().text = "better!";
        }
        else if ((pastAnswerTime > timeJudgeRange[2]) && (pastAnswerTime <= timeJudgeRange[3]) && (successResult))
        {
            coefficient = timeJudgeValue[3];
            ctj.GetComponent<TextMesh>().text = "NotBad";
            Debug.Log("NotBad");
        }
       else if ((pastAnswerTime > timeJudgeRange[3]) && (pastAnswerTime <= timeJudgeRange[4]) && (successResult))
        {
            coefficient = timeJudgeValue[4];
            ctj.GetComponent<TextMesh>().text = "Bad";

            Debug.Log("Bad");
        }

        else if (pastAnswerTime > timeJudgeRange[4])
        {
            coefficient = timeJudgeValue[5];

            Debug.Log("miss");
            ctj.GetComponent<TextMesh>().text = "miss";
            comboCountNum = 0;

        }
        at.endTime = 0;

        if (comboCountNum == 0){
            return totalScore;
        }
        else
        {
            totalScore += baseScore * coefficient * comboCountNum;
            return totalScore;

        }
    }


}
