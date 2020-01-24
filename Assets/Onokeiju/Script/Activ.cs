using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activ : MonoBehaviour
{
    public GameObject Master;
    public GameObject MoveMain;
    [SerializeField] GameObject direction;
    [SerializeField] GameObject moveDecision;
    [SerializeField] GameObject swordDecision;
    [SerializeField] GameObject yesButton;
    [SerializeField] GameObject noButton;
    [SerializeField] Image Image;
    int nowPlayer;
    MasterScriot mas;
    GameObject[] player;
    Player[] playerscr;

    // Start is called before the first frame update
    void Start()
    {
        mas = Master.GetComponent<MasterScriot>();
        nowPlayer = mas.GetNowPlayer();
        player = mas.GetPlayer();
        playerscr = new Player[player.Length];
        for (int i=0;i<player.Length;i++)
        {
            playerscr[i] = player[i].GetComponent<Player>();
        }
        //方角ボタンだけ表示
        DirectionButtonOn();
        playerscr[1].SetDropOut(true);
    }
    
    public void MovePlay()
    {
        direction.SetActive(true);
        moveDecision.SetActive(true);
    }
    public void MoveHide()
    {
        direction.SetActive(false);
        moveDecision.SetActive(false);
    }
    public void SwordPlay()
    {
        direction.SetActive(true);
        swordDecision.SetActive(true);
    }
    public void SwordHide()
    {
        direction.SetActive(false);
        swordDecision.SetActive(false);
    }

    public void StartMove()
    {
        if (playerscr[nowPlayer].IsDropOut())
        {
            while (playerscr[nowPlayer].IsDropOut())
            {
                mas.AddNowPlayer();
                nowPlayer = mas.GetNowPlayer();
                if (nowPlayer >= 4)
                {
                   //   ゲーム終了
                }
            }
        }
    }
    
    //移動の決定ボタンを押したら
    public void MoveDecisionPush()
    {
        //移動系UIを非表示
        direction.SetActive(false);
        moveDecision.SetActive(false);
        swordDecision.SetActive(false);

        if (playerscr[nowPlayer].GetItemKind() == ItemKind.Sword)
        {
            //刀系UIを表示
            yesButton.SetActive(true);
            noButton.SetActive(true);
            Image.enabled = true;
        }
        else
        {
            mas.AddNowPlayer();
            nowPlayer = mas.GetNowPlayer();
            if (nowPlayer >= 4)
            {
                mas.ResetNowPlayer();
                SwordDecisionPush();
            }
            else
            {
                if (playerscr[nowPlayer].IsDropOut())
                {
                    while (playerscr[nowPlayer].IsDropOut())
                    {
                        mas.AddNowPlayer();
                        nowPlayer = mas.GetNowPlayer();
                        DirectionButtonOn();
                        if (nowPlayer >= 4)
                        {
                            mas.ResetNowPlayer();
                            SwordDecisionPush();
                            break;
                        }

                    }
                }
                else
                {
                    DirectionButtonOn();
                }


            }



        }
           
    }

    //プレイヤーのポジション設定
    public void MoveDecision()
    {
        playerscr[nowPlayer].MoveAction(this.gameObject.GetComponent<Move>().GetDirection());
        GameObject map = GameObject.Find(playerscr[nowPlayer].GetPotision().row + playerscr[nowPlayer].GetPotision().column);
        if (map.GetComponent<Chip>().GetItem().GetKind() != ItemKind.None)
        {
            playerscr[nowPlayer].SetFoot(true);
        }
    }

    //刀の決定ボタンを押したら
    public void SwordDecisionPush()
    {
        //全て非表示
        direction.SetActive(false);
        moveDecision.SetActive(false);
        swordDecision.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        Image.enabled = false;
    }

    //はいのボタン
    public void YesPush()
    {
        //方角を表示
        direction.SetActive(true);
    }
    //いいえのボタン
    public void NoPush()
    {
        //全て非表示
        direction.SetActive(false);
        moveDecision.SetActive(false);
        swordDecision.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        Image.enabled = false;
    }
    //方角のボタンを押したら
    public void DirectiomPush()
    {
        //刀の画像が表示されたら(2つの決定ボタンを分けるため)
        if (Image.enabled == false)
        {
            //移動の決定ボタンを表示
            moveDecision.SetActive(true);
        }
        else
        {
            //刀の決定ボタンを表示
            swordDecision.SetActive(true);
        }
    }
    private void DirectionButtonOn()
    {
        //方角ボタンだけ表示
        direction.SetActive(true);
        moveDecision.SetActive(false);
        swordDecision.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        Image.enabled = false;
    }
}