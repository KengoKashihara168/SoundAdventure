using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    // メンバ変数
    [SerializeField] JobScreen jobScreen;
    [SerializeField] DefaultScreen defaultScreen;
    [SerializeField] SoundScreen soundScreen;
    [SerializeField] MoveScreen moveScreen;
    [SerializeField] UseScreen useScreen;
    [SerializeField] GetScreen getScreen;
    [SerializeField] PrivateResult privateResult;

    private ScreenType currentScreen;

    private MapIndex position;  // 座標
    private ItemKind item;      // 所持アイテム
    public bool isGoal { get; private set; }    // 脱出フラグ
    public bool isDead { get; private set; }    // 死亡フラグ
    public bool isHaunted { get; private set; } // 憑人フラグ
    private Action   action;    // プレイヤーの行動

    private void Awake()
    {
        // メンバ変数の初期化
        currentScreen = ScreenType.Job;
        position.SetIndex(0, "A");
        item = ItemKind.MaxItem;
        isGoal = false;
        isDead = false;
        isHaunted = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Job();
    }

    public void Job()
    {
        jobScreen.OpenScreen(isHaunted);
    }

    public void Default()
    {
        AllCloseScreen();
        defaultScreen.OpenScreen(isHaunted, position,item);
    }

    public void Sound(Item item)
    {
        AllCloseScreen();
        soundScreen.OpenScreen(item);
    }

    public void Move()
    {
        AllCloseScreen();
        moveScreen.OpenScreen(position);
    }

    public bool Use()
    {
        if (item != ItemKind.Sword) return false;
        AllCloseScreen();
        useScreen.OpenScreen();
        return true;
    }

    public bool Get(ItemKind kind)
    {
        if (kind == ItemKind.MaxItem) return false;
        AllCloseScreen();
        getScreen.OpenScreen(kind);
        return true;
    }

    public void Private()
    {
        AllCloseScreen();
        privateResult.OpenScreen(GetComponent<Player>());
    }

    public void SetPosition(MapIndex index)
    {
        position = index;
        transform.position = StageMap.IndexToVector(index);
        Debug.Log("Player = " + index.row.ToString() + index.column);
    }

    public void Haunted()
    {
        isHaunted = true;
    }

    public void SetItem(ItemKind getItem)
    {
        item = getItem;
    }

    public void Dead()
    {
        isDead = true;
    }

    public void Goal()
    {
        isGoal = true;
    }

    public ItemKind GetItemKind()
    {
        return item;
    }

    public MapIndex GetNextPosition()
    {
        return moveScreen.GetNextMove();
    }

    public bool GetIsUse()
    {
        return useScreen.IsUse();
    }

    public bool GetIsGet()
    {
        return getScreen.IsGet();
    }

    public void AllCloseScreen()
    {
        jobScreen.CloseScreen();
        defaultScreen.CloseScreen();
        soundScreen.CloseScreen();
        moveScreen.CloseScreen();
        useScreen.CloseScreen();
        getScreen.CloseScreen();
        privateResult.CloseScreen();
    }

}
