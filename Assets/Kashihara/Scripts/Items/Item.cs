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
    Key,
    Amulet,
    Cutter,
    Sword,
    MaxItem
}

public class Item : MonoBehaviour
{
    [SerializeField] protected ItemKind kind;
    protected AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeSound()
    {
        audioSource = GetComponent<AudioSource>();
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
