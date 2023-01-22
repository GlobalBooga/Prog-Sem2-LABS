using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;
    Rigidbody rb;
    CapsuleCollider cc;

    public float jump = 5f;
    public float walkSpeed = 5f;
    public Camera playerCamera;
    Vector3 cameraRotation;

    public LayerMask whatIsGround;

    public Animator playerAnimator;
    private bool isWalking = false;

    bool IsGrounded => Physics.Raycast(cc.bounds.min, Vector3.down, 0.2f, whatIsGround);

    private void Awake() {
        inputAction = new PlayerAction();

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.performed += cntxt => TryJump();


        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
        playerAnimator = GetComponent<Animator>();
    }

    private void OnEnable() 
    {
        inputAction.Enable();
    }

    private void Update() 
    {

    }

    private void FixedUpdate()
    {
        if (IsGrounded) rb.AddForce(move * walkSpeed, ForceMode.Force);
    }

    private void OnDisable() 
    {
        inputAction.Disable();
    }

    private void TryJump()
    {
        if (IsGrounded) Jump();
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
    }

    private float distanceToGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(cc.bounds.min, Vector3.down, out hit, 1000f, whatIsGround))
        {
            return Vector3.Distance(transform.position, hit.transform.position);
        }
        return 0f;
    }
}
