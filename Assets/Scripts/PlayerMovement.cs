using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 40f;
    public float phoneForce = 100f;

    bool phoneMoveRight = false;
    bool phoneMoveLeft = false;

    void FixedUpdate()
    {
        rb.AddForce(0f, 0f, forwardForce * Time.fixedDeltaTime);

        //move on computer
        if (Input.GetKey("d")|| phoneMoveRight)
            rb.AddForce(sidewaysForce * Time.fixedDeltaTime, 0f, 0f, ForceMode.VelocityChange);
        if (Input.GetKey("a")|| phoneMoveLeft)
            rb.AddForce(-sidewaysForce * Time.fixedDeltaTime, 0f, 0f, ForceMode.VelocityChange);
        //move on phone
        /*if(Input.acceleration.x != 0f)
        {
            Debug.Log(Input.acceleration.x);
            rb.AddForce(Input.acceleration.x * phoneForce * Time.fixedDeltaTime, 0f, 0f, ForceMode.VelocityChange);
        }*/



        if (rb.position.y < -1f) FindObjectOfType<GameManager>().EndGame();
    }

    public void PhoneMoveRightButtonClicked()
    {
        phoneMoveRight = true;
    }
    public void PhoneMoveRightButtonReleased()
    {
        phoneMoveRight = false;
    }
    public void PhoneMoveLeftButtonClicked()
    {
        phoneMoveLeft = true;
    }
    public void PhoneMoveLeftButtonReleased()
    {
        phoneMoveLeft = false;
    }
}
