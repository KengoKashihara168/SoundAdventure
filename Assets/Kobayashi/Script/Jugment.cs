using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugment : MonoBehaviour
{
    [SerializeField]
    private Text[] player = new Text[4];
    //プレイヤーの今の状態を知るための変数
    string[] nowState = new string[4];
    // プレイヤーの参加人数
    [SerializeField]
    private int playerNum = 4;
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

    [SerializeField]
    private Button nextButton;
    //-----------------
    //全体の結果表示---
    [SerializeField]
    private Text playerText;

    bool itemGetFlag;
    bool goalArriveFlag;
    bool goalUnlockFlag;
    //プレイヤーナンバー
    private string playerNumText;
    //プレイヤーの今の情報を知るための変数
    string nowInformation;
    [SerializeField]
    //プレイヤーの今の状態を表示
    private Text state;
    //-----------------

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < playerNum; i++)
        {
            player[i].gameObject.SetActive(false);
            nowState[i] = "生存";
        }
        //画像とテキストを表示
        itemImage = GetComponent<Image>();
        itemImage.enabled = false;
        itemText.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        //画像とテキストを非表示
        playerText.gameObject.SetActive(false);
        state.gameObject.SetActive(false);
        //最初は生存
        itemText.GetComponent<Text>().text = "ネコ";
        nowInformation = "何も無かった";
        playerNumText = "1";
        itemGetFlag = false;
        goalArriveFlag = false;
        goalUnlockFlag = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //アイテムがあるマスに止まったら
        if (Input.GetKeyDown(KeyCode.A))
        {
            //アイテムの画像情報を取得
            ItemGet();
            ItemImageGet();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Judgment();
            //プレイヤーの情報(ナンバーを取得)
            PlayerNumGet();
            PlayerNewInformation();
        }
    }
    
    void ItemGet()
    {
        itemImage.enabled = true;
        itemText.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
    }


    //アイテムの画像情報を取得
    void ItemImageGet()
    {
        //キーを押したら画像が切り替わる
        if (Input.GetKeyDown(KeyCode.D))
        {
            itemImage.sprite = itemSprite[0];
            itemText.GetComponent<Text>().text = "ネコ";
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            itemImage.sprite = itemSprite[1];
            itemText.GetComponent<Text>().text = "ワシ";
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            itemImage.sprite = itemSprite[2];
            itemText.GetComponent<Text>().text = "キツネ";
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            itemImage.sprite = itemSprite[3];
            itemText.GetComponent<Text>().text = "ラッコ";
        }
    }

    //全体の結果を表示
    void Judgment()
    {
        //プレイヤーナンバーと状態を表示
        playerText.gameObject.SetActive(true);
        state.gameObject.SetActive(true);
        //プレイヤーナンバーを表示
        playerText.GetComponent<Text>().text = "Player" + playerNumText.ToString();
       
        //画面にプレイヤーと今の状態を表示する
        PlayerNewInformation();
        nextButton.gameObject.SetActive(true);
    }

    //プレイヤーの情報(ナンバーを取得)
    void PlayerNumGet()
    {
        //キーを押したら画像が切り替わる
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerNumText = "1";
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerNumText = "2";
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerNumText = "3";
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerNumText = "4";
        }
    }

    //プレイヤーが知った情報を表示
    void PlayerNewInformation()
    {
        //アイテムを獲得
        if (itemGetFlag == true)
        {
            nowInformation = "アイテム獲得";
        }

        //ゴールがあるマスに止まって鍵が開いていたら
        if (goalArriveFlag == true && goalUnlockFlag == true)
        {
            nowInformation = "ゴールにたどり着きました";
        } //ゴールがあるマスに止まって鍵が閉まっていたら
        else if (goalArriveFlag == true && goalUnlockFlag == false)
        {
            nowInformation = "ゴールにたどり着きました\n鍵が掛かっています";
        }

        //アイテムを獲得
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            nowInformation = "アイテム獲得";
        }

        //ゴールがあるマスに止まって鍵が開いていたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nowInformation = "ゴールにたどり着きました";
        } //ゴールがあるマスに止まって鍵が閉まっていたら
        else// if (goalArriveFlag == true && goalUnlockFlag == false)
        {
            nowInformation = "ゴールにたどり着きました\n鍵が掛かっています";
        }

        //今のプレイヤーの状態を表示
        state.GetComponent<Text>().text = nowInformation.ToString();
    }
    //プレイヤーの今の状態を表示
    void PlayerNewState()
    {
        //画像とテキストを非表示
        playerText.gameObject.SetActive(false);
        state.gameObject.SetActive(false);
        for (int i = 0; i < playerNum; i++)
        {
            nowState[i] = "生存";
            //まだ生存していたら
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                nowState[i] = "ゴール";
            }
            else
            {
                nowState[i] = "死亡";
            }

            //画面にプレイヤーと今の状態を表示する
            player[i].GetComponent<Text>().text = "Player" + (i + 1).ToString() + " " + nowState[i].ToString();
        }
    }

    //はいのボタンを押した時
    public void YesButton()
    {
        Debug.Log("クリックされた");
        itemGetFlag = true;
        //画像とテキストを非表示
        itemImage.enabled = false;
        itemText.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        Judgment();
    }

    //いいえのボタンを押した時
    public void NoButton()
    {
        Debug.Log("クリックされた");
        itemGetFlag = false;
        //画像とテキストを非表示
        itemImage.enabled = false;
        itemText.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        Judgment();
    }

    //次に行くボタンを押した時
    public void NextButton()
    {
        Debug.Log("nextクリックされた");
        //画像とテキストを非表示
        playerText.gameObject.SetActive(false);
        state.gameObject.SetActive(false);

        for (int i = 0; i < playerNum; i++)
        {
            player[i].gameObject.SetActive(true);
        }
        PlayerNewState();
    }
}
