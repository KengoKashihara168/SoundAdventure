using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class text : MonoBehaviour
{
    public Image image;
    int count;
    int a;
    // Start is called before the first frame update
    void Start()
    {
        count = 1;
        a = 1;
    }

    // Update is called once per frame
    void Update()
    {

       
        if (count <= 255)
        {
            count += a;
        }
        image.material.color = new Vector4(130, 130, 130,(float)count/255);


    }
}