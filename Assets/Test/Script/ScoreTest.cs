using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //テキスト使うなら必要
using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    int comboCountNum;
    const float baseScore = 1.0f;
    float totalScore = 0.0f;
    /// <summary>
    /// 成功したか失敗したかを、ゲームを管理するクラスからこいつへ教えてあげる
    /// </summary>
    /// <param name="success"></param>
    /// 

        public void AddResult(bool success)
        {
            if (success)
            {
                comboCountNum++;
                Debug.Log(GetScore());
            }
            else
            {
                comboCountNum = 0;

            }
            Debug.Log(comboCountNum + "コンボ");
            Debug.Log("スコア"+GetScore());

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
