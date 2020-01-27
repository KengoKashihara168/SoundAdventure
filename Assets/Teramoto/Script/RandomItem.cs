using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムの設定と音の設定1
public class RandomItem : MonoBehaviour
{
    int MAP_HEIGHT = 5;
    int MAP_WIDTH  = 5;

    int x, y;

    bool IsDicision;

    //リストに数値を入れる。
    List<int> posListX = new List<int>();
    //リストに数値を入れる。
    List<int> posListY = new List<int>();


    int point;
    //リストに数値を入れる。
    List<int> itemList = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        IsDicision = false;
        for(int i = 0;i < 4;i++)
        {
            itemList.Add(i);
        }

        print(itemList);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDicision)
        {
           for(int i=0;i<4;i++)
            {

                SetItem();
                point += 1;

            }

            //回した回数が4かいだったら止める
            if (point >= 4)
            {
                IsDicision = true;
            }

        }

    }

    //アイテムと音の設定
    void SetItem()
    {

        //乱数決め
        int index = UnityEngine.Random.Range(0, itemList.Count);
        //配列に乱数を入れる。
        int ransu = itemList[index];
        //要素削除
        itemList.RemoveAt(index);

        //乱数を回す
        roulette(ransu);
    }

    private void roulette(int ransu)
    {
        switch (ransu)
        {
            case 0:
                print("鍵");

                break;

            case 1:
                print("チェーンソー");

                break;

            case 2:
                print("刀");

                break;

            case 3:
                print("塩");

                break;



            default:
                print("バグです");
                break;
        }
    }
}