using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Move : MonoBehaviour
{
    bool kill;
    public Player player;
    Direction direction;
    [SerializeField] ColorChange colorChange;
    [SerializeField] MasterScriot masterScriot;


    // Start is called before the first frame update
    void Start()
    {
        direction = Direction.None;
        kill = true;
    }

    //方向の設定
    public void MoveNorth()
    {
        direction = Direction.North;
        colorChange.Color(masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().row-1, masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().column);
    }


    public void MoveSouth()
    {

        direction = Direction.South;
        colorChange.Color(masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().row + 1, masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().column);
    }
    public void MoveWest()
    {
        direction = Direction.West;
        int ascil =masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().column.ToCharArray()[0];
        ascil -= 1;
        char charr = (char)ascil;
        colorChange.Color(masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().row, charr.ToString());
    }
    public void MoveEast()
    {

        direction = Direction.East;
        int ascil = masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().column.ToCharArray()[0];
        ascil += 1;
        char charr = (char)ascil;
        colorChange.Color(masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().row, charr.ToString());
    }

    //プレイヤーのポジション設定
    public void MoveDecision()
    {
        player.MoveAction(direction);

    }
    //プレイヤーの刀の設定
    public void SwordDecision()
    {
        player.KillAction(kill, direction);
    }
    public Direction GetDirection()
    {
        return direction;
    }
}