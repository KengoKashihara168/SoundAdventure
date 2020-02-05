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
    [SerializeField] Image sowrdImage;
    [SerializeField] GameScene gameScene;
    [SerializeField] GameObject audioUI;
    [SerializeField] GameObject nextMoveUI;
    [SerializeField] Aggregate aggregate;
    [SerializeField] Sprite[] itemTakeImages;
    [SerializeField] Sprite[] myItemImages;
    [SerializeField] Sprite[] myJobImages;
    [SerializeField] Image myJob;
    [SerializeField] GameObject[] nextUI;
    [SerializeField] Text playerName;
    [SerializeField] Move move;
    [SerializeField] GameObject myItemUI;
    int nowPlayer;
    MasterScriot mas;
    GameObject[] player;
    Player[] playerscr;
    MapIndex oldPlayerPos;
    bool isMove;
    bool isItem;
    bool useSword;

    // Start is called before the first frame update
    void Start()
    {
        isMove = false;
        isItem = false;
        useSword = false;
        myItemUI.SetActive(false);
        myJob.enabled = false;
        mas = Master.GetComponent<MasterScriot>();
        nowPlayer = mas.GetNowPlayer();
        player = mas.GetPlayer();
        playerscr = new Player[player.Length];
        oldPlayerPos = new MapIndex();
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
                        Debug.Log("こっち1");
                        mas.ResetNowPlayer();
                        SwordDecisionPush();
                        aggregate.AggregateON();
                        audioUI.SetActive(false);
                        gameScene.DeadPlayer();
                        myItemUI.SetActive(false);
                        nextUIOff();
                        myJob.enabled = false;
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
                                Debug.Log("死んでる");
                                mas.ResetNowPlayer();
                                SwordDecisionPush();
                                aggregate.AggregateON();
                                audioUI.SetActive(false);
                                gameScene.DeadPlayer();
                                myItemUI.SetActive(false);
                                nextUIOff();
                                myJob.enabled = false;
                                gameScene.OnScreenButton(ScreenType.Move);
                                break;
                            }
                        }
                      
                    }

                    if (nowPlayer < 4 && !player[nowPlayer].GetComponent<Player>().IsDropOut())
                    {
                        colorChange.Color(playerscr[nowPlayer].GetPotision());
                        MoveSceneNext();
                    }
                     
                }
            }  
        }
    }

    //プレイヤーのポジション設定
    public void MoveDecision()
    {
        if(useSword) // 刀を使ったら
        {
            Sowrd();
            useSword = false;
            isItem = false;
        }
        else
        {
            nowPlayer = mas.GetNowPlayer();
            string pPos = playerscr[nowPlayer].GetPotision().row + playerscr[nowPlayer].GetPotision().column;
            oldPlayerPos = playerscr[nowPlayer].GetPotision();
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
                    if (chip.GetComponent<Chip>().GetItem().GetKind() == ItemKind.Goal)
                    {
                        playerscr[nowPlayer].SetFoot(true);
                        isItem = false;
                    }
                    else
                    {
                        int i = (int)chip.GetComponent<Chip>().GetItem().GetKind();
                        Image.sprite = itemTakeImages[i];
                        playerscr[nowPlayer].SetFoot(true);
                        yesButton.SetActive(true);
                        noButton.SetActive(true);
                        Image.enabled = true;
                        isItem = true;
                    }

                }
                if (!isItem)
                {
                    if (playerscr[nowPlayer].GetItemKind() == ItemKind.Sword)
                    {
                        sowrdImage.enabled = true;
                        useSword = true;
                        yesButton.SetActive(true);
                        noButton.SetActive(true);
                        isMove = false;
                        isItem = true;
                        Debug.Log("刀持ってる");
                    }
                }
                if(!useSword)
                    isMove = false;
            }
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
        sowrdImage.enabled = false;
    }

    //はいのボタン
    public void YesPush()
    {
        if (useSword)   // 刀をしようする
        {
            sowrdImage.enabled = false;
            isItem = false;
            DirectionButtonOn();
        }
        else
        {
            useSword = false;
            isItem = false;
            MoveDecisionPush();
        }
    }
    //いいえのボタン
    public void NoPush()
    {
        if(useSword)
        {
            useSword = false;
            isItem = false;
            MoveDecisionPush();
        }
        else
        {
            if (playerscr[nowPlayer].GetItemKind() != ItemKind.Sword)
            {
                playerscr[nowPlayer].SetFoot(false);
                isItem = false;
                MoveDecisionPush();
            }
            else
            {
                sowrdImage.enabled = true;
                useSword = true;
                Image.enabled = false;
            }
        }
       
    }
    //方角のボタンを押したら
    public void DirectiomPush()
    {
        //刀の画像が表示されたら(2つの決定ボタンを分けるため)
        if (Image.enabled == false)
        {
            //移動の決定ボタンを表示
            //moveDecision.SetActive(true);
        }
        else
        {
            //刀の決定ボタンを表示
            //swordDecision.SetActive(true);
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
            myItemUI.GetComponent<Image>().sprite = myItemImages[(int)playerscr[nowPlayer].GetItemKind()];
            myItemUI.SetActive(true);
            if (!playerscr[nowPlayer].IsHaunted())
                myJob.sprite = myJobImages[0];
            else
                myJob.sprite = myJobImages[1];
            myJob.enabled = true;
        }
    }
    public void MoveSceneNext()
    {
        nextMoveUI.SetActive(false);
        myJob.enabled = false;
        for (int i = 0; i < nextUI.Length; i++)
        {
            nextUI[i].SetActive(true);
        }
        audioUI.SetActive(false);
        SwordDecisionPush();
        if(player[mas.GetNowPlayer()].GetComponent<Player>().IsDropOut())
        {
            mas.AddNowPlayer();
            if(mas.GetNowPlayer() > 3)
            {
                Debug.Log("あふれた");
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
        myItemUI.SetActive(false);
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
    public void nextUIOff()
    {
        for (int i = 0; i < nextUI.Length; i++)
        {
            nextUI[i].SetActive(false);
        }
    }
    public void Sowrd()
    {
        int row = 0;
        int column = 0;
        switch (move.GetDirection())
        {
            case Direction.North:
                row -= 1;
                break;
            case Direction.South:
                row += 1;
                break;
            case Direction.West:
                column -= 1;
                break;
            case Direction.East:
                column += 1;
                break;
        }
        MapIndex pos = new MapIndex();
        int scolumn = (int)oldPlayerPos.column.ToCharArray()[0] + column;
        char chars = (char)scolumn;
        pos.SetIndex(oldPlayerPos.row+row, chars.ToString());
        Debug.Log(chars + "刀");
        aggregate.SetSorwd(pos);
    }
    public bool GetUseSwrod()
    {
        return useSword;
    }
    public MapIndex GetoldPostion()
    {
        return oldPlayerPos;
    }
}