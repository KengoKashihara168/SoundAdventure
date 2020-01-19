using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScreen : MonoBehaviour
{
    private MapIndex playerPosition;
    private MapIndex nextPosition;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScreen(MapIndex playerPos)
    {
        gameObject.SetActive(true);
        playerPosition = playerPos;
        Debug.Log(playerPosition.row.ToString() + playerPosition.column);
    }

    public void MoveNorth()
    {
        MapIndex playerPos = playerPosition;
        for(int i = 1;i < StageMap.Row.Length;i++)
        {
            if(playerPosition.row == StageMap.Row[i])
            {
                playerPos.row = StageMap.Row[i - 1];
            }
        }

        nextPosition = playerPos;

        Debug.Log(nextPosition.row.ToString() + nextPosition.column);
    }

    public void MoveSouth()
    {
        MapIndex playerPos = playerPosition;
        for (int i = 0; i < StageMap.Row.Length - 1; i++)
        {
            if (playerPosition.row == StageMap.Row[i])
            {
                playerPos.row = StageMap.Row[i + 1];
            }
        }

        nextPosition = playerPos;

        Debug.Log(nextPosition.row.ToString() + nextPosition.column);
    }

    public void MoveEast()
    {
        MapIndex playerPos = playerPosition;
        for (int i = 0; i < StageMap.Column.Length - 1; i++)
        {
            if (playerPosition.column == StageMap.Column[i])
            {
                playerPos.column = StageMap.Column[i + 1];
            }
        }

        nextPosition = playerPos;

        Debug.Log(nextPosition.row.ToString() + nextPosition.column);
    }

    public void MoveWest()
    {
        MapIndex playerPos = playerPosition;
        for (int i = 1; i < StageMap.Column.Length; i++)
        {
            if (playerPosition.column == StageMap.Column[i])
            {
                playerPos.column = StageMap.Column[i - 1];
            }
        }

        nextPosition = playerPos;

        Debug.Log(nextPosition.row.ToString() + nextPosition.column);
    }

    public MapIndex GetNextMove()
    {
        return nextPosition;
    }
}
