using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScriot : MonoBehaviour
{
    public GameObject[] Player;
    int nowPlayer;
    // Start is called before the first frame update
    void Start()
    {
        nowPlayer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject[] GetPlayer()
    {
        return Player;
    }
    public int GetNowPlayer()
    {
        return nowPlayer;
    }
    public void ResetNowPlayer()
    {
        nowPlayer = 0;
    }
    public void AddNowPlayer()
    {
        nowPlayer++;
    }
}
