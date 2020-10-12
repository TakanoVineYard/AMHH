using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ResultTest;

public class CharacterTest : MonoBehaviour
{
    Animator CharaAnimator;　//アニメーター用変数
    Animator ResultAnimator;　//アニメーター用変数
    bool QuestionStatus = false; //出題状態かどうか
    GameObject resultObj;　　//ゲームオブジェクトResultを入れる用


    void Start()
    {
        CharaAnimator = GetComponent<Animator>();　//このオブジェクトからアニメーターを取得

        resultObj = GameObject.Find("Result");  //シーン内からResultゲームオブジェクトを探してくる

        ResultAnimator = resultObj.GetComponent<Animator>();　//シーンからアニメーターを取得


    }

    private float span = 3.0f;  //スパン
    private float elapsedTime;  //合計経過時間
    private float currentTime = 0.0f;　  //現在の時間

    void Update()
    {
        if (CharaAnimator.GetBool("BackToIdle") == true)//待機戻りがオンだったら
        {
            CharaAnimator.SetBool("BackToIdle", false);  //オフにする
        }

        currentTime += Time.deltaTime;  //経過時間を加える

        if (currentTime > span)  //経過時間がスパンより大きくなったら実行
        {
            elapsedTime += currentTime;  //合計経過時間に累積

            currentTime = 0f;　  //現在の時間をリセット

            //もし出題状態じゃなかったら実行
            if(QuestionStatus == false)
            {
                MoveSelect(); //方向を選ぶ関数

            }
            //もし出題状態だったら実行

            else if (QuestionStatus == true)
            {

            }

        }
    }

    public void JudgeL()   //外から左ボタンが押されたときに実行
    {
        
        if (QuestionStatus == false) //出題状態じゃない限り、何も実行しないで戻る
        {
            Debug.Log("りたーん");
            return;
        }

        if (CharaAnimator.GetBool("Left") == true)
        {
            Debug.Log("左！あたり！");
            ResultAnimator.SetBool("Correct", true);
        }
        else if (CharaAnimator.GetBool("Left") == false)
        {
            Debug.Log("左じゃないよハズレだよ！！");
            ResultAnimator.SetBool("Incorrect", true);

        }

        Invoke("MoveReset", 0.5f); //しばらくしたら出題状態をやめて、アニメーターの状態をIdleに戻す。
    }

    public void JudgeR()   //外から右ボタンが押されたときに実行
    {
        if (QuestionStatus == false) //出題状態じゃない限り、何も実行しないで戻る
        {
            Debug.Log("りたーん");
        return;
        }

        if (CharaAnimator.GetBool("Right") == true)
        {
            Debug.Log("右！あたり！");
            ResultAnimator.SetBool("Correct", true);
        }
        else if (CharaAnimator.GetBool("Right") == false)
        {
            Debug.Log("右じゃないよハズレだよ！！");

            ResultAnimator.SetBool("Incorrect", true);
        }

        Invoke("MoveReset", 0.5f); //しばらくしたら出題状態をやめて、アニメーターの状態をIdleに戻す。

    }

    private void MoveReset() //出題状態をやめて、アニメーターの状態をIdleに戻す。
    {

        Debug.Log("MoveReset");
        CharaAnimator.SetBool("Left", false);  //左トリガーをオフ
        CharaAnimator.SetBool("Right", false);  //右トリガーをオフ
        CharaAnimator.SetBool("BackToIdle", true);  //待機に戻るトリガーを実行

        ResultAnimator.SetBool("Correct", false);
        ResultAnimator.SetBool("Incorrect", false);

        QuestionStatus = false;


    }


    private void MoveSelect() //キャラの方向を選ぶ関数
    {

        QuestionStatus = true; //出題状態にする

        //Debug.LogFormat(elapsedTime + "秒経過");

        switch (Random.Range(0, 10) % 2)　//ランダムのあまりの数値で分岐。2で割ったあまりだから0か1
        {

            case 0:

                //Debug.Log("0");

                CharaAnimator.SetBool("Left",true);  //左トリガーを実行

                break;

            case 1:
                //Debug.Log("1");

                CharaAnimator.SetBool("Right", true);  //右トリガーを実行

                break;
        }

    }
}
