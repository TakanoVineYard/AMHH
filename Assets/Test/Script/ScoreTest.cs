using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //テキスト使うなら必要
using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    int comboCountNum = 0;
    const float baseScore = 10.0f;
    public float totalScore = 0.0f;

    public Text comboText;
    public Text scoreText;

    public float[] timeJudgeRange = new float[5]; //回答までの時間区分け
    public float[] timeJudgeValue = new float[5];　//回答までの時間による係数

    public CharacterTest at;

    public bool successResult;
    /// <summary>
    /// 成功したか失敗したかを、ゲームを管理するクラスからこいつへ教えてあげる
    /// </summary>
    /// <param name="success"></param>
    /// 

    void Start()
    {
        GameObject comboTextObj = GameObject.Find("comboCount");
        GameObject scoreTextObj = GameObject.Find("score");

        comboText = comboTextObj.GetComponentInChildren<Text>();
        scoreText = scoreTextObj.GetComponentInChildren<Text>();

        Debug.Log(comboText);
        Debug.Log(scoreText);

        at = GameObject.Find("CharacterAll").GetComponent<CharacterTest>();
        

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
            else if (answerTimeRange > timeJudgeRange[0])  //5秒以上かかっててもだめ
            {
            comboCountNum = 0;

            }
            else
            {
                comboCountNum = 0;

            }

        comboText.text = comboCountNum.ToString() + "コンボ";
        scoreText.text = "スコア:" + GetScore(answerTimeRange);

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
        }
       else if ((pastAnswerTime > timeJudgeRange[0]) && (pastAnswerTime <= timeJudgeRange[1]) && (successResult))
        {
            coefficient = timeJudgeValue[1];
            Debug.Log("Good" + timeJudgeValue[1]);
        }
        else if ((pastAnswerTime > timeJudgeRange[1]) && (pastAnswerTime <= timeJudgeRange[2]) && (successResult))
        {
            coefficient = timeJudgeValue[2];
            Debug.Log("better" + timeJudgeValue[2]);
        }
        else if ((pastAnswerTime > timeJudgeRange[2]) && (pastAnswerTime <= timeJudgeRange[3]) && (successResult))
        {
            coefficient = timeJudgeValue[3];
            Debug.Log("Bad");
        }
       else if (pastAnswerTime > timeJudgeRange[4])
        {
            coefficient = timeJudgeValue[4];

            Debug.Log("miss");

        }

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
