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
<<<<<<< HEAD
    protected ItemKind kind;
    private MapIndex position;
    private AudioScene sound;
=======
    [SerializeField] protected ItemKind kind;
    MapIndex position;
    protected AudioSource audioSource;
>>>>>>> Kashihara_PUN2

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        sound = GetComponent<AudioScene>();
        position.SetIndex(0, "A");
=======
        audioSource = GetComponent<AudioSource>();
>>>>>>> Kashihara_PUN2
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(MapIndex index)
    {
<<<<<<< HEAD
        position.SetIndex(index.row,index.column);
        transform.position = StageMap.ConvertToVector(index);
    }

    public MapIndex GetPosition()
=======
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
>>>>>>> Kashihara_PUN2
    {
        return position;
    }
}
