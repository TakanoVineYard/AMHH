using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキスト使うなら必要？
using static TimerTest;
using static SoundTest;

public class CountDownTimerTest : MonoBehaviour
{
    private float seconds;　//秒

    private int CountDownMin = 3; //カウントダウン整数
    private float CountDownSpan = 1.0f; //カウントダウンの秒スパン

    private Text CountDownTimer; //カウントダウン数値をいれるテキスト

    static public bool GameStart = false;

     


    // Start is called before the first frame update
    void Start()
    {
        //GameAudioSource.PlayOneShot(soundCountDown);
        seconds = 0;
        CountDownTimer = GetComponentInChildren<Text>(); //カウントダウン用Textコンポーネント拾ってくるぜ  
    }

    // Update is called once per frame
    void Update()
    {

        if (GameStart == false)
        {

            seconds += Time.deltaTime;

            //1秒でリセット

            if (seconds > CountDownSpan)
            {
                Debug.Log(CountDownSpan+"秒たった");
                CountDownMin -= 1;
                seconds = 0; 

            }

            //↓もし秒の数値が前回の秒数と違ったら(時間が経過してたら)テキストを更新
            //if ((int)seconds != (int)oldSeconds)
            //{
                CountDownTimer.text = CountDownMin.ToString();

            //}

            if (CountDownMin <= 0)
            {
                CountDownTimer.text = "Start！";
                
                GameStartTrigger();
                Invoke("OffActiveStartText", 1); //一秒たったら消す
            }

        }
    }

    void OffActiveStartText()
    {
        CountDownTimer.enabled = false;
        //this.gameObject.SetActive (false);

    }
}
