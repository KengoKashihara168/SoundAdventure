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
    public ItemKind kind
    {
        get;
        protected set;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check()
    {
        Debug.Log(kind);
    }
}
