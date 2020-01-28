using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Move : MonoBehaviour
{
    bool kill;
    public Player player;
    Direction direction;

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
    }


    public void MoveSouth()
    {

        direction = Direction.South;

    }
    public void MoveWest()
    {

        direction = Direction.West;

    }
    public void MoveEast()
    {

        direction = Direction.East;

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