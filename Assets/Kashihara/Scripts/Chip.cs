using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChipType
{
    Close,
    Open,
    Jizo,
    Exit,
    Hassyaku,
}

public class Chip : MonoBehaviour
{
    public ChipType type { get; set; }
    private AudioClip audio;
    private Item info;

    // Start is called before the first frame update
    void Start()
    {
        info = new Item();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// オブジェクト名の設定
    /// </summary>
    /// <param name="row">行番号</param>
    /// <param name="column">列番号</param>
    public void SetName(int row, string column)
    {
        // オブジェクト名は行番号 + 列番号
        string name = row.ToString() + column.ToString();
        gameObject.name = name;
    }

    /// <summary>
    /// 座標の設定
    /// </summary>
    /// <param name="pos">座標</param>
    public void SetPosition(Vector3 pos)
    {
        transform.localPosition = pos;
    }

    public void SetAduio(AudioClip audio)
    {
        this.audio = audio;
        this.gameObject.GetComponent<AudioSource>().clip = audio;
    }
    public AudioSource GetAduio()
    {
        return this.gameObject.GetComponent<AudioSource>();
    }


    public void SetItem(ItemKind kind)
    {
        info.SetKind(kind);
    }
    public Item GetItem()
    {
        return info;
    }
}
