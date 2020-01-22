using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScreen : MonoBehaviour
{
    private Camera mainCamera;
    private Item nearItem;
    private Quaternion defaultCameraRotate;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        nearItem = null;
        defaultCameraRotate = mainCamera.transform.rotation;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScreen(Item item)
    {
        gameObject.SetActive(true);
        nearItem = item;
        PlaySound();
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

    public void PlaySound()
    {
        if (nearItem == null) return;
        nearItem.PlaySound();
    }

    public void StopSound()
    {
        if (nearItem == null) return;
        nearItem.StopSound();
    }

    public void CloseScreen()
    {
        StopSound();
        mainCamera.transform.rotation = defaultCameraRotate;
        gameObject.SetActive(false);
    }
}
