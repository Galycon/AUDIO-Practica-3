using UnityEngine;

public class AudioAnimation: MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayLightSound()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}