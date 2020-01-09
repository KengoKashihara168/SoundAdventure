using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    int pos;
    public new AudioSource []audio=new AudioSource[25];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int Getpos()
    {
        return pos;
    }

    public AudioSource Getaudio(int pos)
    {
        return audio[pos];
    }
    public void Setaudio(int pos,AudioSource aud)
    {
        audio[pos]=aud;
    }
}
