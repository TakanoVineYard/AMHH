using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキスト使うなら必要？
using static CountDownTimerTest;



public class TimerTest : MonoBehaviour
{

    private static int minute; //分
    private static float seconds;　//秒
    private static float oldSeconds; //前のUpdateのときの秒数
    
    private Text CountTimer; //経過時間用
    

// Start is called before the first frame update
void Start()
    {
        minute = 0;
        seconds = 0;
        oldSeconds = 0;
        CountTimer = GetComponentInChildren<Text>(); //ゲーム時間用Textコンポーネント拾ってくるぜ
        CountTimer.enabled = false;

    }


    // Update is called once per frame
    void Update()
    {



        if (GameStart == true)
        {
            if (CountTimer.enabled == false)
            {
                CountTimer.enabled = true;  //カウントの表示

            }

            seconds += Time.deltaTime;

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
