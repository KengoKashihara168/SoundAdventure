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
        kill = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


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

    public void MoveDecision()
    {
        player.MoveAction(direction);

    }

    public void SwordDecision()
    {
        player.KillAction(kill, direction);
    }
}