using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public enum ScreenType
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

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
        GameObject instance = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
        player = instance.GetComponent<Player>();
        player.Initialize(PhotonNetwork.LocalPlayer.ActorNumber);
        InitializeGame();
        JobScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
