using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool IsGrounded;
    public Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            IsGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            IsGrounded = false;

        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            IsGrounded = true;

        }
    }
    private void Update()
    {
        if(IsGrounded == false)
        {
            rb.AddForce(transform.up * -400f*Time.deltaTime);
        }
    }
}
