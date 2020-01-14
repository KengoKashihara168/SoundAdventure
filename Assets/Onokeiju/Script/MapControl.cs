using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    private static MapControl instance;
    private static Map map; // プレイヤーたち

    /// <summary>
    /// インスタンス
    /// </summary>
    public static MapControl Instance
    {
        get
        {
            instance = FindObjectOfType<MapControl>();

            if (instance == null)
            {
                GameObject obj = new GameObject("MapControl");
                instance = obj.AddComponent<MapControl>();
                DontDestroyOnLoad(instance);
                InitializeMap();


            }
            return instance;
        }

        set { }
    }

    private static void InitializeMap()
    {

        GameObject obj = new GameObject("Player");

        map = obj.AddComponent<Map>();
        for (int i = 0; i > 25; i++)
        {
            // 各プレイヤーの初期化
            map.Setaudio(i, null);

        }
    }



    public void SetAudio(int num, AudioSource audio)
    {
        map.Setaudio(num, audio);
    }


    public int GetPosition(int num)
    {
        return map.Getpos();
    }
    public AudioSource GetAudio(int num)
    {
        return map.Getaudio(num);
    }
}

