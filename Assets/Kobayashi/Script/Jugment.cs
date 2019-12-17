using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugment : MonoBehaviour
{
    //アイテムの獲得---
    //画像の表示
    [SerializeField]
    private Image itemImage;
    //テキストの表示(アイテム名)
    [SerializeField]
    private Text itemText;
    //テキストの表示(拾いますか？)
    [SerializeField]
    private Text text;
    //ボタンの表示
    [SerializeField]
    private Button yesButton;
    [SerializeField]
    private Button noButton;
    //-----------------
    //全体の結果表示---
    [SerializeField]
    private Text playerNumText;

    //プレイヤーの今の状態を知るための変数
    string nowState;
    [SerializeField]
    private Text state;

    //-----------------

    // Use this for initialization
    void Start()
    {
        //画像とテキストを表示
        itemImage.gameObject.SetActive(true);
        itemText.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
        //画像とテキストを非表示
        playerNumText.gameObject.SetActive(false);
        state.gameObject.SetActive(false);
        nowState = "生存";
    }

    // Update is called once per frame
    void Update()
    {
        //// 左クリックが押された時
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //画像とテキストを非表示
        //    itemImage.gameObject.SetActive(false);
        //    itemText.gameObject.SetActive(false);
        //    text.gameObject.SetActive(false);
        //    yesButton.gameObject.SetActive(false);
        //    noButton.gameObject.SetActive(false);
        //    Judgment();
        //}
    }

    void Judgment()
    {
        playerNumText.gameObject.SetActive(true);
        state.gameObject.SetActive(true);
        //画面にプレイヤーと今の状態を表示する
        playerNumText.GetComponent<Text>().text = "Player1";
        state.GetComponent<Text>().text = nowState.ToString();
    }

    public void YesButton()
    {
        Debug.Log("クリックされた");
        //画像とテキストを非表示
        itemImage.gameObject.SetActive(false);
        itemText.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        Judgment();
    }
    public void NoButton()
    {
        Debug.Log("クリックされた");
        //画像とテキストを非表示
        itemImage.gameObject.SetActive(false);
        itemText.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        Judgment();
    }
}
