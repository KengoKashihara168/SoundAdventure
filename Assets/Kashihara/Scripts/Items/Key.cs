using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public Key Create(GameObject obj)
    {
        obj.AddComponent<Key>();
        Key key = obj.AddComponent<Key>();
        key.kind = ItemKind.Key;
        return key;
    }
}
