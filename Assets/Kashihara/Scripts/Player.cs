using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // メンバ変数
    private MapIndex position;         // 座標
    private Item     item;             // 所持アイテム
    private bool     isGoal;           // 脱出フラグ
    private bool     isDead;           // 死亡フラグ
    public bool IsHaunted{ get; set; } // 憑人フラグ
    private Action   action;           // プレイヤーの行動

    private void Awake()
    {
        // メンバ変数の初期化
        position.SetIndex(5, "F");
        item = null;
        isGoal = false;
        isDead = false;
        //CreateItem(ItemKind.Amulet);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialize(int number)
    {
        MapIndex index;
        int rand = Random.Range(0, 5);
        if (rand == 5) rand = 4;
        index.row = StageMap.Row[rand];
        rand = Random.Range(0, 5);
        if (rand == 5) rand = 4;
        index.column = StageMap.Column[rand];
        isGoal = false;
        if(number == 3)
        {
            IsHaunted = true;
        }
    }

    public void SetPosition(MapIndex index)
    {
        if (StageMap.CheckRange(position)) return; // まだポジションが設定されていなければ
        // プレイヤーの座標を設定
        position.SetIndex(index.row,index.column);
    }

    /// <summary>
    /// 進行方向の設定
    /// </summary>
    /// <param name="dir">進行方向</param>
    public void MoveAction(Direction dir)
    {
        Debug.Log(dir);
    }

    /// <summary>
    /// 刀の使用設定
    /// </summary>
    /// <param name="isKill">刀の使用フラグ</param>
    /// <param name="dir">使用する方向</param>
    public void KillAction(bool isKill,Direction dir)
    {
        if (!isKill) return;
        Debug.Log(dir);
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
    public bool IsDead()
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
    /// 八尺様解放フラグの取得
    /// </summary>
    /// <returns>八尺様解放フラグ</returns>
    public bool IsRelease()
    {
        if (!IsHaunted) return false;

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
