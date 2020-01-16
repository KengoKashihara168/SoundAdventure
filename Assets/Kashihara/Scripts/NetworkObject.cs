using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkObject : MonoBehaviourPunCallbacks
{
    private GameObject playerPrefab;
    private Dictionary<string, Player> players;
    private Result result;

    // Start is called before the first frame update
    void Start()
    {
        playerPrefab = (GameObject)Resources.Load("Player");
        players = new Dictionary<string, Player>();
        foreach(var player in PhotonNetwork.PlayerList)
        {
            AddPlayer(player);
        }
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
        players.Add(nickName, p);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 全体の結果を設定
    /// </summary>
    private void SetResult()
    {
        CheckDeads();
        CheckGoals();
        CheckGetItem();
        CheckWinner();
    }

    /// <summary>
    /// 死亡者を調べる
    /// </summary>
    private void CheckDeads()
    {
        result.deadNames = new List<string>();
        foreach(var player in players)
        {
            if (!player.Value.IsDead()) continue;
            result.deadNames.Add(player.Key);
        }
    }

    /// <summary>
    /// 脱出者を調べる
    /// </summary>
    private void CheckGoals()
    {
        result.goalNames = new List<string>();
        foreach(var player in players)
        {
            if (!player.Value.IsGoal()) continue;
            result.goalNames.Add(player.Key);
        }
    }

    /// <summary>
    /// アイテムを取得したプレイヤーがいるか調べる
    /// </summary>
    private void CheckGetItem()
    {
        result.isGetItem = false;
        foreach(var player in players)
        {
            if (player.Value.GetItemKind() != ItemKind.None) continue;
            result.isGetItem = true;
        }
    }

    /// <summary>
    /// 勝者の設定
    /// </summary>
    private void CheckWinner()
    {
        result.winer = WinType.None;
    }

    public Player GetPlayer(string nickName)
    {
        return players[nickName];
    }

    public Result GetResult()
    {
        SetResult();
        return result;
    }
    
}
