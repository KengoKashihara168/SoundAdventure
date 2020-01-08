using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private StageMap map;

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
        MapIndex index = map.GetPosition();
        row            = index.row;
        column         = index.column;
        item           = null;
        isGoal         = false;
        isDead         = false;
        isHaunted      = false;
    }

    public void MoveAction(Direction dir)
    {

    }

    public void KillAction(bool isKill,Direction dir)
    {

    }

    public void ItemAction(bool isGet)
    {

    }
}
