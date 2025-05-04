using UnityEngine;
using UnityEngine.UI;

public class TVSoundToggle : MonoBehaviour
{
    public AudioSource tvAudio;
    public GameObject messageUI;

    private bool playerInRange = false;

    void Start()
    {
        if (messageUI != null)
            messageUI.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (tvAudio.isPlaying)
                tvAudio.Pause();
            else
                tvAudio.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (messageUI != null)
                messageUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (messageUI != null)
                messageUI.SetActive(false);
        }
    }
}