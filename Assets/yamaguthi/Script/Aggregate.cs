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

    }
    public void AggregateON()
    {
        players = master.GetPlayer();
        for (int i = 0; i < players.Length; i++)
        {
            player[i] = players[i].GetComponent<Player>();
        }
        GoalPlayer();
        DeadPlayer();
        GetPlayerItem();
    }
    public void GetPlayerItem()
    {
        List<GameObject> savePlayers= new List<GameObject>();
        List<string> savePos =new List<string>();
        List<MapIndex> saveIndex = new List<MapIndex>();
        Dictionary<string, Chip>[] savePlayerIndex = new Dictionary<string, Chip>[5];
        saveIndex = map.GetItemPostion();
        for (int i=0;i<players.Length;i++)
        {
            if(!player[i].IsDropOut()&& !player[i].IsDead()&& !player[i].IsGoal())
            {
                if(player[i].IsFoot())
                {
                    for (int j = 0; j < saveIndex.Count; j++)
                    {
                        GameObject chip = GameObject.Find(saveIndex[j].row+saveIndex[j].column);
                        if (master.CheckPosition(player[i].GetPotision(), saveIndex[j])&& chip.GetComponent<Chip>().GetItem().GetKind()!=ItemKind.None)
                        {
                            player[i].SetItem(true);
                            player[i].SetTake(true);
                            player[i].SetItemKind(chip.GetComponent<Chip>().GetItem().GetKind());
                            chip.GetComponent<Chip>().SetItem(ItemKind.None);
                            break;
                        }
                    }                   
                }
            }
        }
    }
    public void DeadPlayer()
    {
        MapIndex hassyaku =new MapIndex();
        for (int i = 0; i < players.Length; i++)
        {
            if (!player[i].IsDropOut() && !player[i].IsGoal())
            {
                if(master.CheckPosition(player[i].GetPotision(), hassyaku))
                {
                    player[i].SetDead(true);
                }
            }
        }
    }
    public void GoalPlayer()
    {
        MapIndex Goal = new MapIndex();
        for (int i = 0; i < players.Length; i++)
        {
            if (!player[i].IsDropOut() && !player[i].IsDead())
            {
                if (master.CheckPosition(player[i].GetPotision(), Goal))
                {
                    player[i].SetGoal(true);
                }
            }
        }
    }
}
