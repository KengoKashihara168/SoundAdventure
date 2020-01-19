using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScreen : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RightTurn()
    {
        Vector3 rot = Vector3.up * 90.0f;
        mainCamera.transform.Rotate(rot);
    }

    public void LeftTurn()
    {
        Vector3 rot = Vector3.down * 90.0f;
        mainCamera.transform.Rotate(rot);
    }
}
