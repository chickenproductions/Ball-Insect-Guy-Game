using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementComponent : MonoBehaviour
{
    public PlayerMovement playerMovement;
    
    public Rigidbody2D rb;
    
    public float Acceleration;
   
    public GameObject PlayerArt;
   
    private Vector2 inputx;
    
    public GameControls Controls;

    [SerializeReference]private bool Grounded;
    
    public bool ground;
    
    public LayerMask groundCheckMask;

   
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
       
        Controls = new GameControls();
       
        Controls.Player.Jump.performed += Jump;
    }
    private void OnEnable()
    {
        Controls.Enable();
    }
    private void OnDisable()
    {
        Controls.Disable();
    }



    void Update()
    {
        
       
        
        

    }

    private void FixedUpdate()
    {
        Acceleration = Mathf.Lerp(Acceleration, inputx.x, playerMovement.Acceleration * Time.deltaTime);

        float Speed = playerMovement.Speed;

        float AngularSpeed = playerMovement.AngularSpeed;

        MoveAndTurn(Acceleration, Speed, AngularSpeed);

        ground = Physics2D.BoxCast(transform.position, new Vector2(1, 1),0, -Vector2.up,playerMovement.JumpCheckDistance,groundCheckMask);
       
        if (!ground)
        {
            StartCoroutine(GroundCheck());
            if (rb.velocity.y > 0)
            {
                rb.velocity += new Vector2(0, 1) * Physics2D.gravity.y * (playerMovement.jumpGraviyUp - 1) * Time.deltaTime;
            }
            if (rb.velocity.y < 0)
                rb.velocity += new Vector2(0, 1) * Physics2D.gravity.y * (playerMovement.jumpGravityDown - 1) * Time.deltaTime;
        }
        else
        {
            Grounded = true;
        }
     
    }

    public void ParseMovement(InputAction.CallbackContext context)
    {
        inputx = context.ReadValue<Vector2>();
    }

    public void MoveAndTurn(float inputX, float Speed, float AngularSpeed)
    {
        
        PlayerArt.transform.Rotate(0, 0, AngularSpeed * -inputX * Time.deltaTime);
        
        rb.velocity = new Vector2(Speed * inputX, rb.velocity.y);
        
    }
    
    IEnumerator GroundCheck()
    {        
        yield return new WaitForSeconds(playerMovement.jumpDelay);
        
        if(!ground)
        Grounded = false;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        //considering using the "ground normal" for this, so that way when the player is later on removing themselves from the wall they will be able to jump off of it via that
        if (Grounded)
        {

            rb.velocity = new Vector2(rb.velocity.x, 1 + playerMovement.JumpHeight);
                       
            Grounded = false;
           
        }         
    }
}
