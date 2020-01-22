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

    [SerializeField] JobScreen jobScreen;
    [SerializeField] DefaultScreen defaultScreen;
    [SerializeField] SoundScreen soundScreen;
    [SerializeField] MoveScreen moveScreen;
    [SerializeField] UseScreen useScreen;
    [SerializeField] GetScreen getScreen;
    [SerializeField] PrivateResult privateResult;


    [SerializeField] private NextPlayerScreen nextScreen;

    private readonly int MaxPlayer = 4;
    private readonly int MaxItem = 4;

    private int activeNumber;
    private MapIndex[] moveList;
    private bool[] isGetList;
    private ItemKind[] getItemList;
    private bool isUse;


    private void Awake()
    {
        activeNumber = 0;

        moveList = new MapIndex[MaxPlayer];
        isGetList = new bool[MaxPlayer];
        getItemList = new ItemKind[MaxPlayer];
        isUse = false;

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
        // 役職を設定
        bool[] jobList = { false, false, false, false };
        int hauntedNum = Random.Range(0, MaxPlayer - 1);
        jobList[hauntedNum] = true;

        // 座標を設定
        for(int i = 0;i < MaxPlayer;i++)
        {
            moveList[i] = StageMap.GetRandomIndex();
            Debug.Log("Player" + i + ":" + moveList[i].row + moveList[i].column);
            players[i].Initialize(jobList[i], moveList[i]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーの初期化
        InitializePlayer();
        // 役職画面を表示
        jobScreen.OpenScreen(players[activeNumber].isHaunted);
        nextScreen.OpenScreen(activeNumber);
    }

    /// <summary>
    /// プレイヤーのラウンドアップ
    /// </summary>
    private void RoundUpPlayer()
    {
        int next = activeNumber + 1;
        activeNumber = next % MaxPlayer;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 役職画面の次が押された
    /// </summary>
    public void OnJobButton()
    {
        // 役職画面を閉じる
        jobScreen.CloseScreen();
        // プレイヤーのカウントアップ
        RoundUpPlayer();
        // プレイヤーが１巡していなければ
        if(activeNumber != 0)
        {
            // 役職画面を開く
            jobScreen.OpenScreen(players[activeNumber].isHaunted);
            nextScreen.OpenScreen(activeNumber);
        }
        else
        {
            // デフォルト画面を開く
            defaultScreen.OpenScreen(players[activeNumber].isHaunted, players[activeNumber].position,ItemKind.MaxItem);
        }
    }

    /// <summary>
    /// 音を聞くボタンが押された
    /// </summary>
    public void OnSoundButton()
    {
        defaultScreen.CloseScreen();
        soundScreen.OpenScreen(NearItem());
    }

    /// <summary>
    /// 音を聞く画面の「次へ」が押されたら
    /// </summary>
    public void OnSoundNextButton()
    {
        // 音を聞く画面を閉じる
        soundScreen.CloseScreen();
        // プレイヤーのラウンドアップ
        RoundUpPlayer();
        // プレイヤーが１巡していたら
        if (activeNumber == 0)
        {
            // 音を聞き終える
            defaultScreen.SoundEnd();
        }

        // デフォルト画面を開く
        defaultScreen.OpenScreen(players[activeNumber].isHaunted, players[activeNumber].position, ItemKind.MaxItem);
        nextScreen.OpenScreen(activeNumber);
    }

    /// <summary>
    /// デフォルト画面の「移動ボタン」が押されたら
    /// </summary>
    public void OnMoveButton()
    {
        // デフォルト画面を閉じる
        defaultScreen.CloseScreen();
        // 移動画面を開く
        moveScreen.OpenScreen(players[activeNumber].position);
    }

    /// <summary>
    /// 移動画面の「次へ」を押したとき
    /// </summary>
    public void OnMoveNextButton()
    {
        // 移動画面を閉じる
        moveList[activeNumber] = moveScreen.GetNextMove();
        ItemKind nextItem = GetNextItem();
        if (nextItem != ItemKind.MaxItem)
        {
            getItemList[activeNumber] = nextItem;
            // アイテム取得画面を開く
            getScreen.OpenScreen();
            return;
        }

        if (players[activeNumber].item == ItemKind.Sword)
        {
            // 刀仕様画面を開く
            useScreen.OpenScreen();
            return;
        }

        // 移動画面を閉じる
        CloseMoveScreen();
    }

    /// <summary>
    /// アイテム取得画面の「次へ」ボタンが押されたとき
    /// </summary>
    public void OnGetButton(bool isGet)
    {
        isGetList[activeNumber] = isGet;
        if(!isGet)
        {
            getItemList[activeNumber] = ItemKind.MaxItem;
        }
        getScreen.CloseScreen();
        // 移動画面を閉じる
        CloseMoveScreen();

        Debug.Log(getItemList[activeNumber]);
    }

    /// <summary>
    /// 刀使用画面の「次へ」が押されたとき
    /// </summary>
    public void OnUseButton(bool use)
    {
        isUse = use;
        useScreen.CloseScreen();
        // 移動画面を閉じる
        CloseMoveScreen();
    }

    /// <summary>
    /// 移動画面を閉じる
    /// </summary>
    private void CloseMoveScreen()
    {
        moveScreen.CloseScreen();
        // 次のプレイヤーへ
        RoundUpPlayer();

        // プレイヤーが１巡していたら
        if (activeNumber == 0)
        {
            // 音を聞き終える
            defaultScreen.MoveEnd();
        }

        // デフォルト画面を開く
        defaultScreen.OpenScreen(players[activeNumber].isHaunted, players[activeNumber].position, ItemKind.MaxItem);
        nextScreen.OpenScreen(activeNumber);
    }

    private void JudgeResult()
    {
        
    }

    private void GettingItem()
    {

        for(int i = 0;i < MaxPlayer - 1;i++)
        {
            if(!players[i].position.Equals(players[i + 1].position))
            {
                if(isGetList[i])
                {

                }
            }
        }
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

        if(nearItem != null)
        {
            Debug.Log("Player" + activeNumber + "に一番近いアイテムは" + nearItem.GetKind());
        }

        return nearItem;
    }

    private ItemKind GetNextItem()
    {
        MapIndex playerIndex = moveList[activeNumber];
        ItemKind kind = ItemKind.MaxItem;
        foreach (var item in items)
        {
            MapIndex itemIndex = StageMap.VectorToIndex(item.transform.position);
            if (Equals(playerIndex, itemIndex))
            {
                kind = item.GetKind();
            }
        }

        return kind;
    }
}
