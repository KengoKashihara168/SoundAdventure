using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ゴールなどの位置設定
/// </summary>


public class SettingAllLocation : MonoBehaviour
{
    int MAP_HEIGHT = 5;
    int MAP_WIDTH = 5;

    int x, y;

    bool IsDicision;
    //ボタンのオブジェの取得
    [SerializeField]
    private GameObject buttonObj2;

    //ボタンクリックスクリプト
    ClickButton cbScript;

    //リストに数値を入れる。
    List<int> posListX = new List<int>();
    //リストに数値を入れる。
    List<int> posListY = new List<int>();

    // Start is called before the first frame update
    void Start()
    {

        cbScript = buttonObj2.GetComponent<ClickButton>();
        IsDicision = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(!IsDicision)
        {
            if (cbScript.GetClickButton())
            {
                //Playerの場所決め
                SetPlayerPos();

                //ゴールの場所決め
                SetGoalPos();
                //八尺の場所決め
                SetHasshakkuPos();

                //決定FlagをOn
                IsDicision = true;
            }

        }
    }



    //Playerの設定
    void SetPlayerPos()
    {
        //w,hにランダム数を代入する
        int w = Random.Range(0, MAP_WIDTH);
        int h = Random.Range(0, MAP_HEIGHT);

            for (int j = 0; j < posListX.Count; j++)
            {
                if (w == posListX[j] && h == posListY[j])
                {
                    w = Random.Range(0, MAP_WIDTH);
                    h = Random.Range(0, MAP_HEIGHT);
                    j = -1;
                    continue;
                }
            }

        x = w;
        y = h;
      
        Control.Instance.SetPosition(0, x + y * 5);// a posListX.Add(w);
        posListY.Add(h);
        print("Playerの場所は" + ((w + (h * 5)) + 1));
    }


    void SetGoalPos()
    {
        //w,hにランダム数を代入する
        int w = Random.Range(0, MAP_WIDTH);
        int h = Random.Range(0, MAP_HEIGHT);


        for (int i = 0; i < posListX.Count; i++)
        {
            if (w == posListX[i] && h == posListY[i])
            {
                w = Random.Range(0, MAP_WIDTH);
                h = Random.Range(0, MAP_HEIGHT);
                i = -1;
                continue;
            }
        }
        x = w;
        y = h;
        posListX.Add(w);
        posListY.Add(h);
        print("Goalの場所は" + ((w + (h * 5)) + 1));
    }
    void SetHasshakkuPos()
    {
        //w,hにランダム数を代入する
        int w = Random.Range(0, MAP_WIDTH);
        int h = Random.Range(0, MAP_HEIGHT);


        for (int i = 0; i < posListX.Count; i++)
        {
            if (w == posListX[i] && h == posListY[i])
            {
                w = Random.Range(0, MAP_WIDTH);
                h = Random.Range(0, MAP_HEIGHT);
                i = -1;
                continue;
            }
        }
        x = w;
        y = h;
        posListX.Add(w);
        posListY.Add(h);
        print("八尺の場所は" + ((w + (h * 5)) + 1));
    }

}
