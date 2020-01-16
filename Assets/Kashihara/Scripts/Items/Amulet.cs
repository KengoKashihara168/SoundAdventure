using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amulet : Item
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public Amulet Create(GameObject obj)
    {
        Amulet amulet = obj.AddComponent<Amulet>();
        amulet.kind = ItemKind.Amulet;
        return amulet;
    }
}
