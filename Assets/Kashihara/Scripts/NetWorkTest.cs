//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Photon.Pun;
//using Photon.Realtime;
//using UnityEngine.UI;

//public class NetWorkTest : MonoBehaviourPunCallbacks
//{
//    [SerializeField] private Text playerName;

//    // Start is called before the first frame update
//    void Start()
//    {
//        PhotonNetwork.IsMessageQueueRunning = true;
//        foreach(var player in PhotonNetwork.PlayerList)
//        {
//            playerName.text += player.NickName;
//            playerName.text += ",";
//        }

//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
