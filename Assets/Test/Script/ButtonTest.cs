using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonTest : MonoBehaviour
{

    GameObject TapButton;
    GameObject ReleaseButton;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


    }
    //ボタンを押した時の処理
    public void Click(string button)
    {


        if (button == "Left")
        {
            Debug.Log("左！");

            //右を押した状態とキャラの向きがあってるか

        }
        else if (button == "Right")
        {
            Debug.Log("右！");

        }
    }
    
}
