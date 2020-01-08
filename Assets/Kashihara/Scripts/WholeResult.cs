using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholeResult : MonoBehaviour
{
    private string[] deadPlayers; // 死亡したプレイヤー配列
    private string[] goalPlayers; // 脱出したプレイヤー配列
    private bool     isGetItem;   // アイテム獲得フラグ
    private bool     youthWin;    // 青年の勝利フラグ
    private bool     hauntedWin;  // 憑人の勝利フラグ

    // Start is called before the first frame update
    void Start()
    {
        // メンバ変数の初期化
        deadPlayers = new string[4];
        goalPlayers = new string[4];
        isGetItem   = false;
        youthWin    = false;
        hauntedWin  = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 死亡したプレイヤーのリスト
    /// </summary>
    /// <returns>死亡したプレイヤー達</returns>
    public string[] DeadPlayers()
    {
        return deadPlayers;
    }

    /// <summary>
    /// 脱出したプレイヤーのリスト
    /// </summary>
    /// <returns>脱出したプレイヤー達</returns>
    public string[] GoalPlayers()
    {
        return goalPlayers;
    }

    /// <summary>
    /// アイテム獲得者の有無を取得
    /// </summary>
    /// <returns>アイテム獲得者の有無</returns>
    public bool IsGetItem()
    {
        return isGetItem;
    }

    /// <summary>
    /// 青年の勝利か取得
    /// </summary>
    /// <returns>青年の勝利フラグ</returns>
    public bool IsYouthWin()
    {
        return youthWin;
    }

    /// <summary>
    /// 憑人の勝利か取得
    /// </summary>
    /// <returns>憑人の勝利フラグ</returns>
    public bool IsHauntedWin()
    {
        return hauntedWin;
    }
}
