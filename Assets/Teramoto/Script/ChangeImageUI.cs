using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeImageUI : MonoBehaviour
{

    public Sprite SetImage0;
    public Sprite SetImage1;
    public Sprite SetImage2;
    SpriteRenderer MainSpriteRenderer;
    //子供の画像
    public Image ImageUIChild;
    //ボタンクリックスクリプト
    ClickSettingPlayerButton csbpScript;

    //ボタンのオブジェの取得
    [SerializeField]
    private GameObject buttonObj;

    private bool IsDecision;

    // Start is called before the first frame update
    void Start()
    {
        // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //スクリプトの呼び出し
        csbpScript = buttonObj.GetComponent<ClickSettingPlayerButton>();
        IsDecision = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsDecision)
        {
            return;
        }
        if(!IsDecision)
        {
            if (csbpScript.GetClickButton())
            {
                IsDecision = true;

                //乱数を回す
                int index = UnityEngine.Random.Range(0, 3);

                //配列に乱数を入れる。
                int ransu = index;

                //プレイヤーの情報を取得
                //乱数を回す
                roulette(ransu);

            }


        }
    }

    void roulette(int rand)
    {
        switch (rand)
        {
            case 0:
                //画像のSet
                MainSpriteRenderer.sprite = SetImage0;
                ImageUIChild.sprite = MainSpriteRenderer.sprite;

                break;

            case 1:
                //画像のSet
                MainSpriteRenderer.sprite = SetImage1;

                ImageUIChild.sprite = MainSpriteRenderer.sprite;

                break;
            case 2:
                //画像のSet
                MainSpriteRenderer.sprite = SetImage2;

                ImageUIChild.sprite = MainSpriteRenderer.sprite;

                break;

            default:
                print("値がおかしいです");
                break;
        }
    }

}
