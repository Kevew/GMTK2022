using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WallRunning : MonoBehaviour
{

    [Header("Wallrunning")]
    public LayerMask whatIsWall;
    public LayerMask whatIsGround;
    public float wallRunForce;
    public float maxWallRunTime;
    public float wallJumpUpForce;
    public float wallJumpSideForce;
    private float wallRunTimer;
    private bool running = false;

    [Header("Input")]
    private float hInput;
    private float vInput;

    [Header("Detection")]
    public float wallCheckDistance;
    public float minJumpHeight;
    private RaycastHit leftWallhit;
    private RaycastHit rightWallHit;
    private bool wallLeft;
    private bool wallRight;

    bool LeaveWall;
    public float ExitWallTime;
    private float ExitWallTimer;


    public bool UseGravity;
    public float gravityCounterForce;

    public Transform orientation;
    private PlayerMovement pm;
    private Rigidbody rb;

    public Camera cam;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        StateMachine();
        CheckForWall();
        if (running)
        {
            WallRunMovement();
        }
    }

    void CheckForWall()
    {
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallCheckDistance, whatIsWall);
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallhit, wallCheckDistance, whatIsWall);
    }

    bool AboveGround()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, whatIsGround);
    }

    void StateMachine()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        if((wallRight || wallLeft) && vInput > 0 && AboveGround() && !LeaveWall)
        {
            if (!running)
            {
                StartWallRun();
            }
            if(wallRunTimer > 0)
            {
                wallRunTimer -= Time.deltaTime;
            }
            if(wallRunTimer <= 0 && running)
            {
                LeaveWall = true;
                ExitWallTimer = ExitWallTime;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                WallJump();
            }
        }else if (LeaveWall)
        {
            if (running)
            {
                StopWallRun();
            }
            if(ExitWallTimer > 0)
            {
                ExitWallTimer -= Time.deltaTime;
            }
            if(ExitWallTimer <= 0)
            {
                LeaveWall = false;
            }
        }
        else
        {
            if (running)
            {
                StopWallRun();
            }
        }
    }

    void StartWallRun()
    {
        running = true;
        wallRunTimer = maxWallRunTime;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        DoFov(90f);
        if (wallLeft) DoTilt(-5f);
        if (wallRight) DoTilt(5f);
    }

    void WallRunMovement()
    {
        rb.useGravity = UseGravity;
        Vector3 wallNormal = wallRight ? rightWallHit.normal : leftWallhit.normal;
        Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);

        if((orientation.forward -wallForward).magnitude > (orientation.forward - -wallForward).magnitude)
        {
            wallForward = -wallForward;
        }
        rb.AddForce(wallForward * wallRunForce, ForceMode.Force);
        if(!(wallLeft && hInput > 0) && !(wallRight && hInput < 0))
        {
            rb.AddForce(-wallNormal * 100, ForceMode.Force);
        }

        if (UseGravity)
        {
            rb.AddForce(transform.up * gravityCounterForce, ForceMode.Force);
        }
    }



    void StopWallRun()
    {
        running = false;
        rb.useGravity = true;

        DoFov(80f);
        DoTilt(0f);
    }

    void WallJump()
    {
        LeaveWall = true;
        ExitWallTimer = ExitWallTime;
        Vector3 wallNormal = wallRight ? rightWallHit.normal : leftWallhit.normal;
        Vector3 force = transform.up * wallJumpUpForce + wallNormal * wallJumpSideForce;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(force,ForceMode.Impulse);
    }



    public void DoFov(float endvalue)
    {
        cam.DOFieldOfView(endvalue, 0.25f);
    }


    public void DoTilt(float zTilt)
    {
        transform.DOLocalRotate(new Vector3(0, 0, zTilt), 0.25f);
    }
}
