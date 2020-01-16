using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkObject : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;
    private Dictionary<string, Player> players;

    // Start is called before the first frame update
    void Start()
    {
        players = new Dictionary<string, Player>();
        foreach(var player in PhotonNetwork.PlayerList)
        {
            AddPlayer(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Player GetPlayer(string nickName)
    {
        Debug.Log("GetPlayer:" + nickName);
        return players[name];
    }

    private void AddPlayer(Photon.Realtime.Player player)
    {
        // プレイヤーオブジェクトの生成
        GameObject obj = Instantiate(playerPrefab);
        // プレイヤーをネットワークオブジェクトの子要素に追加
        obj.transform.SetParent(transform);
        // オブジェクト名をプレイヤー名に変更
        obj.name = player.NickName;
        // プレイヤースクリプトの取得
        Player p = obj.GetComponent<Player>();
        // プレイヤーをディクショナリに登録
        string nickName = player.NickName;
        Debug.Log("AddPlayer:" + nickName);
        players.Add(nickName, p);
        Debug.Log(players[nickName].IsDead());
    }
}
