using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkObject : MonoBehaviourPunCallbacks
{
    

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// マスターサーバに接続
    /// </summary>
    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions() { MaxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom("Room1", options, TypedLobby.Default);
    }

    /// <summary>
    /// マッチング
    /// </summary>
    public override void OnJoinedRoom()
    {
        PhotonNetwork.IsMessageQueueRunning = false;

    }
}
