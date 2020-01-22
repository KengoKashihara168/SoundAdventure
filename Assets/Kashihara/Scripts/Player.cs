using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isHaunted { get; private set; }
    public MapIndex position { get; private set; }
    public ItemKind item { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialize(bool job,MapIndex startPos)
    {
        isHaunted = job;
        position = startPos;
        transform.position = StageMap.IndexToVector(position);
        item = ItemKind.Sword;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
