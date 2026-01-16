using TMPro.Examples;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 5f;
    [SerializeField] private float groundDistance = 0.3f;

    private Player_Controls controls;
    private Rigidbody rb;
    private Animator animator;
    private Vector2 moveInput;

    public LayerMask groundMask;
    public bool isGrounded;
    public GameObject spawn;

    void Awake()
    {
        controls = new Player_Controls();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += _ => moveInput = Vector2.zero;
        controls.Player.Jump.performed += _ => Jump();
    }

    void OnEnable() => controls.Player.Enable();
    void OnDisable() => controls.Player.Disable();

    void FixedUpdate()
    {
        GroundCheck();
        MovePlayer();
    }

    void Update()
    {
        UpdateAnimations();
        RotatePlayer();
    }

    void MovePlayer()
    {
        rb.linearVelocity = new Vector3(moveInput.x * moveSpeed, rb.linearVelocity.y, 0f);
    }

    void Jump()
    {
        if (!isGrounded) return;

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, 0f);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundMask);
    }

    void UpdateAnimations()
    {
        animator.SetBool("isMoving", Mathf.Abs(moveInput.x) > 0.1f);
        animator.SetBool("isJumpingUp", !isGrounded && rb.linearVelocity.y > 0.1f);
    }

    void RotatePlayer()
    {
        if (moveInput.x > 0.1f)
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        else if (moveInput.x < -0.1f)
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
            transform.position = spawn.transform.position;
    }
}
