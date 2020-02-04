using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] private GameObject wholeResultScreen;
    [SerializeField] private GameObject master;
    [SerializeField] private MasterScriot mast;
    [SerializeField] private Activ activ;
    [SerializeField] private GameObject[] nextPlayerUI;
    [SerializeField] private Text nextPlayername;
    List<string> deadPlayers = new List<string>();
    GameObject[] Player;
    int nowPlayer;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
        GameObject instance = PhotonNetwork.Instantiate("NetworkObject", Vector3.zero, Quaternion.identity);
        network = instance.GetComponent<NetworkObject>();
        InitializeGame();
        DefaultScreen();
        Player = master.GetComponent<MasterScriot>().GetPlayer();
        for (int i = 0; i < Player.Length; i++)
          //  player[i] = gPlayer[i].GetComponent<Player>();
        nowPlayer = master.GetComponent<MasterScriot>().GetNowPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScreenButton(ScreenType type)
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
        for (int i = 0; i < nextPlayerUI.Length; i++)
        {
            nextPlayerUI[i].SetActive(true);
        }
        Debug.Log(mast.GetNowPlayer());
        nextPlayername.text = "プレイヤー" + (mast.GetNowPlayer() + 1);
        foreach (Transform child in privateResultScreen.gameObject.transform)
        {
            child.gameObject.SetActive(false);
            if (child.name == "NextButton")
            {
                foreach (Transform text in child)
                {
                    text.gameObject.SetActive(false);
                }
            }
        }
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

    public void DeadPlayer()
    {
        for (int i = 0; i < Player.Length; i++)
        {
            if (!Player[i].GetComponent<Player>().IsDropOut() && Player[i].GetComponent<Player>().IsDead())
            {
                deadPlayers.Add(Player[i].name); Debug.Log("起動");
            }
        }
    }
    public List<string> GetDeadPlayers()
    {
        return deadPlayers;
    }
    public void NextButton()
    {
        for (int i = 0; i < nextPlayerUI.Length; i++)
        {
            nextPlayerUI[i].SetActive(false);
        }
        PrivateResultScreen();
    }
    public void ResetUI()
    {
        for (int i = 0; i < nextPlayerUI.Length; i++)
        {
            nextPlayerUI[i].SetActive(false);
        }
    }


    /// <summary>
    /// 個人結果画面
    /// </summary>
    private void PrivateResultScreen()
    {
       
       
        nowPlayer = master.GetComponent<MasterScriot>().GetNowPlayer();
        if(nowPlayer>=4)
        {
            master.GetComponent<MasterScriot>().ResetNowPlayer();
            foreach (Transform child in privateResultScreen.gameObject.transform)
            {
                child.gameObject.SetActive(false);
                if (child.name == "NextButton")
                {
                    foreach (Transform text in child)
                    {
                        text.gameObject.SetActive(false);
                    }
                }
            }
            deadPlayers.Clear();
            activ.OnNextMoveUI();
        }else
        if (!Player[nowPlayer].GetComponent<Player>().IsDropOut())
        {
            foreach (Transform child in privateResultScreen.gameObject.transform)
            {
                child.gameObject.SetActive(true);
                if(child.name=="NextButton")
                {
                    foreach (Transform text in child)
                    {
                        text.gameObject.SetActive(true);
                    }
                }      
            }
            privateResultScreen.OpenScreen(Player[nowPlayer].GetComponent<Player>(), deadPlayers);
        }
        else
        {
            master.GetComponent<MasterScriot>().AddNowPlayer();
            PrivateResultScreen();
        }
    }

    /// <summary>
    /// 全体結果画面
    /// </summary>
    private void WholeResultScreen()
    {

    }
}
