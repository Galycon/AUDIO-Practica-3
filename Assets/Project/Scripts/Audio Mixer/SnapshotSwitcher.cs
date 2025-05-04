using UnityEngine;
using UnityEngine.Audio;

public class SnapshotSwitcher : MonoBehaviour
{
    public AudioMixer mixer;
    public string normalSnapshotName = "Normal";
    public string bunkerSnapshotName = "Bunker";
    public float transitionTime = 1f;

    public GameObject messageUI;  // UI que muestra "Pulsa B para cambiar modo"

    private bool inBunker = false;
    private bool playerInZone = false;

    void Start()
    {
        if (messageUI != null)
            messageUI.SetActive(false);
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.B))
        {
            inBunker = !inBunker;
            string targetSnapshot = inBunker ? bunkerSnapshotName : normalSnapshotName;

            AudioMixerSnapshot snapshot = mixer.FindSnapshot(targetSnapshot);
            if (snapshot != null)
            {
                snapshot.TransitionTo(transitionTime);
            }
            else
            {
                Debug.LogWarning("Snapshot not found: " + targetSnapshot);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            if (messageUI != null)
                messageUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            if (messageUI != null)
                messageUI.SetActive(false);
        }
    }
}
