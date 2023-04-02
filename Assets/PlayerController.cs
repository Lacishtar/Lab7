using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public float turnSpeed = 90;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private Animator animator;
    private Vector2 move;

    void Start()
    {
        // controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision other)
    {
        if(gameObject.CompareTag("Wall"))
        {
            animator.SetFloat("Speed", 0);
        }
    }

    void Update() 
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // controller.Move(transform.forward * vertical * speed * Time.deltaTime);
        Vector3 moveDir = new Vector3(horizontal, 0.0f, vertical);

        if(moveDir == Vector3.zero)
        {
            animator.SetFloat("Speed", 0);
        }
        else if(Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.UpArrow)))
        {
            animator.SetFloat("Speed", 0.55f);
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetFloat("Speed", 0.1f);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetFloat("Speed", 0.25f);
            transform.Rotate(Vector3.up * horizontal * turnSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetFloat("Speed", 0.35f);
            transform.Rotate(Vector3.up * horizontal * turnSpeed * Time.deltaTime);            
        }
        else if(Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("Speed", 0.55f);
        }
    }

}