using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10;
    public float sprintSpeed = 20;
    private float speed;
    public float rotatnigSpeed = 300;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Sprint();
    }

    void Movement()
    {
        transform.position += transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * rotatnigSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = moveSpeed;
        }
    }
}
