using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemInfo
{
    public MapIndex position; // 座標
                              // 音
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

    public ItemKind GetKind()
    {
        return kind;
    }
    public void SetKind(ItemKind kind)
    {
        this.kind= kind;
    }
    public ItemInfo GetInfo(ItemKind kind)
    {
        return info;
    }
}
