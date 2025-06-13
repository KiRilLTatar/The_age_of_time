using UnityEngine;

public class Portal : MonoBehaviour
{
    public float speed = 6f;
    public float jumpHeight = 2f;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private int pickupCount = 0;
    private AudioSource audioSource;
    public PickupUI pickupUI;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject); 
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.4f, LayerMask.GetMask("Default"));

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            pickupCount++;
            Debug.Log("Собрано предметов: " + pickupCount);
            audioSource.Play();
            pickupUI.UpdatePickupCount();
            Destroy(other.gameObject);
        }
    }
}
