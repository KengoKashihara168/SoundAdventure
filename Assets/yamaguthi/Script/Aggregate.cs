using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggregate : MonoBehaviour
{
    [SerializeField] MasterScriot master;
    [SerializeField] GameObject map;
    [SerializeField] Hassyakusama hassyaku;
    GameObject[] players;
    Player[] player;
    bool isGoal;
    // Start is called before the first frame update
    void Start()
    {
        isGoal = false;
    }
    public void AggregateON()
    {
        
        players = master.GetPlayer();
        player = new Player[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            player[i] = players[i].GetComponent<Player>();
        }
        if (!hassyaku.GetRelease())
        {
            ReleaseHssyaku();
        }
        else
        {
            hassyaku.MoveDirection();
        }
        Debug.Log("八尺は" + hassyaku.GetPosition().row + hassyaku.GetPosition().column);
        DeadPlayer();
        GetPlayerItem();
        GoalPlayer();
    }
    public void GetPlayerItem()
    {
        List<GameObject> savePlayers= new List<GameObject>();
        List<string> savePos =new List<string>();
        map.GetComponent<StageMap>().ItemChip();
        List<MapIndex> saveIndex = map.GetComponent<StageMap>().GetItemPostion();
        Debug.Log(map.GetComponent<StageMap>().GetItemPostion());
        Dictionary<string, Chip>[] savePlayerIndex = new Dictionary<string, Chip>[5];
        //saveIndex = map.GetItemPostion();
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
                            if(chip.GetComponent<Chip>().GetItem().GetKind() == ItemKind.Sword)
                            {
                                if(!player[i].IsHaunted() && !isGoal)
                                {
                                    if ((player[i].GetItemKind() == ItemKind.Key || player[i].GetItemKind() == ItemKind.Cutter))
                                    {
                                        player[i].SetItemKind(ItemKind.None);
                                        isGoal = true;
                                        Debug.Log("開く");
                                    }
                                }


                            }
                            else
                            {
                                if (player[i].GetItemKind()!=ItemKind.None)
                                {
                                    Item item = map.GetComponent<StageMap>().CheckItem(player[i].GetItemKind());
                                    player[i].SetItemKind(chip.GetComponent<Chip>().GetItem().GetKind());
                                    chip.GetComponent<Chip>().SetItem(item.GetKind());
                                    chip.GetComponent<Chip>().SetAduio(item.GetAudio());
                                }
                                else
                                {
                                    player[i].SetItem(true);
                                    player[i].SetTake(true);
                                    player[i].SetItemKind(chip.GetComponent<Chip>().GetItem().GetKind());
                                    chip.GetComponent<Chip>().SetItem(ItemKind.None);
                                }
                            }
                        }
                    }                   
                }
            }
        }
    }
    public void DeadPlayer()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (!player[i].IsDropOut() && !player[i].IsGoal()&& !player[i].IsHaunted())
            {
                if(master.CheckPosition(player[i].GetPotision(), hassyaku.GetPosition()))
                {
                    player[i].SetDead(true);
                }
            }
        }
    }
    public void GoalPlayer()
    {
        List<MapIndex> saveIndex = map.GetComponent<StageMap>().GetItemPostion();
        if (isGoal)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (!player[i].IsHaunted())
                {
                    if (!player[i].IsDropOut() && !player[i].IsDead())
                    {

                        for (int j = 0; j < saveIndex.Count; j++)
                        {
                            GameObject chip = GameObject.Find(saveIndex[j].row + saveIndex[j].column);
                            if (chip.GetComponent<Chip>().GetItem().GetKind() == ItemKind.Sword)
                            {
                                if (master.CheckPosition(player[i].GetPotision(), chip.GetComponent<Chip>().GetMapindex()))
                                {
                                    player[i].SetGoal(true);
                                }
                            }

                        }

                    }
                }
            }
        }
      
    }
    public void ReleaseHssyaku()
    {
        for(int i=0;i< player.Length;i++)
        {
            if(player[i].IsHaunted()&& master.CheckPosition(player[i].GetPotision(), hassyaku.GetPosition()))
            {
                hassyaku.SetRelease(true);
            }
        }
    }
}
