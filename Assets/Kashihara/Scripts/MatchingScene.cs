using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchingScene : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField inputName;
    [SerializeField] private GameObject nameList;

    [SerializeField] private GameObject playerInput;

    private List<Text> names;

    private readonly int MaxPlayer = 4;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        names = new List<Text>();

        for(int i = 0;i < nameList.transform.childCount;i++)
        {
            Transform child = nameList.transform.GetChild(i);
            Text name = child.GetComponent<Text>();
            names.Add(name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var player in PhotonNetwork.PlayerList)
        {
            int num = player.ActorNumber - 1;
            names[num].text = player.NickName;
        }

        Matching();
    }

    /// <summary>
    /// マスターサーバに接続
    /// </summary>
    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions() { MaxPlayers = (byte)MaxPlayer };
        PhotonNetwork.JoinOrCreateRoom("Room1", options, TypedLobby.Default);
        //PhotonNetwork.JoinOrCreateRoom("Room2", options, TypedLobby.Default);
    }

    /// <summary>
    /// 名前入力のボタンが押された
    /// </summary>
    public void OnDecision()
    {
        if (inputName.text == "") return;
        PhotonNetwork.LocalPlayer.NickName = inputName.text;
        playerInput.SetActive(false);
    }

    /// <summary>
    /// プレイヤーが揃っているか調べる
    /// </summary>
    /// <returns></returns>
    private bool IsFilled()
    {
        if (PhotonNetwork.PlayerList.Length < MaxPlayer) return false;
        return true;
    }

    /// <summary>
    /// プレイヤーが名前入力を終了しているか調べる
    /// </summary>
    /// <returns></returns>
    private bool IsNameQuery()
    {
        bool isNameQuery = true;
        foreach (var player in PhotonNetwork.PlayerList)
        {
            isNameQuery = player.NickName != "";
        }
        return isNameQuery;
    }

    /// <summary>
    /// マッチングできるか調べる
    /// </summary>
    /// <returns></returns>
    private bool IsMatching()
    {
        if (playerInput.activeSelf) return false; // 自身の名前入力が終了しているか
        if (!IsNameQuery()) return false;         // 全プレイヤーの名前入力が終了しているか
        if (!IsFilled()) return false;            // プレイヤーが揃っているか
        return true;
    }

    /// <summary>
    /// 全員マッチングして次のシーンへ
    /// </summary>
    private void Matching()
    {
        if (!IsMatching()) return;
        PhotonNetwork.IsMessageQueueRunning = false;
        SceneManager.LoadScene("GameTestScene");
    }

    
}
