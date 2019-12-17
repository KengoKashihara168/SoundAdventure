using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static  PlayerController instance;
    private static  Player[]         players;               // プレイヤーたち
    private static  int              TurnCount{ get; set; } // 現在のターン数
    private static Vector2           position { get; set; } // 座標
    private static Chip[]            nextChips;             // 次に移動できるマス
    private static Chip              currentChip;

    /// <summary>
    /// インスタンス
    /// </summary>
    public static PlayerController Instance
    {
        get
        {
            instance = FindObjectOfType<PlayerController>();

            if (instance == null)
            {
                IniTialize();
            }
            return instance;
        }

        set { }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private static void IniTialize()
    {
        GameObject obj = new GameObject("PlayerController");
        instance = obj.AddComponent<PlayerController>();
        DontDestroyOnLoad(instance);
        // プレイヤーの初期化
        InitializePlayer();
        position    = new Vector2(); // 座標の初期化
        nextChips   = new Chip[4];   // 移動できるマスの初期化
        currentChip = new Chip();    // 現在のマスの初期化
    }

    /// <summary>
    /// プレイヤーの初期化
    /// </summary>
    private static void InitializePlayer()
    {
        players = new Player[(int)PlayerNum.MaxPlayer];
        GameObject obj = new GameObject("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = obj.AddComponent<Player>();
            players[i].Initialize();
        }
    }

    /// <summary>
    /// プレイヤーの種類を取得
    /// </summary>
    /// <param name="num">プレイヤーの添え字</param>
    /// <returns>プレイヤーの種類</returns>
    public PlayerType GetType(int num)
    {
        return players[num].playerType;
    }
    /// <summary>
    /// プレイヤーの種類を取得
    /// </summary>
    /// <param name="num">プレイヤー番号</param>
    /// <returns>プレイヤーの種類</returns>
    public PlayerType GetType(PlayerNum num)
    {
        return players[(int)num].playerType;
    }

    /// <summary>
    /// プレイヤーの方角を取得
    /// </summary>
    /// <param name="num">プレイヤーの添え字</param>
    /// <returns>方角</returns>
    public Direction GetDirection(int num)
    {
        return players[num].direction;
    }
    /// <summary>
    /// プレイヤーの方角を取得
    /// </summary>
    /// <param name="num">プレイヤー番号</param>
    /// <returns>方角</returns>
    public Direction GetDirection(PlayerNum num)
    {
        return players[(int)num].direction;
    }


    /// <summary>
    /// 現在のターン数を取得
    /// </summary>
    /// <returns></returns>
    public int GetCurrentTurn()
    {
        return TurnCount;
    }

    /// <summary>
    /// ターン数の増加
    /// </summary>
    public void IncrimentTurn()
    {
        TurnCount++;
    }

    /// <summary>
    /// ターン数の初期化
    /// </summary>
    private void InitializeTurn()
    {
        TurnCount = 0;
    }
}
