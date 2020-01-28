using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggregate : MonoBehaviour
{
    [SerializeField] MasterScriot master;
    [SerializeField] StageMap map;
    GameObject[] players;
    Player[] player;
    // Start is called before the first frame update
    void Start()
    {
        players = master.GetPlayer();
        for (int i = 0; i < players.Length; i++)
        {
            player[i] = players[i].GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetPlayerItem()
    {
        List<GameObject> savePlayers= new List<GameObject>();
        List<string> savePos =new List<string>();
        List<MapIndex> saveIndex = new List<MapIndex>();
        saveIndex = map.GetItemPostion();
        for (int i=0;i<players.Length;i++)
        {
            if(!player[i].IsDropOut())
            {
                if(player[i].IsFoot())
                {
                    savePos.Add(players[i].GetComponent<Player>().GetPotision().row.ToString() + players[i].GetComponent<Player>().GetPotision().column.ToString());
                }
            }
        }
        for(int i = 0; i < savePos.Count; i++)
        {
            if (savePos.Contains(saveIndex[i].ToString()))
            {

            }
        }
    }
}
