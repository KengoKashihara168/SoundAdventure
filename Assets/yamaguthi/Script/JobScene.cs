﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class JobScene : MonoBehaviour
{
    [SerializeField] Hassyakusama hassyaku;
    [SerializeField] ColorChange colorChange;
    [SerializeField]
    GameObject ResultNextButton;
    [SerializeField] GameObject nameBox;
    public GameObject map;
    [SerializeField] StageMap stageMap;
    public GameObject master;
    public Text playerName;
    public AudioClip[] audio;
    public GameObject jobPanel;
    public GameObject[] role;

    GameObject[] Player;
    List<MapIndex> save = new List<MapIndex>();
    Item[] item;
    int itemNum = 1;
    bool isItem;
    bool isSceneClose=false;
    int isHaunted;
    int maxcolumn = 4;
    // Start is called before the first frame update
    void Start()
    {
        int nowPlayer = master.GetComponent<MasterScriot>().GetNowPlayer();
        isItem = false;
        isHaunted = Random.Range(0, maxcolumn);
        Player = master.GetComponent<MasterScriot>().GetPlayer();
        playerName.text = "プレイヤー" + (nowPlayer + 1);
        for(int i=0;i< role.Length; i++)
        {
            role[i].SetActive(false);
        }
        ResultNextButton.SetActive(false);
        nameBox.SetActive(false);
       // item = stageMap.GetItemInfo();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void newJob()
    {
        item = stageMap.GetItemInfo();
    }
        public void CloseScene()
    {
        jobPanel.SetActive(false);
    }
    // プレイヤーのポジションとアイテムのポジション設定
    public void SetinfoPos()
    {

        int nowPlayer = master.GetComponent<MasterScriot>().GetNowPlayer();
      
        //  アイテムのポジション設定
        if (!isItem)
        {
            for (int i = 0; i < 5; i++)
            {
                SetItemPositon();
                SetItem(item[i].GetInfo().audio, item[i].GetInfo().kind, i);
            }
            SetItemPositon();
            hassyaku.SetPostion(save[save.Count - 1].row, save[save.Count - 1].column);
            Debug.Log("八尺" + hassyaku.GetPosition().row + hassyaku.GetPosition().column);
            isItem = true;
        }

        // プレイヤーのポジション設定
        MapIndex index = Autocheck();
        save.Add(index);
        // 役職設定
        if (nowPlayer == isHaunted)
        {
            Player[nowPlayer].GetComponent<Player>().SetHaunted(true);
            Debug.Log("つきびと" + "プレイヤー" + (nowPlayer + 1));
            role[0].SetActive(false);
            role[1].SetActive(true);
        }
        else
        {
            role[0].SetActive(true);
            role[1].SetActive(false);
        }
        Player[nowPlayer].GetComponent<Player>().SetPotision(index);
        Debug.Log(Player[nowPlayer].GetComponent<Player>().GetPotision().row + Player[nowPlayer].GetComponent<Player>().GetPotision().column + "プレイヤー" + (nowPlayer + 1));
       
        if (master.GetComponent<MasterScriot>().GetNowPlayer() > 3)
        {
            master.GetComponent<MasterScriot>().ResetNowPlayer();
            isSceneClose = true;
        }
    }
    // アイテムのポジションをセット
    private void SetItemPositon()
    {
        save.Add(Autocheck());
        Debug.Log(save[save.Count-1].row+ save[save.Count-1].column+"アイテム");
    }
    private void SetItem(AudioClip audio, ItemKind kind,int num)
    {
        map.GetComponent<StageMap>().SetItem(save[num].row, save[num].column, audio, kind);
    }
    private MapIndex Autocheck()
    {
        string[] Column = { "A", "B", "C", "D", "E" };
        int row = Random.Range(0, maxcolumn);
        int columnint = Random.Range(0, maxcolumn);
        MapIndex sa = new MapIndex();
        sa.SetIndex(row, Column[columnint]);
        for (int i = 0; i < save.Count; i++)
        {
            if (save[i].row == row && save[i].column == Column[columnint])
            {
                row = Random.Range(0, maxcolumn);
                columnint = Random.Range(0, maxcolumn);
                i = -1;
                sa.SetIndex(row, Column[columnint]);
                continue;
            }
        }
        return sa;
    }
    public bool GetCloseFlag()
    {
        return isSceneClose;
    }

    public void roleImagePlay(bool breakFlag)
    {
        int nowPlayer = master.GetComponent<MasterScriot>().GetNowPlayer();
        if (breakFlag == true)
        {
            role[0].SetActive(false);
            role[1].SetActive(false);
            role[2].SetActive(true);
            role[3].SetActive(true);
            playerName.text = "プレイヤー" + (nowPlayer + 1);
        }
        else
        {
            role[2].SetActive(false);
            role[3].SetActive(false);
        }
    }
    public void add()
    {
        master.GetComponent<MasterScriot>().AddNowPlayer();
    }
    public void playerpostion()
    {
        int nowPlayer = master.GetComponent<MasterScriot>().GetNowPlayer();
        colorChange.ColorCh(Player[nowPlayer].GetComponent<Player>().GetPotision());
    }
    public void SetCloseFlag(bool flag)
    {
        isSceneClose = flag;
    }
}


