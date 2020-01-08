using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChipType
{
    Close,
    Open,
    Jizo,
    Exit,
    Hassyaku,
}

public class Chip : MonoBehaviour
{
    public ChipType type { get; set; }
    private int row;
    private string column;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIndex(int row,string column)
    {
        this.row = row;
        this.column = column;

        string name = row.ToString() + column.ToString();
        ChangeName(name);
    }

    private void ChangeName(string name)
    {
        this.gameObject.name = name;
    }
}
