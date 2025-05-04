using UnityEngine;

public class RandomFlick : MonoBehaviour
{
    public Animator animator;
    public string triggerName = "Flicker";

    public float minDelay = 1f;
    public float maxDelay = 5f;

    private void Start()
    {
        StartCoroutine(PlayFlickerAtRandom());
    }

    private System.Collections.IEnumerator PlayFlickerAtRandom()
    {
        while (true)
        {
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);

            animator.SetTrigger(triggerName);
        }
    }
}