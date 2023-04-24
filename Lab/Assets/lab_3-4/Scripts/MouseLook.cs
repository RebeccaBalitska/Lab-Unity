using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    private float moveDeadZone;

    private int rightFingerId;
    private float halfScrenSize;
    private float cameraPitch;
    private Vector2 lookInput;


    private float xRotation = 0;
    [SerializeField] private Transform player;

    [SerializeField] private float mouseSensitivity = 50;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rightFingerId = -1;
        halfScrenSize = Screen.width / 2;

    }


    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation= Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up * mouseX);

        GetTouchInput();
        if (rightFingerId != -1)
        {
            LookAround();
        }
    }
    private void GetTouchInput()
    {
        for(int i = 0;i< Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            switch (t.phase)
            {
                case TouchPhase.Began:
                    if(t.position.x > halfScrenSize && rightFingerId == -1)
                    {
                        rightFingerId = t.fingerId;
                    }break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (t.fingerId == rightFingerId)
                    {
                        rightFingerId = -1;
                    }break;
                case TouchPhase.Moved:
                    if (t.fingerId == rightFingerId)
                    {
                        lookInput = t.deltaPosition * mouseSensitivity * Time.deltaTime;
                    }break;
                case TouchPhase.Stationary:
                    if (t.fingerId == rightFingerId)
                    {
                        lookInput = Vector2.zero;
                    }break;
            }
        }
    }
    private void LookAround()
    {
        cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90, 90);
        transform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);

        player.Rotate(Vector3.up * lookInput.x);
    }

}
