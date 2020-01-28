﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class JobScene : MonoBehaviour
{
    public GameObject map;
    public GameObject master;
    public Text playerName;
    public AudioClip[] audio;
    public Canvas canvas;
    GameObject[] Player;
    List<MapIndex> save = new List<MapIndex>();
    Item[] item;
    int itemNum = 1;
    bool isItem;
    bool isSceneClose=false;
    int isHaunted;
    int maxcolumn = 5;
    // Start is called before the first frame update
    void Start()
    {
        int nowPlayer = master.GetComponent<MasterScriot>().GetNowPlayer();
        isItem = false;
        isHaunted = Random.Range(0, maxcolumn);
        Player = master.GetComponent<MasterScriot>().GetPlayer();
        playerName.text = "プレイヤー" + (nowPlayer + 1);
        item = map.GetComponent<StageMap>().GetItemInfo();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void CloseScene()
    {
        // メインのキャンバスの子のサブキャンバスから非表示にするUIを探す
        foreach (Transform child in canvas.transform)
        {
            if (child.name == "JobUI")
            {
                foreach (Transform schild in child.transform)
                {
                    schild.gameObject.SetActive(false);
                }
            }
        }
    }
    public void SetinfoPos()
    {    
        int nowPlayer = master.GetComponent<MasterScriot>().GetNowPlayer();
        playerName.text = "プレイヤー" + (nowPlayer + 1);
        if (!isItem)
        {
            for (int i = 0; i < itemNum; i++)
            {
                SetItemPositon();
                SetItem(item[i].GetInfo().audio, item[i].GetInfo().kind, i);
            }
            isItem = true;
        }
        MapIndex index = Autocheck();
        for (int i=0;i< nowPlayer; i++)
        {
            if(Player[i].GetComponent<Player>().GetPotision().row==index.row&& Player[i].GetComponent<Player>().GetPotision().column == index.column )
            {
                index = Autocheck();
                i = 0;
                continue;
            }
        }
        if(nowPlayer== isHaunted)
        {
            Player[nowPlayer].GetComponent<Player>().SetHaunted(true);
        }
        Player[nowPlayer].GetComponent<Player>().SetPotision(index);
        master.GetComponent<MasterScriot>().AddNowPlayer();
        if (master.GetComponent<MasterScriot>().GetNowPlayer() >= 4)
        {
            master.GetComponent<MasterScriot>().ResetNowPlayer();
            isSceneClose = true;
        }
    }
    private void SetItemPositon()
    {
        save.Add(Autocheck());
        Debug.Log(save[save.Count-1].row+ save[save.Count-1].column);
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
                i = 0;
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
}


