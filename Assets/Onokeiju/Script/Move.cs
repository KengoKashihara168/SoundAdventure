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
    [SerializeField] GameObject activUI;

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
        int row = masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().row - 1;
        if ((row >= 0))
        {
            activUI.SetActive(true);
            colorChange.Color(masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().row - 1, masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().column);
        }
        else
        {
            colorChange.Color(masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().row , masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().column);
            activUI.SetActive(false);
        }
    }


    public void MoveSouth()
    {

        direction = Direction.South;
        int row = masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().row + 1;
        if ((row <= 4))
        {
            activUI.SetActive(true);
            colorChange.Color(masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().row + 1, masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().column);
        }
        else
        {
            colorChange.Color(masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().row, masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().column);
            activUI.SetActive(false);
        }
    }
    public void MoveWest()
    {
        direction = Direction.West;
        int ascil =masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().column.ToCharArray()[0];
        ascil -= 1;
        char charr = (char)ascil;
        if((ascil-65 >= 0))
        {
            Debug.Log("通る");
            activUI.SetActive(true);
            colorChange.Color(masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().row, charr.ToString());
        }
        else
        {
            colorChange.Color(masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().row, masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().column);
            activUI.SetActive(false);
        }
    }
    public void MoveEast()
    {

        direction = Direction.East;
        int ascil = masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().column.ToCharArray()[0];
        ascil += 1;
        char charr = (char)ascil;
        if ((ascil - 65 <= 4))
        {
            Debug.Log("通る");
            activUI.SetActive(true);
            colorChange.Color(masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().row, charr.ToString());
        }
        else
        {
            colorChange.Color(masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().row, masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision().column);
            activUI.SetActive(false);
        }
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