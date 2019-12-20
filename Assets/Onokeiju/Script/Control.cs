using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private static Control instance;
    private static PlayerDT[] players; // プレイヤーたち


    /// <summary>
    /// インスタンス
    /// </summary>
    public static Control Instance
    {
        get
        {
            instance = FindObjectOfType<Control>();

            if (instance == null)
            {
                GameObject obj = new GameObject("PlayerController");
                instance = obj.AddComponent<Control>();
                DontDestroyOnLoad(instance);
                InitializePlayer();
            }
            return instance;
        }

        set { }
    }


    private static void InitializePlayer()
    {
        players = new PlayerDT[(int)PlayerNum.MaxPlayer];
        GameObject obj = new GameObject("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = obj.AddComponent<PlayerDT>();

            // 各プレイヤーの初期化
            players[i].SetPosition(0);
            players[i].playerNum = (PlayerNum)i;
            // players[i].isHuman = true;

        }

  
    }
    /// <summary>
    /// 指定プレイヤーの移動
    /// </summary>
    /// <param name="num">プレイヤー番号</param>
    /// <param name="x">X座標</param>
    /// <param name="y">Y座標</param>
    public void SetPosition(int num, int pos)
    {
        players[num].SetPosition(pos);
    }

    /// <summary>
    /// 指定プレイヤーのX座標を伝える
    /// </summary>
    /// <param name="num">プレイヤー番号</param>
    /// <returns>X座標</returns>
    public int GetPlayerPosition(int num)
    {
        return players[num].GetPos();
    }
 

}