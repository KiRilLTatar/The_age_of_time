using System;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public CharacterController control;
    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float rotationSpeed = 10f;
    public Animator animator;

    private Vector3 velocity;
    private Camera mainCamera;
    private Hightlightable lastHighlighted;

    private int animIDIsGrounded;
    private int animIDIsMoving;
    private int animIDJump;

    void Awake()
    {
        if (!control)
        {
            control = GetComponent<CharacterController>();
            if (!control)
            {
                Debug.LogError("CharacterController не найден!");
                enabled = false;
                return;
            }
        }

        if (!animator)
        {
            animator = GetComponentInChildren<Animator>();
            if (!animator)
            {
                Debug.LogError("Animator не найден!");
                enabled = false;
                return;
            }
        }

        mainCamera = Camera.main;
        if (!mainCamera)
        {
            Debug.LogError("MainCamera не найдена!");
            enabled = false;
            return;
        }

        animIDIsGrounded = Animator.StringToHash("IsGrounded");
        animIDIsMoving = Animator.StringToHash("IsMoving");
        animIDJump = Animator.StringToHash("Jump");
    }

    void Update()
    {
        if (!control || !mainCamera || !animator) return;

        bool isGrounded = control.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 inputDir = new Vector3(x, 0f, z).normalized;
        bool isMoving = inputDir.magnitude >= 0.1f;

        animator.SetBool(animIDIsGrounded, isGrounded);
        animator.SetBool(animIDIsMoving, isMoving);

        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 move = cameraForward * z + cameraRight * x;

        if (isMoving)
        {
            Vector3 lookDir = new Vector3(move.x, 0, move.z);
            Quaternion targetRotation = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        control.Move(move.normalized * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger(animIDJump);
        }

        velocity.y += gravity * Time.deltaTime;
        control.Move(velocity * Time.deltaTime);

        CheckHighlight();
    }

    void CheckHighlight()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f))
        {
            if (hit.collider.CompareTag("ForCraft"))
            {
                Hightlightable currentHighlightable = hit.collider.GetComponent<Hightlightable>();

                if (currentHighlightable != null && currentHighlightable != lastHighlighted)
                {
                    lastHighlighted?.Unhighlight();
                    currentHighlightable.Highlight();
                    lastHighlighted = currentHighlightable;
                }
            }
            else
            {
                lastHighlighted?.Unhighlight();
                lastHighlighted = null;
            }
        }
        else
        {
            lastHighlighted?.Unhighlight();
            lastHighlighted = null;
        }
    }
}
