using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activ : MonoBehaviour
{
    public GameObject Master;
    public GameObject MoveMain;
    [SerializeField] ColorChange colorChange;
    [SerializeField] GameObject direction;
    [SerializeField] GameObject moveDecision;
    [SerializeField] GameObject swordDecision;
    [SerializeField] GameObject yesButton;
    [SerializeField] GameObject noButton;
    [SerializeField] Image Image;
    [SerializeField] GameScene gameScene;
    [SerializeField] GameObject audioUI;
    [SerializeField] Aggregate aggregate;
    int nowPlayer;
    MasterScriot mas;
    GameObject[] player;
    Player[] playerscr;
    bool isMove;
    bool isItem;

    // Start is called before the first frame update
    void Start()
    {
        isMove = false;
        isItem = false;
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
       // playerscr[2].SetDead(true);
       // playerscr[2].SetDropOut(true);

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
        nowPlayer = mas.GetNowPlayer();
        if (!isMove)
        {

            //移動系UIを非表示
            direction.SetActive(false);
            moveDecision.SetActive(false);
            swordDecision.SetActive(false);
            if(!isItem)
            {
                mas.AddNowPlayer();
                nowPlayer = mas.GetNowPlayer();
                if (nowPlayer >= 4 && !isItem)
                {
                    mas.ResetNowPlayer();
                    SwordDecisionPush();
                    aggregate.AggregateON();
                    audioUI.SetActive(false);
                    gameScene.DeadPlayer();
                    gameScene.OnScreenButton(ScreenType.Private);
                }
                else
                {
                    colorChange.Color(playerscr[nowPlayer].GetPotision());
                    if (playerscr[nowPlayer].IsDropOut())
                    {
                        while (playerscr[nowPlayer].IsDropOut())
                        {
                            mas.AddNowPlayer();
                            nowPlayer = mas.GetNowPlayer();

                            if (nowPlayer >= 4 && !isItem)
                            {
                                mas.ResetNowPlayer();
                                SwordDecisionPush();
                                aggregate.AggregateON();
                                audioUI.SetActive(false);
                                gameScene.DeadPlayer();
                                gameScene.OnScreenButton(ScreenType.Private);
                                break;
                            }
                        }
                        DirectionButtonOn();
                    }
                    else
                    {
                        DirectionButtonOn();
                    }
                }
            }
            
            //    if (playerscr[nowPlayer].GetItemKind() == ItemKind.Sword)
            //    {
            //        //刀系UIを表示
            //        yesButton.SetActive(true);
            //        noButton.SetActive(true);
            //        Image.enabled = true;
            //    }
            //    else
            //    {
            //        mas.AddNowPlayer();
            //        nowPlayer = mas.GetNowPlayer();
            //        if (nowPlayer >= 4)
            //        {         
            //            mas.ResetNowPlayer();
            //            SwordDecisionPush();
            //            aggregate.AggregateON();
            //            audioUI.SetActive(false);
            //            gameScene.DeadPlayer();
            //            gameScene.OnScreenButton(ScreenType.Private);
            //        }
            //        else
            //        {
            //            if (playerscr[nowPlayer].IsDropOut())
            //            {
            //                while (playerscr[nowPlayer].IsDropOut())
            //                {
            //                    mas.AddNowPlayer();
            //                    nowPlayer = mas.GetNowPlayer();
            //                    DirectionButtonOn();
            //                    if (nowPlayer >= 4)
            //                    {
            //                        mas.ResetNowPlayer();
            //                        SwordDecisionPush();
            //                        aggregate.AggregateON();
            //                        audioUI.SetActive(false);
            //                        gameScene.DeadPlayer();
            //                        gameScene.OnScreenButton(ScreenType.Private);
            //                        break;
            //                    }

            //                }
            //            }
            //            else
            //            {
            //                DirectionButtonOn();
            //            }
            //        }
            //    }
            //}   
        }
    }

    //プレイヤーのポジション設定
    public void MoveDecision()
    {
        nowPlayer = mas.GetNowPlayer();
        string pPos = playerscr[nowPlayer].GetPotision().row + playerscr[nowPlayer].GetPotision().column;
        playerscr[nowPlayer].MoveAction(this.gameObject.GetComponent<Move>().GetDirection());
        if (pPos == playerscr[nowPlayer].GetPotision().row + playerscr[nowPlayer].GetPotision().column)
        {
            isMove = true;
        }
      else
        {
            GameObject chip = GameObject.Find(playerscr[nowPlayer].GetPotision().row + playerscr[nowPlayer].GetPotision().column);
            if (chip.GetComponent<Chip>().GetItem().GetKind() != ItemKind.None)
            {
                if(chip.GetComponent<Chip>().GetItem().GetKind()== ItemKind.Sword)
                {
                    playerscr[nowPlayer].SetFoot(true);
                    isItem = false;
                }
                else
                {
                    playerscr[nowPlayer].SetFoot(true);
                    yesButton.SetActive(true);
                    noButton.SetActive(true);
                    Image.enabled = true;
                    isItem = true;
                }

            }
            isMove = false;
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
        isItem = false;
        MoveDecisionPush();
    }
    //いいえのボタン
    public void NoPush()
    {
        playerscr[nowPlayer].SetFoot(false);
        isItem = false;
        MoveDecisionPush();
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
    public void DirectionButtonOn()
    {
        nowPlayer = mas.GetNowPlayer();
        colorChange.ColorReset();
        if (player[nowPlayer].GetComponent<Player>().IsDropOut())
        {
            mas.AddNowPlayer();
            DirectionButtonOn();
        }
        else
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
}