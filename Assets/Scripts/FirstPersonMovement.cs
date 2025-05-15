using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonMovement : MonoBehaviour
{
    public float walkSpeed = 6.0f;
    public float sprintSpeed = 10.0f;
    public float jumpForce = 8.0f;
    public float gravity = 20.0f;
    public float mouseSensitivity = 2.0f;

    private AudioSource audioSource;
    public AudioClip footstepSound;


    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0f;
    private float rotationY = 0f;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        // Mouse Look
        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        transform.localRotation = Quaternion.Euler(0, rotationX, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);

        // Movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Speed variation
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        if (controller.isGrounded)
        {
            moveDirection = move * currentSpeed;
            bool isMoving = moveX != 0 || moveZ != 0;

            if (isMoving)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = footstepSound;
                    audioSource.loop = true;
                    audioSource.Play();
                }
            }
            else
            {
                audioSource.Stop();
            }


            // Jump
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move
        controller.Move(moveDirection * Time.deltaTime);
    }
}

