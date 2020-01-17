using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{
    // Start is called before the first frame update
    void Start()
    {
        kind = ItemKind.Sword;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public Sword Create(GameObject obj)
    {
        Sword sword = obj.AddComponent<Sword>();
        sword.kind = ItemKind.Sword;
        return sword;
    }
}
