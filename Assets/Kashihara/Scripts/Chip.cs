using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChipType
{
    None,
    jizo,
    Exit,
    Hassyaku,
}

public class Chip : MonoBehaviour
{
    public ChipType type { get; set; }
    private Sound sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sound GetSound()
    {
        return sound;
    }
}
