using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private StageMap map; 

    private int row;
    private string column;
 

    // Start is called before the first frame update
    void Start()
    {
        MapIndex index = map.GetPosition();
        row = index.row;
        column = index.column;
        Debug.Log(row + column);
    }
}
