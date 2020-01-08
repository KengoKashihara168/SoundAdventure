using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // メンバ変数
    private int    row;       // マップの行番号(Y座標)
    private string column;    // マップの列番号(X座標)
    private Item   item;      // 所持アイテム
    private bool   isGoal;    // 脱出フラグ
    private bool   isDead;    // 死亡フラグ
    private bool   isHaunted; // 憑人フラグ
    private Action action;    // プレイヤーの行動

    // Start is called before the first frame update
    void Start()
    {
        // メンバ変数の初期化
        row            = 0;
        column         = "A";
        item           = null;
        isGoal         = false;
        isDead         = false;
        isHaunted      = false;
    }

    /// <summary>
    /// 進行方向の設定
    /// </summary>
    /// <param name="dir">進行方向</param>
    public void MoveAction(Direction dir)
    {

    }

    /// <summary>
    /// 刀の使用設定
    /// </summary>
    /// <param name="isKill">刀の使用フラグ</param>
    /// <param name="dir">使用する方向</param>
    public void KillAction(bool isKill,Direction dir)
    {

    }

    /// <summary>
    /// アイテムの獲得設定
    /// </summary>
    /// <param name="isGet">アイテムの獲得フラグ</param>
    public void ItemAction(bool isGet)
    {

    }

    /// <summary>
    /// 死亡フラグの取得
    /// </summary>
    /// <returns>死亡フラグ</returns>
    public bool IdDead()
    {
        return isDead;
    }

    /// <summary>
    /// 脱出フラグの取得
    /// </summary>
    /// <returns>脱出フラグ</returns>
    public bool IsGoal()
    {
        return isGoal;
    }

    /// <summary>
    /// アイテム名の取得
    /// </summary>
    /// <returns>アイテム名</returns>
    public string GetItemName()
    {
        if (item == null) return "none";

        return item.name;
    }

    /// <summary>
    /// 八尺様解放フラグの取得
    /// </summary>
    /// <returns>八尺様解放フラグ</returns>
    public bool IsRelease()
    {
        if (!isHaunted) return false;

        return true;
    }

    /// <summary>
    /// 刀の使用結果の取得
    /// </summary>
    /// <returns>刀の使用結果</returns>
    public bool IsKill()
    {
        return false;
    }
}
