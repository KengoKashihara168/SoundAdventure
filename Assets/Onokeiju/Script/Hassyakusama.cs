using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hassyakusama : MonoBehaviour
{
    public Player player;
    private StageMap map;
    private  MapIndex position;
    MapIndex mapIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(Random.Range(1, 3));
    }

    private void Move(int num)
    {
     


     
    }
}
