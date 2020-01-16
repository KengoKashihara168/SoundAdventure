using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// プレイヤーに役職を設定するクラス
/// </summary>


public class SettingPlayerJob : MonoBehaviour
{
    [SerializeField]
    private Player player; 

    //ボタンクリックスクリプト
    ClickSettingPlayerButton csbpScript;

    //ボタンのオブジェの取得
    [SerializeField]
    private GameObject buttonObj;

    //ボタンのオブジェの取得
    [SerializeField]
    private GameObject buttonObj2;

    //ボタンクリックスクリプト
    ClickButton cbScript;

    //青年のイメージ
    [SerializeField]
    private GameObject youthImage;

    //憑人イメージ
    [SerializeField]
    private GameObject scoldImage;

    //リストに数値を入れる。
    int num;

    //押されたか判別するフラグ
    bool ISClickButtonFlag;

    //青年かのフラグ
    bool IsYouth;
    //憑人かのフラグ
    bool IsScold;

    //決定したかのFlag
    bool IsDecision;
    //役職が決まったかのFlag
    bool IsDecisionPost;

    // Start is called before the first frame update
    void Start()
    {

        youthImage.SetActive(false);
        scoldImage.SetActive(false);
        buttonObj.SetActive(true);
        buttonObj2.SetActive(false);
        csbpScript = buttonObj.GetComponent<ClickSettingPlayerButton>();
        cbScript = buttonObj2.GetComponent<ClickButton>();
        ISClickButtonFlag = false;
        IsDecision = false;
        IsDecisionPost = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (csbpScript.GetClickButton())
        {
            buttonObj.SetActive(false);

            ISClickButtonFlag = true;
        }

        if (!IsDecision)
        {
            if (ISClickButtonFlag)
            {
                IsDecision = true;
                //乱数決め
                int index = UnityEngine.Random.Range(0, 2);

                //配列に乱数を入れる。
                int ransu = index;

                //プレイヤーの情報を取得
                //乱数を回す
                roulette(ransu);
                //ボタンクリックさせたときのFlagをOnにする。
                ISClickButtonFlag = false;

            }
        }

        if(IsDecision)
        {

            //憑人のflagがfalse
            if (!player.IsHaunted())
            {
                //青年

                youthImage.SetActive(true);
                scoldImage.SetActive(false);
                IsDecisionPost = true;
               // print("青年");
            }
            //憑人のflagがtrue
            if (player.IsHaunted())
            {
                //憑人
                youthImage.SetActive(false);

                scoldImage.SetActive(true);
                IsDecisionPost = true;
               // print("憑人");
            }
        }


        if (IsDecisionPost)
        {
            //ボタンを表示させる
            buttonObj2.SetActive(true);
        }

        //役職表示後ボタン表示されそれを押されたときの処理
        if (cbScript.GetClickButton())
        {
            //Scene移動をさせる。
            //SceneManager.LoadScene("Sound");

        }
    }

    void roulette(int rand)
    {
        switch (rand)
        {
            case 0:
                //プレイヤーを青年に変更
                RoleYouth();
                break;

            case 1:
                //プレイヤーを憑人に変更
                RoleScold();
                break;
            case 2:
               // print("値がおかしいです");
                break;
            default:
             //   print("値がおかしいです");
                break;
        }
    }

    //青年用
    private void RoleYouth()
    {
        if(IsDecision)
        {
            IsYouth = true;
            IsScold = false;
        }
    }

    //憑人用
    private void RoleScold()
    {
       IsYouth = false;
       IsScold = true;

    }
}
