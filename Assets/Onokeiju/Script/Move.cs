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
    [SerializeField] Activ activ;

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
        MapIndex pos =new MapIndex();
        if (activ.GetUseSwrod())
        {
            pos = activ.GetoldPostion();
        }
        else
        {
            pos = masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision();
        }
        int row = pos.row - 1;
        if ((row >= 0))
        {
            activUI.SetActive(true);
            colorChange.Color(pos.row - 1, pos.column);
        }
        else
        {
            Debug.Log("通れない");
            colorChange.Color(pos.row , pos.column);
            activUI.SetActive(false);
        }
    }


    public void MoveSouth()
    {

        direction = Direction.South;
        MapIndex pos = new MapIndex();
        if (activ.GetUseSwrod())
        {
            pos = activ.GetoldPostion();
        }
        else
        {
            pos = masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision();
        }
        int row = pos.row + 1;
        if ((row <= 4))
        {
            activUI.SetActive(true);
            colorChange.Color(pos.row + 1, pos.column);
        }
        else
        {
            colorChange.Color(pos.row, pos.column);
            Debug.Log("通れない");
            activUI.SetActive(false);
        }
    }
    public void MoveWest()
    {
        MapIndex pos = new MapIndex();
        if (activ.GetUseSwrod())
        {
            pos = activ.GetoldPostion();
        }
        else
        {
            pos = masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision();
        }
        direction = Direction.West;
        int ascil =pos.column.ToCharArray()[0];
        ascil -= 1;
        char charr = (char)ascil;
        if((ascil-65 >= 0))
        {
            Debug.Log("通る");
            activUI.SetActive(true);
            colorChange.Color(pos.row, charr.ToString());
        }
        else
        {
            Debug.Log("通れない");
            colorChange.Color(pos.row, pos.column);
            activUI.SetActive(false);
        }
    }
    public void MoveEast()
    {

        MapIndex pos = new MapIndex();
        if (activ.GetUseSwrod())
        {
            pos = activ.GetoldPostion();
        }
        else
        {
            pos = masterScriot.GetPlayer()[masterScriot.GetNowPlayer()].GetComponent<Player>().GetPotision();
        }
        direction = Direction.East;
        int ascil = pos.column.ToCharArray()[0];
        ascil += 1;
        char charr = (char)ascil;
        if ((ascil - 65 <= 4))
        {
            Debug.Log("通る");
            activUI.SetActive(true);
            colorChange.Color(pos.row, charr.ToString());
        }
        else
        {
            Debug.Log("通れない");
            colorChange.Color(pos.row, pos.column);
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