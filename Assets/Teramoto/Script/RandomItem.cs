﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムの設定と音の設定1
public class RandomItem : MonoBehaviour
{
    int MAP_HEIGHT = 5;
    int MAP_WIDTH  = 5;

    int x, y;

    bool IsDicision;

    //リストに数値を入れる。
    List<int> posListX = new List<int>();
    //リストに数値を入れる。
    List<int> posListY = new List<int>();


    int point;
    //リストに数値を入れる。
    List<int> itemList = new List<int>();

    //リストに数値を入れる。
    List<int> itemSoundList = new List<int>();

    //音を入れる
    //リストに数値を入れる。
    List<AudioClip> soundList = new List<AudioClip>();

    [SerializeField]
    private AudioClip sound1;
    [SerializeField]
    private AudioClip sound2;
    [SerializeField]
    private AudioClip sound3;
    [SerializeField]
    private AudioClip sound4;

    private AudioClip audioClip = null;


    ItemKind itemkind = ItemKind.None;
    [SerializeField]
    StageMap stageMap; 
    // Start is called before the first frame update
    void Start()
    {
        IsDicision = false;
        for(int i = 0;i < 4;i++)
        {
            itemList.Add(i);
            itemSoundList.Add(i);
        }

        {
            soundList.Add(sound1);
            soundList.Add(sound2);
            soundList.Add(sound3);
            soundList.Add(sound4);

        }

        print(soundList);
        print(itemList);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDicision)
        {

           for(int i=0;i<4;i++)
            {

                //アイテムの設定
                SettingItem();
                SettingItemSound();

                //確認用表示
                print("item=" + itemkind);
                print("soundCrip=" + audioClip);

                //ItemInfoの追加
                stageMap.SetItemInfo(itemkind, audioClip);


                itemkind = ItemKind.None;
                audioClip = null;

                point += 1;
            }

            //回した回数が4かいだったら止める
            if (point >= 4)
            {
                IsDicision = true;
            }

        }

    }


    void SettingItemSound()
    {
        //乱数決め
        int index = UnityEngine.Random.Range(0, itemSoundList.Count);
        //配列に乱数を入れる。
        int ransu = itemSoundList[index];
        //要素削除
        itemSoundList.RemoveAt(index);

        //乱数を回す
        soundRoulette(ransu);

    }

    private void soundRoulette(int ransu)
    {
        switch (ransu)
        {
            case 0:
                audioClip = soundList[0];
                print(audioClip);
                break;

            case 1:
                audioClip = soundList[1];
                print(audioClip);

                break;

            case 2:
                audioClip = soundList[2];
                print(audioClip);

                break;

            case 3:
                audioClip = soundList[3];
                print(audioClip);

                break;



            default:
                print("バグです");
                break;
        }
    }

    //アイテムと音の設定
    void SettingItem()
    {

        //乱数決め
        int index = UnityEngine.Random.Range(0, itemList.Count);
        //配列に乱数を入れる。
        int ransu = itemList[index];
        //要素削除
        itemList.RemoveAt(index);

        //乱数を回す
        itemRulette(ransu);
    }

    private void itemRulette(int ransu)
    {
        switch (ransu)
        {
            case 0:
                print("鍵");
                itemkind = ItemKind.Key;
                break;

            case 1:
                print("チェーンソー");
                itemkind = ItemKind.Cutter;

                break;

            case 2:
                print("刀");
                itemkind = ItemKind.Sword;

                break;

            case 3:
                print("塩");
                itemkind = ItemKind.Amulet;
                break;



            default:
                print("バグです");
                break;
        }
    }
}