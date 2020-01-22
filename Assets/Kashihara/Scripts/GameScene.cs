using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public enum ScreenType
<<<<<<< HEAD
{
    Default,
    Sound,
    Move,
    Use,
    Get,
    Private,
    Whole,
}

public class GameScene : MonoBehaviourPunCallbacks
{
    [SerializeField] private StageMap map;
    [SerializeField] private List<Item> item;
    private Player player;
    
    //private NetworkObject network;

    [SerializeField] private JobScreen jobScreen;
    [SerializeField] private DefaultScreen defaultScreen;
    [SerializeField] private GameObject soundScreen;
    [SerializeField] private GameObject moveScreen;
    [SerializeField] private GameObject itemUseScreen;
    [SerializeField] private GameObject itemGetScreen;
    [SerializeField] private PrivateResult privateResultScreen;
    [SerializeField] private WholeResult wholeResultScreen;
=======
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
>>>>>>> Kashihara_PUN2

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        PhotonNetwork.IsMessageQueueRunning = true;
        GameObject instance = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
        player = instance.GetComponent<Player>();
        player.Initialize(PhotonNetwork.LocalPlayer.ActorNumber);
        InitializeGame();
        JobScreen();
=======
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
>>>>>>> Kashihara_PUN2
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

<<<<<<< HEAD
    public void ChangeScreen(ScreenType type)
    {
        switch (type)
        {
            case ScreenType.Default:
                DefaultScreen();
                break;
            case ScreenType.Sound:
                SoundScreen();
                break;
            case ScreenType.Move:
                MoveScreen();
                break;
            case ScreenType.Use:
                UseItemScreen();
                break;
            case ScreenType.Get:
                GetItemScreen();
                break;
            case ScreenType.Private:
                PrivateResultScreen();
                break;
            case ScreenType.Whole:
                WholeResultScreen();
                break;
        }
    }

 

    /// <summary>
    /// 初期化
    /// </summary>
    private void InitializeGame()
    {
        if(PhotonNetwork.LocalPlayer.ActorNumber == 3)
        {
            item = new List<Item>();
            CreateItem(ItemKind.Amulet);
            InitializeItem();
        }
    }

    private void CreateItem(ItemKind kind)
    {
        GameObject obj = PhotonNetwork.Instantiate("Item", Vector3.zero, Quaternion.identity);
        switch (kind)
        {
            case ItemKind.Amulet:
                item.Add(Amulet.Create(obj));
                break;
            case ItemKind.Cutter:
                item.Add(Cutter.Create(obj));
                break;
            case ItemKind.Key:
                item.Add(Key.Create(obj));
                break;
            case ItemKind.Sword:
                item.Add(Sword.Create(obj));
                break;
        }
    }

    /// <summary>
    /// アイテムの初期化
    /// </summary>
    private void InitializeItem()
    {
        
        MapIndex index;
        for(int i = 0;i < 4;i++)
        {
            index.column = StageMap.Column[Random.Range(0, 4)];
            index.row = StageMap.Row[Random.Range(0, 4)];
            for(int j = 0;j < i;j++)
            {
                if (item[j].GetPosition().row != index.row) continue;
                if (item[j].GetPosition().column != index.column) continue;
                index.column = StageMap.Column[Random.Range(0, 4)];
                index.row = StageMap.Row[Random.Range(0, 4)];
            }
            item[i].SetPosition(index);
        }
    }

    /// <summary>
    /// 役職画面
    /// </summary>
    private void JobScreen()
    {
        jobScreen.SetJobImage(player.IsHaunted);
    }

    /// <summary>
    /// デフォルト画面
    /// </summary>
    private void DefaultScreen()
    {
        defaultScreen.OpenScreen();
=======
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
>>>>>>> Kashihara_PUN2
    }

    /// <summary>
    /// 音を聴く画面
    /// </summary>
    private void SoundScreen()
    {
        Debug.Log("Sound");
    }

    /// <summary>
    /// 移動画面
    /// </summary>
    private void MoveScreen()
    {
        Debug.Log("Move");
    }

    /// <summary>
    ///  刀の使用画面
    /// </summary>
    private void UseItemScreen()
    {
        Debug.Log("Use");
    }

    /// <summary>
    /// アイテム獲得画面
    /// </summary>
    private void GetItemScreen()
    {
        Debug.Log("Get");
    }

    /// <summary>
    /// 個人結果画面
    /// </summary>
    private void PrivateResultScreen()
    {
        string nickName = PhotonNetwork.NickName;
        //Player player = network.GetPlayer(nickName);
        privateResultScreen.OpenScreen(player);
    }

    /// <summary>
    /// 全体結果画面
    /// </summary>
    private void WholeResultScreen()
    {
        //Result result = network.GetResult();
        //wholeResultScreen.OpenScreen(result);
    }


}
