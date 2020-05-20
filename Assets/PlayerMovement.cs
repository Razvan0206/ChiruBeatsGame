using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardForce = 100f;
    public float sidewaysForce = 70f;
    public float backForce = 60f;
    public float jumpForce = 20000f;
    public float SlideSpeed = 1000f;

    float forwardForce2 = 100f;
    float sidewaysForce2 = 70f;
    float backForce2 = 60f;
    float jumpForce2 = 20000f;

    public float angle;
    float angle2;

    public Transform cameraTr;

    public Rigidbody rb;
    public CapsuleCollider coll;

    public GroundCheck groundCheck;
    bool sliding;
    
    void Start()
    {
        forwardForce2 = forwardForce;
        sidewaysForce2 = sidewaysForce;
        backForce2 = backForce;
        jumpForce2 = jumpForce;
        Time.timeScale = 1f;
    }

    
    void FixedUpdate()
    {
        if(angle >= -2 && angle2 == 1)
        {
            angle -= 3*Time.deltaTime;
        }
        if (angle <= 2 && angle2 == -1)
        {
            angle += 3 * Time.deltaTime;
            
        }
        if(angle>0 && angle2 == 0)
        {
            angle -= Time.deltaTime * 5;
        }
        if (angle < 0 && angle2 == 0)
        {
            angle += Time.deltaTime * 5;
        }
    }
    private void Update()
    {
        if(transform.position.y <= -10f)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        Jump();
        Move();
        SlowMo();
        Crouch1();
        if (Input.GetKeyDown(KeyCode.A))
        {
            angle2 = -1;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            angle2 = 0;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            angle2 = 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            angle2 = 0;
        }
        if(groundCheck.IsGrounded == false)
        {
            forwardForce = forwardForce2 / 1.5f;
            sidewaysForce = sidewaysForce2 / 1.5f;
            backForce = backForce2 / 1.5f;
            jumpForce = jumpForce2 / 1.5f;
        }
        if (groundCheck.IsGrounded == true)
        {
            forwardForce = forwardForce2;
            sidewaysForce = sidewaysForce2;
            backForce = backForce2;
            jumpForce = jumpForce2;
        }
        if(sliding == true)
        {
            coll.height = 1f;
            
        }
        if (sliding == false)
        {
            coll.height = 3f;
        }

    }
    void Crouch1()
    {
        if(groundCheck.IsGrounded == true && Input.GetKeyDown(KeyCode.LeftControl) && sliding == false)
        {
            sliding = true;
            Invoke("Crouch2", 1f);
            rb.AddForce(transform.forward * SlideSpeed);
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        }
    }
    void SlowMo()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = Time.timeScale * 0.01f;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.01f;
        }
    }
    void Crouch2()
    {   
        sliding = false;   
    }

    void Move()
    {
        if (sliding == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.forward * forwardForce);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(transform.forward * -backForce);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(transform.right * -sidewaysForce);
            angle2 = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * sidewaysForce);
            angle2 = 1;
        }
        
    }
    void Jump()
    {
        if(groundCheck.IsGrounded == true && Input.GetKeyDown(KeyCode.Space) && sliding == false)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }
    
}
