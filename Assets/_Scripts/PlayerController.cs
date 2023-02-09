using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerController : MonoBehaviour
{
    public Vector3 moveDirection;
    public Vector2 rawIpnut => inputAction.Player.Move.ReadValue<Vector2>();

    Vector2 rotate;
    Rigidbody rb;
    CapsuleCollider cc;
    public Transform rotator;
    public Transform cameraHolder;

    public float jump = 5f;
    public float walkSpeed = 5f;
    Vector3 cameraRotation;

    public LayerMask whatIsGround;

    public PlayerAction inputAction;
    public Animator playerAnimator;
    private bool isWalking = false;

    public List<Gun> guns;

    public Vector2 MouseDelta => inputAction.Player.Look.ReadValue<Vector2>();

    bool IsGrounded => Physics.Raycast(cc.bounds.min, Vector3.down, 0.2f, whatIsGround);


    public void SetBodyRotation()
    {
        if (rotator) rotator.rotation = Quaternion.LookRotation(moveDirection, transform.up);
    }

    private void Awake() {
        inputAction = new PlayerAction();

        /*inputAction.Player.Move.performed += cntxt =>
        {
            Vector2 inputDir = cntxt.ReadValue<Vector2>();
            //moveDirection = cameraHolder.forward * inputDir.y + cameraHolder.right * inputDir.x;
            //moveDirection = new Vector3(inputDir.x, 0f, inputDir.y);

            if (rotator)  ;
        };*/
        inputAction.Player.Move.canceled += cntxt => moveDirection = Vector2.zero;

        inputAction.Player.Jump.performed += cntxt => TryJump();

        inputAction.Player.Shoot.performed += cntxt =>
        {
            foreach (var gun in guns)
            {
                gun.Shoot();
            }
        };
        //inputAction.Player.Aim.performed += cntxt => gun.Aim();

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
        //Debug.Log(DistanceToGround());

    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * walkSpeed, ForceMode.Force);
        //Debug.Log(IsGrounded +"   "+ moveDirection);
    }

    private void OnDisable() 
    {
        inputAction.Disable();
    }

    private void TryJump()
    {
        if (DistanceToGround() == 0) Jump();
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
    }

    private float DistanceToGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(cc.bounds.min, Vector3.down, out hit, 1000f, whatIsGround))
        {
            return Vector3.Distance(transform.position, hit.transform.position);
        }
        return 0f;
    }
}
