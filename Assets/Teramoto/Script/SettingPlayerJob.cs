using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// プレイヤーに役職を設定するクラス
/// </summary>


public class SettingPlayerJob : MonoBehaviour
{
    [SerializeField]
    private Player player; 

    //ボタンのオブジェの取得
    [SerializeField]
    private GameObject buttonObj;

    //ボタンクリックスクリプト
    ClickButton script;

    //リストに数値を入れる。
    int num;

    //押されたか判別するフラグ
    bool ISClickButtonFlag;

    //青年かのフラグ
    bool IsYouth;

    //決定したかのFlag
    bool IsDecision;


    // Start is called before the first frame update
    void Start()
    {
        IsYouth = true;
        buttonObj.SetActive(true);
        script = buttonObj.GetComponent<ClickButton>();
        ISClickButtonFlag = false;
        IsDecision = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Playerがいるかの確認
            
        //憑人のflagがfalse
        if (!player.IsHaunted())
        {
            //青年
            IsDecision = true;
            IsYouth = true;
        }

        //憑人のflagがtrue
        if (player.IsHaunted())
        {
            //憑人
            IsYouth = false;
            IsDecision = true;
        }


        if (IsDecision)
        {
            //ボタンを表示させる
            buttonObj.SetActive(true);
        }

        //役職表示後ボタン表示されボタンを押されたときの処理
        if (script.GetClickButton())
        {
            //Scene移動をさせる。
            //SceneManager.LoadScene("Sound");

        }

        
    }

    public bool GetYouth()
    {
        return IsYouth;
    }
}
