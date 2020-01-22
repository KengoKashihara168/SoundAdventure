using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScreenType
{
    Job,
    Default,
    Sound,
    Move,
    Use,
    Get,
    Private,
    Whole,
}

public class GameScene : MonoBehaviour
{
    [SerializeField] private Player[] players;
    [SerializeField] private Item[] items;

    [SerializeField] private NextPlayerScreen nextScreen;

    private readonly int MaxPlayer = 4;

    private int activeNumber;
    private bool[] jobList = { false, false, false, false };
    private MapIndex[] moveList;


    private void Awake()
    {
        activeNumber = 0;

        moveList = new MapIndex[MaxPlayer];

        foreach (var item in items)
        {
            item.SetPosition(StageMap.GetRandomIndex());
            MapIndex index = StageMap.VectorToIndex(item.transform.position);
            Debug.Log(item.GetKind() + "=" + index.row.ToString() + index.column);
        }
    }

    /// <summary>
    /// プレイヤーの初期化
    /// </summary>
    private void InitializePlayer()
    {
        // 座標を設定
        int i = 0;
        foreach (Player player in players)
        {
            moveList[i] = StageMap.GetRandomIndex();
            player.SetPosition(moveList[i]);
            i++;
        }
        // 役職を設定
        int hauntedNum = Random.Range(0, MaxPlayer - 1);
        players[hauntedNum].Haunted();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializePlayer();
        foreach (var player in players)
        {
            player.gameObject.SetActive(false);
        }
        players[activeNumber].gameObject.SetActive(true);
        ChangeScreen(ScreenType.Job);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScreen(ScreenType type)
    {
        players[activeNumber].AllCloseScreen();
        switch (type)
        {
            case ScreenType.Job:
                players[activeNumber].Job();
                break;
            case ScreenType.Default:
                players[activeNumber].Default();
                break;
            case ScreenType.Sound:
                players[activeNumber].Sound(NearItem());
                break;
            case ScreenType.Move:
                players[activeNumber].Move();
                break;
            case ScreenType.Use:
                if(!players[activeNumber].Use())
                {
                    ChangeScreen(ScreenType.Get);
                }
                break;
            case ScreenType.Get:
                if (!players[activeNumber].Get(GetNextItem()))
                {
                    ChangeScreen(ScreenType.Private);
                }
                break;
            case ScreenType.Private:
                SetPlayerResult();
                players[activeNumber].Private();
                break;
            case ScreenType.Whole:

                break;
        }
    }



    /// <summary>
    /// 次のプレイヤーへ後退する（０～３プレイヤーのJobに設定）
    /// </summary>
    private void NextPlayer()
    {
        players[activeNumber].gameObject.SetActive(false);
        // ４カウントをループ
        int nextNum = (activeNumber + 1) % MaxPlayer;
        activeNumber = nextNum;
        // プレイヤーをアクティブにする
        players[activeNumber].gameObject.SetActive(true);
    }

    public void JobNext()
    {
        //NextPlayer();
        players[activeNumber].Default();
    }

    public void JobEnd()
    {
        NextPlayer();
        players[activeNumber].Default();
    }

    public void OnSound()
    {
        Camera.main.transform.position = players[activeNumber].transform.position;
        players[activeNumber].Sound(NearItem());
    }

    public void OnDefault()
    {
        players[activeNumber].Default();
    }

    public void OnMove()
    {
        players[activeNumber].Move();
    }

    public void MoveNext()
    {
        moveList[activeNumber] = players[activeNumber].GetNextPosition();

        if(players[activeNumber].GetItemKind() == ItemKind.Sword)
        {
            players[activeNumber].Use();
        }

        

        NextPlayer();
        players[activeNumber].Default();
    }

    public void MoveEnd()
    {
        moveList[activeNumber] = players[activeNumber].GetNextPosition();
        NextPlayer();
    }

    private void SetPlayerResult()
    {
        // 座標の更新
        players[activeNumber].SetPosition(players[activeNumber].GetNextPosition());
        // アイテムの更新
        if(players[activeNumber].GetIsGet())
        {
            players[activeNumber].SetItem(GetNextItem());
        }
        // 八尺様の更新

        // 出口の更新
    }

    private Item NearItem()
    {
        float distance = 99999.0f;
        Item nearItem = null;
        Vector3 playerPos = players[activeNumber].transform.position;
        Vector3 itemPos;
        foreach (var item in items)
        {
            itemPos = item.transform.position;
            float toItem = (playerPos - itemPos).magnitude;
            if (toItem < distance)
            {
                if (toItem < StageMap.ChipDistance * 2)
                {
                    nearItem = item;
                }
            }
        }

        return nearItem;
    }

    private ItemKind GetNextItem()
    {
        MapIndex playerIndex = players[activeNumber].GetNextPosition();
        ItemKind kind = ItemKind.MaxItem;
        foreach(var item in items)
        {
            MapIndex itemIndex = StageMap.VectorToIndex(item.transform.position);
            if(Equals(playerIndex,itemIndex))
            {
                kind = item.GetKind();
            }
        }

        return kind;
    }
}
