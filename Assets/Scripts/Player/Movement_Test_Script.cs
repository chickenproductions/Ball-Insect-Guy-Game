using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Test_Script : MonoBehaviour
{
    
    public PlayerMovement playerMovement;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        float Speed = playerMovement.Speed;
        float AngularSpeed = playerMovement.AngularSpeed;

        //rb.AddTorque(Speed *input);
        rb.angularVelocity = (AngularSpeed * -input);
        rb.velocity = new Vector2(Speed * input, rb.velocity.y );

    }
}
