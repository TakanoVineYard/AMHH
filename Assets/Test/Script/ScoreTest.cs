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


    }


    public void Update()
    {


    }

    public void AddResult(bool success)
        {
            if (success)
            {
                comboCountNum++;
               // Debug.Log(GetScore());
            }
            else
            {
                comboCountNum = 0;

            }
        comboText.text = comboCountNum.ToString() + "コンボ";
        scoreText.text = "スコア:" + GetScore();

        //Debug.Log(comboCountNum + "コンボ");
        //Debug.Log("スコア"+GetScore());

    }
    /// <summary>
    /// 現状でのスコアをゲッツ
    /// </summary>
    /// <returns>コンボによる倍率をかけた値を返す</returns>
    public float GetScore()
    {
        totalScore += baseScore * comboCountNum;
        return totalScore;

    }

}
