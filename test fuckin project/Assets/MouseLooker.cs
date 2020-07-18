using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooker : MonoBehaviour
{

    public Transform player;
    public float mouseSensitivity = 100f;


    float RotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        RotationX -= MouseY;

        RotationX = Mathf.Clamp(RotationX, -90, 90);

        transform.localRotation = Quaternion.Euler(RotationX, 0f, 0f);
        player.Rotate(Vector3.up * MouseX);


    }
}
