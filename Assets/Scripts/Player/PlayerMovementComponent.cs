using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

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

    public bool leftCheck, rightCheck;
    
    RaycastHit2D LeftCheckCast;    
    RaycastHit2D RightCheckCast;
    RaycastHit2D BottomCheckCast;

    public float RotationZeroSpeed = 5;

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
        Acceleration =Mathf.Lerp(Acceleration, inputx.x, playerMovement.Acceleration * Time.deltaTime);

        float Speed = playerMovement.Speed;
        float AngularSpeed = playerMovement.AngularSpeed;

        BottomCheckCast = Physics2D.CircleCast(transform.position, 0.8f, -transform.up,playerMovement.JumpCheckDistance,groundCheckMask);        
        LeftCheckCast = Physics2D.Raycast(transform.position, -transform.right, 2f, groundCheckMask);        
        RightCheckCast = Physics2D.Raycast(transform.position, transform.right, 2f, groundCheckMask);
        
        leftCheck = LeftCheckCast;
        rightCheck = RightCheckCast;
        ground = BottomCheckCast;

        MoveAndTurn(Acceleration, Speed, AngularSpeed);

        if (!ground)
        {
            StartCoroutine(GroundCheck());
            if (rb.velocity.y > 0)
            {
                rb.velocity += new Vector2(0, 1) * Physics2D.gravity.y * (playerMovement.jumpGraviyUp - 1) * Time.deltaTime;
            }
            if (rb.velocity.y < 0)
            {
                rb.velocity += new Vector2(0, 1) * Physics2D.gravity.y * (playerMovement.jumpGravityDown - 1) * Time.deltaTime;
            }
                
        }
        else
        {
            Grounded = true;
        }
        Vector2 desiredUpVec;
        
        if (Grounded)
        {
            desiredUpVec = BottomCheckCast.normal;
        }
        else
        {
            desiredUpVec = new Vector2(0, 1);
        }
        transform.up = Vector2.Lerp(transform.up,desiredUpVec, RotationZeroSpeed * Time.deltaTime);

    }

    public void ParseMovement(InputAction.CallbackContext context)
    {
        inputx = context.ReadValue<Vector2>();
    }

    public void MoveAndTurn(float inputX, float Speed, float AngularSpeed)
    {

       
            PlayerArt.transform.Rotate(0, 0, (-inputX * playerMovement.AngularSpeed * Time.deltaTime));

            Vector2 forward = transform.right;
            Vector2 down = -transform.up;

            rb.velocity += ((forward * Speed) * inputX) * Time.deltaTime;
      

        
    }
    
    IEnumerator GroundCheck()
    {        
        yield return new WaitForSeconds(playerMovement.jumpDelay);

        if (!ground)
        {
            
            Grounded = false;
       
        }
        
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (Grounded)
        {
            Vector2 UpDir = transform.up;
            
            rb.velocity += UpDir * playerMovement.JumpHeight;
                       
            Grounded = false;
           
        }
        else
        {
            return;
        }     
    }

    private void OnDrawGizmos()
    {

        if (LeftCheckCast)
        {
            Gizmos.color = Color.white;
            
            Gizmos.DrawLine(transform.position, LeftCheckCast.point);
        }
        else
        {
            Gizmos.color = Color.red;
            
            Gizmos.DrawLine(transform.position, transform.position + transform.right * -2);
        }


        if (RightCheckCast)
        {
            Gizmos.color = Color.white;
            
            Gizmos.DrawLine(transform.position, RightCheckCast.point);
        }
        else
        {
            Gizmos.color = Color.blue;
            
            Gizmos.DrawLine(transform.position, transform.position + transform.right * 2);
        }
        Gizmos.color = Color.yellow;
       
        Gizmos.DrawLine(transform.position, transform.position + -transform.up * 2);
    }
    
    
}
