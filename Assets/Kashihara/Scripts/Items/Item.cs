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
    Amulet,
    Cutter,
    Key,
    Sword,
    MaxItem
}

public class Item : MonoBehaviour
{
    [SerializeField] protected ItemKind kind;
    MapIndex position;
    protected AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(MapIndex index)
    {
        position = index;
        transform.position = StageMap.IndexToVector(index);
    }

    public void PlaySound()
    {
        audioSource.Play();
    }

    public void StopSound()
    {
        audioSource.Stop();
    }

    public ItemKind GetKind()
    {
        return kind;
    }
}
