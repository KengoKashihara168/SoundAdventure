using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

using UnityEngine.UI;

public class GameScene : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text text;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        // プレイヤーの生成
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        MapIndex index = GetRandomIndex();
        Vector3 pos = StageMap.IndexToVector(index);
        GameObject obj = PhotonNetwork.Instantiate("Player", pos, Quaternion.identity);
        player = obj.GetComponent<Player>();

        if(PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            player.isHaunted = false;
        }
        else
        {
            player.isHaunted = true;
        }

        text.text = index.row.ToString() + index.column;
    }

    /// <summary>
    /// ランダムなインデックスを取得
    /// </summary>
    /// <returns></returns>
    private MapIndex GetRandomIndex()
    {
        MapIndex index;
        index.row = StageMap.Row[GetRand(4)];
        index.column = StageMap.Column[GetRand(4)];
        return index;
    }

    /// <summary>
    /// ０～rangeの乱数を取得
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    private int GetRand(int range)
    {
        float rand_f = Random.Range(0.0f, range + 1.0f);
        int rand_i = (int)rand_f;
        if (rand_i <= range) return rand_i;
        return rand_i - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeGame()
    {

    }
}
