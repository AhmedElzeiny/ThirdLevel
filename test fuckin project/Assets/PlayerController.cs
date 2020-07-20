using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public variables
    public float walkSpeed = 15f;
    public float runSpeed = 8f;
    public float jumpHeight = 10f;
    public float gravity = 9.8f;
    public Transform GroundCheck;
    public float groundDist = 0.5f;
    public LayerMask GroundMask;
    public bool hasGun;
    public GameObject gun;

    //private variables
    float currentSpeed;
    CharacterController controller;
    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        gun.SetActive(hasGun);

        currentSpeed = walkSpeed;

        if (GetComponent<CharacterController>())
        {
            controller = GetComponent<CharacterController>();
        }
        else
        {
            gameObject.AddComponent<CharacterController>();
            controller = GetComponent<CharacterController>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        Grounded();
        if (Input.GetButtonDown("Run"))
        {
            currentSpeed = runSpeed;
        }
        else if (Input.GetButtonUp("Run"))
        {
            currentSpeed = walkSpeed;
        }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        float moveHorizontal = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;


        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;

        Move(movement);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }
        velocity.y -= gravity * Time.deltaTime;
        Move(velocity * Time.deltaTime );


    }




    void Move(Vector3 movement)
    {
        controller.Move(movement);
    }

    void Grounded()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDist, GroundMask);
    }


   


}
