﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameText : MonoBehaviour
{
    [SerializeField]
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActive(bool flag)
    {
        gameObject.SetActive(flag);
    }

    public void SetName(string name)
    {
        text.text = name;
    }
}
