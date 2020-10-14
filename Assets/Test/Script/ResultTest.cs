using UnityEngine;

public class ResultTest : MonoBehaviour
{

    Animator ResultAnimator;


    int comboCorrectVal = 0;  //コンボ数
    float scoreRank = 1.0f; //　スコア

    public int comboGradeUpA = 5;  //このコンボ以上で、スコア計算値を上げる
    public int comboGradeUpB = 10;
    public int comboGradeUpC = 15;


    float totalScore = 0f; //トータルスコア 


    // Start is called before the first frame update
    void Start()
    {
        ResultAnimator = GetComponent<Animator>(); //このオブジェクトからアニメーターを取得

    }

    // Update is called once per frame
     void Update()
    {



     void ResultCorrect()
        {
            ResultAnimator.SetBool("Correct", true);  //正解
            Debug.Log("正解");

            comboCorrectVal += 1;

            float addScore = 0f;

            if ((comboCorrectVal <= comboGradeUpA))
            {
                addScore = 1.0f;
            }
            else if ((comboCorrectVal > comboGradeUpA) && (comboCorrectVal <= comboGradeUpB))
            {
                addScore = 1.25f;
            }
            else if ((comboCorrectVal > comboGradeUpB) && (comboCorrectVal <= comboGradeUpC))
            {
                addScore = 1.5f;
            }
            else if (comboCorrectVal > comboGradeUpC)
            {
                addScore = 2f;
            }
            scoreRank = comboCorrectVal * addScore;

            totalScore += scoreRank;

            ResultReset();

        }

         void ResultInCorrect()
        {
            ResultAnimator.SetBool("Incorrect", true);  //不正解
            Debug.Log("不正解");
            comboCorrectVal = 0;
            ResultReset();
        }

         void ResultReset()
        {
            ResultAnimator.SetBool("Correct", false);  //
            ResultAnimator.SetBool("Incorrect", false);  //

            Debug.Log(comboCorrectVal+ "コンボ");
            Debug.Log("合計スコア"+(int)totalScore);


        }

    }
}

