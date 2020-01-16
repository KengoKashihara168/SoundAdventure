using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : Item
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public Cutter Create(GameObject obj)
    {
        Cutter cutter = obj.AddComponent<Cutter>();
        cutter.kind = ItemKind.Cutter;
        return cutter;
    }
}
