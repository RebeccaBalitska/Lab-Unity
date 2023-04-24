using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float spead;
    public float speadJump = 15;

    private float xPos;
    private float zPos;

    private Rigidbody rb;


    private bool isJump = false;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rb.AddForce(Vector3.up * speadJump * Time.deltaTime, ForceMode.Impulse);
            isJump = true;
            animator.Play("Jump");
        }
        if(xPos!=0 || zPos != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
                animator.SetBool("Walk", true);
            }
        }
        else
        {
            animator.SetBool("Walk", false);

        }
        xPos = Input.GetAxis("Horizontal") * spead * Time.deltaTime;
        zPos = Input.GetAxis("Vertical") * spead * Time.deltaTime;

        transform.Translate(new Vector3(xPos, 0, zPos));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = false;
        }
    }
}
