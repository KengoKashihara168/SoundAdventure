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
    protected ItemKind kind;
    private MapIndex position;
    private AudioScene sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioScene>();
        position.SetIndex(0, "A");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(MapIndex index)
    {
        position.SetIndex(index.row,index.column);
        transform.position = StageMap.ConvertToVector(index);
    }

    public MapIndex GetPosition()
    {
        return position;
    }
}
