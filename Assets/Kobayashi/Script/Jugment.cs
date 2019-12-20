using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Jugment : MonoBehaviour
{
    //アイテムの獲得---
    //画像の表示
    private Image itemImage;
    [SerializeField]
    private Sprite[] itemSprite;
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
    private Text playerText;
    //プレイヤーナンバー
    private string playerNum;
    //プレイヤーの今の状態を知るための変数
    string nowState;
    [SerializeField]
    //プレイヤーの今の状態を表示
    private Text state;
    [SerializeField]
    //Scene用ボタン
    private Button button;
    //-----------------


    // Use this for initialization
    void Start()
    {
        //画像とテキストを表示
        itemImage = GetComponent<Image>();
        itemImage.gameObject.SetActive(true);
        itemText.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
        //画像とテキストを非表示
        playerText.gameObject.SetActive(false);
        state.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        //最初は生存
        nowState = "生存";
        playerNum = "1";
    }

    // Update is called once per frame
    void Update()
    {
        //アイテムの画像情報を取得
        ItemImageGet();
        //プレイヤーの情報(ナンバーを取得)
        PlayerNumGet();
        //画面にプレイヤーと今の状態を表示する
        PlayerNewState();
    }

    //全体の結果を表示
    void Judgment()
    {
        //プレイヤーナンバーと状態を表示
        playerText.gameObject.SetActive(true);
        state.gameObject.SetActive(true);
        //プレイヤーナンバーを表示
        playerText.GetComponent<Text>().text = "Player" + playerNum.ToString();
        //今のプレイヤーの状態を表示
        state.GetComponent<Text>().text = nowState.ToString();
    }

    //アイテムの画像情報を取得
    void ItemImageGet()
    {
        //キーを押したら画像が切り替わる
        if (Input.GetKeyDown(KeyCode.D))
        {
            itemImage.sprite = itemSprite[0];
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            itemImage.sprite = itemSprite[1];
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            itemImage.sprite = itemSprite[2];
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            itemImage.sprite = itemSprite[3];
        }
    }

    //プレイヤーの情報(ナンバーを取得)
    void PlayerNumGet()
    {
        //キーを押したら画像が切り替わる
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerNum = "1";
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerNum = "2";
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerNum = "3";
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerNum = "4";
        }
    }

    //画面にプレイヤーと今の状態を表示する
    void PlayerNewState()
    {
        //プレイヤーがゴールしたら
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            nowState = "ゴール";
        }
        else
        {
            ////まだ生存していたら
            //if (Input.GetKeyDown(KeyCode.DownArrow))
            //{
            //    nowState = "生存";
            //}
            //else if (Input.GetKeyDown(KeyCode.LeftArrow))
            //{
            //    nowState = "死亡";
            //}
        }
        //まだ生存していたら
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            nowState = "生存";
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            nowState = "死亡";
        }
    }

    //はいのボタンを押した時
    public void YesButton()
    {
        Debug.Log("クリックされた");
        //画像とテキストを非表示
        itemImage.gameObject.SetActive(false);
        itemText.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        button.gameObject.SetActive(true);
        Judgment();
    }

    //いいえのボタンを押した時
    public void NoButton()
    {
        Debug.Log("クリックされた");
        //画像とテキストを非表示
        itemImage.gameObject.SetActive(false);
        itemText.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        button.gameObject.SetActive(true);
        Judgment();
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("Sound");
    }
}
