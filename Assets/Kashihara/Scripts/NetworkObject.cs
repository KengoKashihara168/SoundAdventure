using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkObject : MonoBehaviourPunCallbacks
{
    private bool[] playerJobs;
    private List<MapIndex> mapIndex;
    private List<MapIndex> playerPosition;

    public void InitializeObject()
    {
        // マップの初期化
        //InitializeMap();
        // 役職の初期化
        InittializeJobs();
    }

    /// <summary>
    /// 役職の初期化
    /// </summary>
    private void InittializeJobs()
    {
        playerJobs = new bool[MatchingScene.MaxPlayer];
        // 全て青年で設定
        for (int i = 0; i < playerJobs.Length; i++)
        {
            playerJobs[i] = false;
        }

        // 乱数で憑人を設定
        int rand = GetRand(MatchingScene.MaxPlayer);
        playerJobs[rand] = true;
    }

    /// <summary>
    /// 役職用の乱数を取得
    /// </summary>
    /// <returns></returns>
    private int GetRand(float range)
    {
        float min = 0.0f;
        float max = Mathf.Floor(range);
        int rand = (int)Random.Range(min, max);
        if (rand >= range)
        {
            rand = (int)range - 1;
        }

        return rand;
    }

    /// <summary>
    /// マップインデックスの初期化
    /// </summary>
    private void InitializeMap()
    {
        // 配列の初期化
        int mapLength = StageMap.MapSize * StageMap.MapSize;
        mapIndex = new List<MapIndex>();

        // インデックスを初期化
        int i = 0;
        foreach(var row in StageMap.Row)
        {
            foreach(var column in StageMap.Column)
            {
                mapIndex[i].SetIndex(row, column);
                i++;
            }
        }
    }

    /// <summary>
    /// プレイヤーの座標を初期化
    /// </summary>
    private void InitializePosition()
    {
        playerPosition = new List<MapIndex>();
        foreach(var player in PhotonNetwork.PlayerList)
        {
            playerPosition[player.ActorNumber] = GetMapIndex();
        }
    }


    public void PlayerMove(int number,Direction dir)
    {
        MapIndex position = mapIndex[number];

        switch(dir)
        {
            case Direction.East:
                
                break;
            case Direction.North:
                position.row -= 1;
                break;
            case Direction.South:
                position.row += 1;
                break;
            case Direction.West:

                break;
        }
    }

    //private string NextColumn(string current,bool isRight)
    //{
    //    string next;

    //    if(isRight)
    //    {
    //        for(int i = 0;i < StageMap.Column.Length;i++)
    //        {
    //            if(current == StageMap.Column[i])
    //            {
    //                next = StageMap.Column[i + 1];
    //            }
    //        }
    //    }

    //    return next;
    //}
    

    /*--------------------------------値の取得-------------------------------------------------*/

    /// <summary>
    ///  マップインデックスの取得
    /// </summary>
    /// <returns></returns>
    private MapIndex GetMapIndex()
    {
        int rand = GetRand(mapIndex.Count);
        MapIndex index = mapIndex[rand];
        mapIndex.RemoveAt(rand);
        return index;
    }

    /// <summary>
    /// 役職の取得
    /// </summary>
    /// <param name="actorNumber">Photonローカルプレイヤーのアクターナンバー</param>
    /// <returns></returns>
    public bool[] GetJob(int actorNumber)
    {
        foreach(var j in playerJobs)
        {
            Debug.Log(j);
        }

        int num = actorNumber - 1;
        return playerJobs;
    }

    /// <summary>
    /// プレイヤーの座標を取得
    /// </summary>
    /// <param name="actorNumber"></param>
    /// <returns></returns>
    public MapIndex GetPlayerPosition(int actorNumber)
    {
        return playerPosition[actorNumber];
    }

    //private Dictionary<string, Player> players;
    //private Map map;
    //private Result result;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    // マップの生成
    //    CreateMap();
    //    // プレイヤーの生成
    //    CreatePlayer();
    //}

    ///// <summary>
    ///// マップの生成
    ///// </summary>
    //private void CreateMap()
    //{
    //    GameObject prefab = (GameObject)Resources.Load("Map");
    //    GameObject obj = Instantiate(prefab);
    //    obj.transform.SetParent(transform);
    //    map = GetComponent<Map>();
    //}

    ///// <summary>
    ///// プレイヤーの生成
    ///// </summary>
    //private void CreatePlayer()
    //{
    //    players = new Dictionary<string, Player>();
    //    foreach (var player in PhotonNetwork.PlayerList)
    //    {
    //        AddPlayer(player);
    //    }
    //    // プレイヤーの初期化
    //    InitializePlayer();
    //}

    //private void AddPlayer(Photon.Realtime.Player player)
    //{
    //    // プレイヤーオブジェクトの生成
    //    GameObject prefab = (GameObject)Resources.Load("Player");
    //    GameObject obj = Instantiate(prefab);
    //    // プレイヤーをネットワークオブジェクトの子要素に追加
    //    obj.transform.SetParent(transform);
    //    // オブジェクト名をプレイヤー名に変更
    //    obj.name = player.NickName;
    //    // プレイヤースクリプトの取得
    //    Player p = obj.GetComponent<Player>();
    //    // プレイヤーをディクショナリに登録
    //    string nickName = player.NickName;
    //    players.Add(nickName, p);
    //}

    ///// <summary>
    ///// プレイヤーの初期化
    ///// </summary>
    //private void InitializePlayer()
    //{
    //    // 役職の設定
    //    InitializeJob();

    //}

    ///// <summary>
    ///// プレイヤーの役職を設定
    ///// </summary>
    //private void InitializeJob()
    //{
    //    List<bool> jobs;
    //    // 配列を全て青年で初期化
    //    jobs = new List<bool>();
    //    for (int i = 0; i < players.Count; i++)
    //    {
    //        jobs[i] = false;
    //    }
    //    // 乱数の取得
    //    int rand = CheckMax(GetRand());
    //    // 乱数の配列を憑人に変更
    //    jobs[rand] = true;

    //    // プレイヤーに設定
    //    int index = 0;
    //    foreach(var player in players)
    //    {
    //        player.Value.IsHaunted = jobs[index];
    //        index++;
    //    }
    //}

    ///// <summary>
    ///// 役職用の乱数を取得
    ///// </summary>
    ///// <returns></returns>
    //private int GetRand()
    //{
    //    float min = 0.0f;
    //    float max = Mathf.Floor(MatchingScene.MaxPlayer);
    //    return (int)Random.Range(min, max);
    //}

    ///// <summary>
    ///// 役職の乱数が最大値か調べる
    ///// </summary>
    ///// <param name="rand"></param>
    //private int CheckMax(int rand)
    //{
    //    if (rand >= MatchingScene.MaxPlayer)
    //    {
    //        return MatchingScene.MaxPlayer - 1;
    //    }
    //    return rand;
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    ///// <summary>
    ///// 全体の結果を設定
    ///// </summary>
    //private void SetResult()
    //{
    //    CheckDeads();
    //    CheckGoals();
    //    CheckGetItem();
    //    CheckWinner();
    //}

    ///// <summary>
    ///// 死亡者を調べる
    ///// </summary>
    //private void CheckDeads()
    //{
    //    result.deadNames = new List<string>();
    //    foreach(var player in players)
    //    {
    //        if (!player.Value.IsDead()) continue;
    //        result.deadNames.Add(player.Key);
    //    }
    //}

    ///// <summary>
    ///// 脱出者を調べる
    ///// </summary>
    //private void CheckGoals()
    //{
    //    result.goalNames = new List<string>();
    //    foreach(var player in players)
    //    {
    //        if (!player.Value.IsGoal()) continue;
    //        result.goalNames.Add(player.Key);
    //    }
    //}

    ///// <summary>
    ///// アイテムを取得したプレイヤーがいるか調べる
    ///// </summary>
    //private void CheckGetItem()
    //{
    //    result.isGetItem = false;
    //    foreach(var player in players)
    //    {
    //        if (player.Value.GetItemKind() == ItemKind.None) continue;
    //        result.isGetItem = true;
    //    }
    //}

    ///// <summary>
    ///// 勝者の設定
    ///// </summary>
    //private void CheckWinner()
    //{
    //    result.winer = WinType.None;
    //}

    //public Player GetPlayer(string nickName)
    //{
    //    return players[nickName];
    //}

    //public Result GetResult()
    //{
    //    SetResult();
    //    return result;
    //}

}
