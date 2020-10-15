using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキスト使うなら必要？
using static CountDownTimerTest;



public class TimerTest : MonoBehaviour
{

    private static int minute = 0; //分
    private static float seconds = 0;　//秒
    private static float oldSeconds = 0; //前のUpdateのときの秒数


    public static float getDeltaTime = 0; //時間経過取得の大元

    private Text CountTimer; //経過時間用

    public  AudioClip soundGameStart;
    //public  AudioClip soundGameBGM;

    AudioSource GameAudioSource; //ゲームBGM

    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 0;
        oldSeconds = 0;
        CountTimer = GetComponentInChildren<Text>(); //ゲーム時間用Textコンポーネント拾ってくるぜ
        CountTimer.enabled = false;
        GameAudioSource = GetComponent<AudioSource>(); //オーディオソースを引っ張る

    }


    // Update is called once per frame
    void Update()
    {

        getDeltaTime = Time.deltaTime;
        //Debug.Log("経過時間(TimerTest)→"+ getDeltaTime);

        if (GameStart == true)
        {
            if (CountTimer.enabled == false)
            {
                CountTimer.enabled = true;  //カウントの表示
                //GameAudioSource.PlayOneShot(soundGameBGM); //音再生
                GameAudioSource.PlayOneShot(soundGameStart); //音再生

            }

            seconds += getDeltaTime;

         //↓60秒で1分にリセット
            if (seconds >= 60)
            {
                minute++;
                seconds = seconds - 60;
            }
            //↓もし秒の数値が前回の秒数と違ったら(時間が経過してたら)テキストを更新
            if ((int)seconds != (int)oldSeconds)
            {
                CountTimer.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
            }

            oldSeconds = seconds; //経過時間として現在の時間を上書く

        }
    }


    public static void GameStartTrigger()
    {
        minute = 0;
        seconds = 0;
        oldSeconds = 0;
        GameStart = true;
    }

}
