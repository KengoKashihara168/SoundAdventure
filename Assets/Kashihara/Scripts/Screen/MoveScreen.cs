using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScreen : MonoBehaviour
{
    [SerializeField] private Button nextButton;
    private MapIndex playerPosition;
    private MapIndex nextPosition;

    private void Awake()
    {
        nextButton.interactable = false;
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScreen(MapIndex playerPos)
    {
        gameObject.SetActive(true);
        playerPosition = playerPos;
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
        nextButton.interactable = true;
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
        nextButton.interactable = true;
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
        nextButton.interactable = true;
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
        nextButton.interactable = true;
        nextPosition = playerPos;
    }

    public MapIndex GetNextMove()
    {
        return nextPosition;
    }

    public void CloseScreen()
    {
        gameObject.SetActive(false);
    }
}
