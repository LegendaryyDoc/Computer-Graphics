using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanScript : MonoBehaviour
{
    public float movementSpeed;

    private Animator movement;
    private bool running= false;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
            movement.SetBool("Run", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
            movement.SetBool("Run", false);
        }

        if(Input.GetKey(KeyCode.W))
        {
            movement.SetBool("Forward", true);
            movement.SetBool("Reset", false);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            movement.SetBool("Forward", false);
            movement.SetBool("Reset", true);
        }

        if(Input.GetKey(KeyCode.A))
        {
            movement.SetBool("Left", true);
            movement.SetBool("Reset", false);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            movement.SetBool("Left", false);
            movement.SetBool("Reset", true);
        }

        if(Input.GetKey(KeyCode.D))
        {
            movement.SetBool("Right", true);
            movement.SetBool("Reset", false);
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            movement.SetBool("Right", false);
            movement.SetBool("Reset", true);
        }
    }
}