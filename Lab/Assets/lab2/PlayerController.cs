using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float spead;
    public float speadJump = 15;

    private float xPos;
    private float zPos;

    private Rigidbody rb;
    private CharacterController characterController;

    private bool isJump = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();  
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rb.AddForce(Vector3.up *speadJump * Time.deltaTime,ForceMode.Impulse);
            isJump = true;
        }
        xPos = Input.GetAxis("Horizontal") * spead * Time.deltaTime;
        zPos = Input.GetAxis("Vertical") * spead * Time.deltaTime;

       transform.Translate(new Vector3(xPos ,0,zPos ));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJump = false;
        }if(collision.gameObject.tag == "lose")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
