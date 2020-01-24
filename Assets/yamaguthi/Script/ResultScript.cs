using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScript : MonoBehaviour
{
    public GameObject Master;
    GameObject[] Player;
    Player[] playerSr;
    int num = 0;
    text goal;
    // Start is called before the first frame update
    void Start()
    {
        Player = Master.GetComponent<MasterScriot>().GetPlayer();
        for(int i=0;i< Player.Length;i++)
        {
            playerSr[i] = Player[i].GetComponent<Player>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResultON()
    {
        for (int i = 0; i < Player.Length; i++)
        {
            if (!playerSr[i].IsDropOut())
            {
                if (playerSr[i].IsDead())
                {
                    // プレイヤーnum死亡
                }
                else if (playerSr[num].IsGoal())
                {
                    // プレイヤーnumゴール
                }
            }
        }
    }
}
