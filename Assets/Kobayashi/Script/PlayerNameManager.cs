﻿using UnityEngine;

public class PlayerNameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerNameText[] player = new PlayerNameText[4];
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivePlayerName(string name)
    {
        if (index >= player.Length)
        {
            return;
        }
        player[index].SetActive(true);
        player[index].SetName(name);
        index++;
    }

    public void AllUnActive()
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i].SetActive(false);
        }
        index = 0;
    }
}
