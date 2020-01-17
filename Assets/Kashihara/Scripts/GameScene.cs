using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

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
    //[SerializeField] private Map map;
    //[SerializeField] private Player[] players;
    private NetworkObject network;

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
        GameObject instance = PhotonNetwork.Instantiate("NetworkObject", Vector3.zero, Quaternion.identity);
        network = instance.GetComponent<NetworkObject>();
        InitializeGame();
        DefaultScreen();
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

    }

    /// <summary>
    /// デフォルト画面
    /// </summary>
    private void DefaultScreen()
    {
        Debug.Log("Default");
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
        Player player = network.GetPlayer(nickName);
        privateResultScreen.OpenScreen(player);
    }

    /// <summary>
    /// 全体結果画面
    /// </summary>
    private void WholeResultScreen()
    {
        Result result = network.GetResult();
        wholeResultScreen.OpenScreen(result);
    }


}
