using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // メンバ変数
    private MapIndex position;  // 座標
    /*[SerializeField]*/ private Item     item;      // 所持アイテム
    /*[SerializeField]*/ private bool     isItem;    // 所持フラグ
    /*[SerializeField]*/ private bool     isFoot;    // 足元フラグ
    /*[SerializeField]*/ private bool     isGoal;    // 脱出フラグ
    /*[SerializeField]*/ private bool     isDead;    // 死亡フラグ
    /*[SerializeField]*/ private bool     isHaunted; // 憑人フラグ
   /*[SerializeField]*/  private bool     isDropOut; // 脱落フラグ
    private Action   action;    // プレイヤーの行動

    private void Awake()
    {
        // メンバ変数の初期化
        position.SetIndex(1, "A");
        item = null;
        isGoal = false;
        isDead = true;
        isHaunted = false;
        isItem = false;
        isFoot = false;
        isDropOut = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 進行方向の設定
    /// </summary>
    /// <param name="dir">進行方向</param>
    public void MoveAction(Direction dir)
    {
        int ascli;
        char charascli;
        switch (dir)
        {
            case Direction.North:// 北
                position.row -= 1;
                break;
            case Direction.South:// 南
                position.row += 1;
                break;
            case Direction.West:// 西
                 ascli= (int)position.column.ToCharArray()[0];
                ascli -= 1;
                charascli = (char)ascli;
                position.column= charascli.ToString();
                Debug.Log(position.column);
                break;
            case Direction.East:// 東
                 ascli = (int)position.column.ToCharArray()[0];
                ascli += 1;
                charascli = (char)ascli;
                position.column = charascli.ToString();
                Debug.Log(position.column);
                break;
        }
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

    public void SetFoot(bool isfoot)
    {
        isFoot = isfoot;
    }
    public bool GetFoot()
    {
        return isFoot;
    }
    /// <summary>
    /// アイテムの獲得設定
    /// </summary>
    /// <param name="isGet">アイテムの獲得フラグ</param>
    public void ItemAction(bool isGet)
    {
        isItem = isGet;
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
    /// 憑人フラグの取得
    /// </summary>
    /// <returns></returns>
    public bool IsHaunted()
    {
        return isHaunted;
    }
    public void SetHaunted(bool haunted)
    {
        isHaunted = haunted;
    }

    /// <summary>
    /// アイテム名の取得
    /// </summary>
    /// <returns>アイテム名</returns>
    public ItemKind GetItemKind()
    {
        if (item == null) return ItemKind.None;

        return item.GetKind();
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


    /// <summary>
    /// 脱落フラグの取得
    /// </summary>
    /// <returns></returns>
    public bool IsDropOut()
    {
        return isDropOut;
    }
    public void SetDropOut(bool dropOut)
    {
        isDropOut = dropOut;
    }

    public void SetPotision(int row,string column)
    {
        position.SetIndex(row, column);
    }
    public void SetPotision(MapIndex index)
    {
        position.SetIndex(index.row, index.column);
    }
    public MapIndex GetPotision()
    {
        return position;
    }
}
