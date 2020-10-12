using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultTest : MonoBehaviour
{

    Animator ResultAnimator;


    // Start is called before the first frame update
    void Start()
    {
        ResultAnimator = GetComponent<Animator>(); //このオブジェクトからアニメーターを取得

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ResultCorrectt()
    {
        ResultAnimator.SetBool("Correct", true);  //正解
        Debug.Log("正解");

    }

    public void ResultIorrect()
    {
        ResultAnimator.SetBool("Incorrect", true);  //不正解
        Debug.Log("不正解");

    }

    public void ResultReset()
    {
        ResultAnimator.SetBool("Correct", false);  //不正解
        ResultAnimator.SetBool("Incorrect", false);  //不正解




    }

}
