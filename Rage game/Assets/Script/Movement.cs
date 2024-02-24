using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    
    [SerializeField]StartedControlsGet controls;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] bool isGrounded;
    [SerializeField] bool canMove;
    [SerializeField] float groundDetection;
    [SerializeField] float currentJumpForce;
    [SerializeField] float maxHoldJumpTime;
    [SerializeField] LayerMask groundLayer;

    
    void Start()
    {
         this.gameObject.GetComponent<StartedControlsGet>();
         
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, groundDetection);
    }
    
    void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(transform.position,groundDetection,groundLayer);
        if(isGrounded)
        {
            
            if (controls.isJumping)
            {
                canMove = false;
                if (currentJumpForce >= maxHoldJumpTime)
                {
                    currentJumpForce = maxHoldJumpTime;
                    return;
                }
                currentJumpForce += 1f;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                Jump();
            }
            if (canMove)
            {

                Move();
            }
            canMove = true;
        }
        
        
            
        
    }
    private void Move()
    {
        rb.velocity = new Vector2(controls.direction.x * moveSpeed, rb.velocity.y);
    }
    private void Jump()
    {
        print("JUMP");
        print(transform.up * currentJumpForce+"MACIEK");
        rb.AddForce(transform.up + new Vector3(controls.direction.x,1)  * currentJumpForce * 10);
    }
}
