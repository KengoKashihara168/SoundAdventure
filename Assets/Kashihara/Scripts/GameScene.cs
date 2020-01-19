using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

using UnityEngine.UI;
using ExitGames.Client.Photon;

public class GameScene : MonoBehaviourPunCallbacks
{
    [SerializeField] private JobScreen jobScreen;
    [SerializeField] private SoundScreen soundScreen;
    [SerializeField] private MoveScreen moveScreen;
    private Player player;
    private List<Item> items;
    private Goal goal;
    private Hassyaku hassyaku;

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
        // アイテムの生成
        CreateItem();
        // ゴールの生成
        CreateGoal();
        // 八尺様の生成
        CreateHassyaku();

        OpenMoveScreen();
    }

    private void CreatePlayer()
    {
        MapIndex index = GetRandomIndex();
        Debug.Log(index.row.ToString() + index.column);
        Vector3 pos = StageMap.IndexToVector(index);
        GameObject obj = PhotonNetwork.Instantiate("Player", pos, Quaternion.identity);
        player = obj.GetComponent<Player>();

        if(PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            player.isHaunted = true;
        }
        else
        {
            player.isHaunted = false;
        }

        SetPlayerData();
    }

    private void SetPlayerData()
    {
        // 座標の設定
        var hashtable = new ExitGames.Client.Photon.Hashtable();
        hashtable["PlayerPos"] = player.GetPosition();
        PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);
        // 職種の設定
        hashtable["PlayerJob"] = player.isHaunted;
        PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);
    }

    private void CreateItem()
    {
        items = new List<Item>();
        SetItem((ItemKind)PhotonNetwork.LocalPlayer.ActorNumber - 1);
        foreach(Item item in items)
        {
            item.InitializeSound();
        }
    }

    private void SetItem(ItemKind kind)
    {
        MapIndex index = GetRandomIndex();
        Vector3 pos = StageMap.IndexToVector(index);
        GameObject obj;
        switch(kind)
        {
            case ItemKind.Amulet:
                obj = PhotonNetwork.Instantiate("Amulet", pos, Quaternion.identity);
                items.Add(obj.GetComponent<Amulet>());
                break;
            case ItemKind.Cutter:
                obj = PhotonNetwork.Instantiate("Cutter", pos, Quaternion.identity);
                items.Add(obj.GetComponent<Cutter>());
                break;
            case ItemKind.Key:
                obj = PhotonNetwork.Instantiate("Key", pos, Quaternion.identity);
                items.Add(obj.GetComponent<Key>());
                break;
            case ItemKind.Sword:
                obj = PhotonNetwork.Instantiate("Sword", pos, Quaternion.identity);
                items.Add(obj.GetComponent<Sword>());
                break;
        }
    }

    private void CreateGoal()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber != 1) return;
        MapIndex index = GetRandomIndex();
        Vector3 pos = StageMap.IndexToVector(index);
        GameObject obj = PhotonNetwork.Instantiate("Goal", pos, Quaternion.identity);
        goal = obj.GetComponent<Goal>();
    }

    private void CreateHassyaku()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber != 2) return;
        MapIndex index = GetRandomIndex();
        Vector3 pos = StageMap.IndexToVector(index);
        GameObject obj = PhotonNetwork.Instantiate("Hassyaku", pos, Quaternion.identity);
        hassyaku = obj.GetComponent<Hassyaku>();
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

    private void OpenJobScreen()
    { 
        jobScreen.SetJobSprite(player.isHaunted);
    }

    public void OpenSoundScreen()
    {
        Item nearItem = GetNearItem();
        if (nearItem == null) return;
        nearItem.PlaySound();
    }

    public void OpenMoveScreen()
    {
        MapIndex index = StageMap.VectorToIndex(player.GetPosition());
        moveScreen.OpenScreen(index);
    }

    private Item GetNearItem()
    {
        float distance = 99999.0f;
        Item nearItem = null;
        Vector3 playerPos = player.transform.position;
        Vector3 itemPos;
        foreach(var item in items)
        {
            itemPos = item.transform.position;
            float toItem = (playerPos - itemPos).magnitude;
            if(toItem < distance)
            {
                if(toItem < StageMap.ChipDistance * 2)
                {
                    nearItem = item;
                }
            }
        }

        return nearItem;
    }

    public void StopSound()
    {
        Item nearItem = GetNearItem();
        nearItem.StopSound();
    }
}
