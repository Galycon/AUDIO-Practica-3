using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] woodSteps;
    public AudioClip stoneStep;
    public AudioClip carpetStep;

    public float stepRate = 0.5f;
    private float nextStepTime = 0f;

    public LayerMask surfaceLayer;
    public Transform groundCheck;
    public float groundDistance = 2.0f;

    public Rigidbody rb;

    private string currentSurface = "";

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        bool isMoving = rb.velocity.magnitude > 0.1f;
        bool isGrounded = IsPlayerGrounded();

        if (isGrounded && isMoving && Time.time >= nextStepTime)
        {
            PlayFootstep();
            nextStepTime = Time.time + stepRate;
        }
    }

    bool IsPlayerGrounded()
    {
        return Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, surfaceLayer);
    }

    void PlayFootstep()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, Vector3.down, out hit, groundDistance, surfaceLayer))
        {
            string surfaceTag = hit.collider.tag;

            AudioClip selectedClip = null;

            switch (surfaceTag)
            {
                case "Wood":
                    if (woodSteps.Length > 0)
                        selectedClip = woodSteps[Random.Range(0, woodSteps.Length)];
                    break;
                case "Stone":
                    selectedClip = stoneStep;
                    break;
                case "Carpet":
                    selectedClip = carpetStep;
                    break;
                default:
                    return;
            }

            if (selectedClip != null)
            {
                audioSource.clip = selectedClip;
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.volume = Random.Range(0.2f, 0.4f);
                audioSource.Play();
            }
        }
    }
}