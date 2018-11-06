using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 20;
    public float sprintSpeed = 40;
    private float speed;

    [Header("Flashlight")]
    public GameObject flashLight;
    private bool active = false;

    [Header("Camera")]
    [Range(10, 100)]
    public float zoomIn = 20;
    [Range(1, 5)]
    public float zoomSpeed = 1;
    private new Camera camera;
    private float deafultFov;
    private bool zoomedIn = false;
    private float zoomValue;

    // Use this for initialization
    void Start()
    {
        flashLight.SetActive(false);

        camera = GetComponent<Camera>();
        deafultFov = camera.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Sprint();

        Mouse();

        if (flashLight != null)
            FlashLight();

        FieldOfView();
    }

    void Movement()
    {
        transform.position += transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.position += transform.right * speed * 0.7f * Time.deltaTime * Input.GetAxis("Horizontal");
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

    void Mouse()
    {
        transform.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X"), Space.World);
        transform.Rotate(Vector3.right, -Input.GetAxisRaw("Mouse Y"), Space.Self);
        //Press ESC to get the mouse backS
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FieldOfView()
    {
        camera.fieldOfView = Mathf.Lerp(deafultFov, zoomIn, zoomValue);

        if (Input.GetMouseButton(1))
        {
            zoomValue += Time.deltaTime * zoomSpeed;
        }
        else
        {
            zoomValue = 0;
            camera.fieldOfView = deafultFov;
        }
    }

    void FlashLight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (active == false)
                active = true;
            else if (active == true)
                active = false;
        }

        flashLight.SetActive(active);
    }
}
