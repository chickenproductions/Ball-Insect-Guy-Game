using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private Rigidbody2D rb;
    public float Acceleration;
   
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        
        Acceleration = Mathf.Lerp(Acceleration, input, playerMovement.Acceleration * Time.deltaTime);
        
        float Speed = playerMovement.Speed;
        
        float AngularSpeed = playerMovement.AngularSpeed;
        
        MoveAndTurn(Acceleration, Speed, AngularSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void MoveAndTurn(float inputX, float Speed, float AngularSpeed)
    {
        rb.angularVelocity = (AngularSpeed * -inputX);
        
        // this code works but it is very un wheel like as its moving soully 
        //in a world space X direction which does not take account with the 
        //ground surface, the only issue is that it is rather hard to get the ground of a rolling ball
        //maybe rolling could be generally a visual thing and not a gameplay thing
        //perhaps consider using a setting to configure between the two for debug purposes?
        
        //rb.velocity = new Vector2(Speed * inputX, rb.velocity.y);
        
    }
    public void Jump()
    {
        //considering using the "ground normal" for this, so that way when the player is later on removing themselves from the wall they will be able to jump off of it via that
        
        rb.AddForce(new Vector3(0, 600, 0));
    }
}
