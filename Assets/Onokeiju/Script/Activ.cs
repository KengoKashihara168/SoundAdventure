﻿using System.Collections;
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
    [SerializeField] GameObject nextMoveUI;
    [SerializeField] Aggregate aggregate;
    [SerializeField] Sprite[] itemImages;
    [SerializeField] GameObject[] nextUI;
    [SerializeField] Text playerName;
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
        for(int i=0;i<nextUI.Length;i++)
        {
            nextUI[i].SetActive(false);
        }
        //方角ボタンだけ表示
        SwordDecisionPush();
       //DirectionButtonOn();
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

    public bool StartMove()
    {
        int dead =0;
        int goal = 0;
        for (int i = 0; i < player.Length; i++)
        {
            if (player[i].GetComponent<Player>().IsDead())
                dead++;
            if (player[i].GetComponent<Player>().IsGoal())
                goal++;
            if (dead > 2 || goal > 2)
                return true;
        }
        return false;
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
                    if(StartMove())
                    {
                        // ゲーム終了
                    }
                    else
                    {
                        mas.ResetNowPlayer();
                        SwordDecisionPush();
                        aggregate.AggregateON();
                        audioUI.SetActive(false);
                        gameScene.DeadPlayer();
                        gameScene.OnScreenButton(ScreenType.Move);
                    }

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
                                gameScene.OnScreenButton(ScreenType.Move);
                                break;
                            }
                        }
                        MoveSceneNext();
                    }
                    else
                    {
                        MoveSceneNext();
                    }
                    if (nowPlayer <= 4 && !player[nowPlayer].GetComponent<Player>().IsDropOut())
                        colorChange.Color(playerscr[nowPlayer].GetPotision());
                }
            }  
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
                    int i = (int)chip.GetComponent<Chip>().GetItem().GetKind();
                    Image.sprite = itemImages[i];
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
         //   moveDecision.SetActive(true);
        }
        else
        {
            //刀の決定ボタンを表示
          //  swordDecision.SetActive(true);
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
    public void MoveSceneNext()
    {
        nextMoveUI.SetActive(false);
        for (int i = 0; i < nextUI.Length; i++)
        {
            nextUI[i].SetActive(true);
        }
        audioUI.SetActive(false);
        SwordDecisionPush();
        if(player[mas.GetNowPlayer()].GetComponent<Player>().IsDropOut())
        {
            mas.AddNowPlayer();
            if(mas.GetNowPlayer()>3)
            {
                mas.ResetNowPlayer();
                SwordDecisionPush();
                aggregate.AggregateON();
                audioUI.SetActive(false);
                gameScene.DeadPlayer();
                gameScene.OnScreenButton(ScreenType.Move);
            }
            else
            {
                MoveSceneNext();
            } 
        }
        playerName.text = "プレイヤー" + (mas.GetNowPlayer() + 1);
    }
    public void OnNextMoveUI()
    {
        SwordDecisionPush();
        nextMoveUI.SetActive(true);
        colorChange.ColorReset();
        audioUI.SetActive(false);
    }
    public void DirectionUI()
    {
        for (int i = 0; i < nextUI.Length; i++)
        {
            nextUI[i].SetActive(false);
        }
        DirectionButtonOn();
        audioUI.SetActive(true);
        colorChange.Color(player[mas.GetNowPlayer()].GetComponent<Player>().GetPotision());
    }
}