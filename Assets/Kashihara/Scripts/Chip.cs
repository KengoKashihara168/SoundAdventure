﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private Image image;
    MapIndex pos;

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
        pos.row = row;
        pos.column = column;
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

    // チップの音の設定
    public void SetAduio(AudioClip audio)
    {
        this.audio = audio;
        this.gameObject.GetComponent<AudioSource>().clip = audio;
    }
    public AudioSource GetAduio()
    {
        return this.gameObject.GetComponent<AudioSource>();
    }

    // アイテムの取得と設定
    public void SetItem(ItemKind kind)
    {
        if (kind == ItemKind.None)
            this.gameObject.GetComponent<AudioSource>().clip = null;
        info.SetKind(kind);
    }
    public Item GetItem()
    {
        return info;
    }

    public MapIndex GetMapindex()
    {
        return pos;
    }

    public void ColorChange()
    {
        this.image.color = new Vector4(1, 1, 1, 1);
    }
}
