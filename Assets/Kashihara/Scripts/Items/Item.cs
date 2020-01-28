using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemInfo
{
    public MapIndex position; // 座標
    public AudioClip audio;   // 音
    public ItemKind  kind;   // 名前
}

public enum ItemKind
{
    None,
    Key,
    Amulet,
    Cutter,
    Sword,
}

public class Item : MonoBehaviour
{
    [SerializeField] private ItemKind kind;

    private ItemInfo info;

    // Start is called before the first frame update
    void Start()
    {
        info = new ItemInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // アイテムの情報の設定
    public void SetInfo(ItemKind kind,AudioClip audio)
    {
        info.kind = kind;
        info.audio = audio;
    }
    // アイテムの名前を取得設定
    public ItemKind GetKind()
    {
        return kind;
    }
    public void SetKind(ItemKind kind)
    {
        this.kind= kind;
    }
    // アイテムの情報の取得
    public ItemInfo GetInfo()
    {
        return info;
    }
}
