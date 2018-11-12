using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

        Mouse();
    }

    void Mouse()
    {
        //Press ESC to get the mouse backS
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
