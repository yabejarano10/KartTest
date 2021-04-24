using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour
{
    [SerializeField]
    float Speed;
    [SerializeField]
    float TurnSpeed;

    private float boostTimer;
    private bool boosting;
    private float initSpeed;

    private float lostControlTime;
    private bool controlLost;
    private float initTurn;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        boostTimer = 0;
        boosting = false;
        initSpeed = Speed;

        lostControlTime = 0;
        controlLost = false;
        initTurn = TurnSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Move();
        Turn();

        if(boosting)
        {
            boostTimer += Time.deltaTime;
            if(boostTimer >= 1.5f)
            {
                Speed = initSpeed;
                boostTimer = 0;
                boosting = false;
            }
        }
        if(controlLost)
        {
            lostControlTime += Time.deltaTime;
            if(lostControlTime >= 1)
            {
                TurnSpeed = initTurn;
                lostControlTime = 0;
                controlLost = false;
            }
        }
        
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce( new Vector3(Vector3.forward.x,0,Vector3.forward.z) * Speed * 10);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(-new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * Speed * 10);
        }
        Vector3 localVel = transform.InverseTransformDirection(rb.velocity);
        localVel = new Vector3(0, localVel.y, localVel.z);
        rb.velocity = new Vector3(transform.TransformDirection(localVel).x, rb.velocity.y, transform.TransformDirection(localVel).z);
    }
    void Turn()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * TurnSpeed * 10);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.up * TurnSpeed * 10);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boost")
        {
            boosting = true;
            Speed += 20f;
        }
        if(other.tag == "Oil")
        {
            controlLost = true;
            TurnSpeed *= 1.4f;
        }
    }
}
