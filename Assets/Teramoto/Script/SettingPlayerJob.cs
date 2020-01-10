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

    public AudioSource[] audio;
    // Start is called before the first frame update
    void Start()
    {

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
        //MapControl.Instance.SetAudio(15, audio[5]);
        //もしそのひとが青年なら青年の画像を表示
        if (IsYouth)
        {
            //表示を凝る

            //画像の表示
            youthImage.SetActive(true);
            IsDecisionPost = true;
        }

        //もしそのひとが憑人なら憑人の画像を表示
        if (IsScold)
        {
            
            //画像の表示
            IsDecisionPost = true;
            scoldImage.SetActive(true);
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
            //SceneManager.LoadScene("");

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
                print("値がおかしいです");
                break;
            default:
                print("値がおかしいです");
                break;
        }
    }

    //青年用
    private void RoleYouth()
    {
        // print("青年です");
        IsYouth = true;
        IsScold = false;
    }
    //憑人用
    private void RoleScold()
    {
        //  print("憑人です");
        IsScold = true;
        IsYouth = false;
    }
}
