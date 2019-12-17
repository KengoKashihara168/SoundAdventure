using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip   sound;
    public Direction direction { get; set; }
    public float     distance { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play()
    {
        
    }

    private void SetAudio()
    {

    }
}
