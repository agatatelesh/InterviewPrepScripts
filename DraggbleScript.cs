using UnityEngine;

public class DraggbleScript : MonoBehaviour, IDrag
{
    [SerializeField] private float magnetDistanceThreshold = 1f;
    [SerializeField] private float magnetSpeed = 10f;
    [SerializeField] private Collider magnetCollider; // Collider component on the empty game object
    //[SerializeField] private AudioClip audioClip; // Audio clip to play when the object is in place
    [SerializeField] private AudioClip[] audioClips; // Array of audio clips to play when the object is in place

    

    public bool isInARightPlace;

    private Transform parentTransform;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private AudioSource audioSource; // Reference to the AudioSource component


    private void Start()
    {
        parentTransform = transform.parent;
        startPosition = transform.position;
        startRotation = parentTransform.rotation;
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component from the same GameObject
    
    }

    public void onStartDrag()
    {
        Debug.Log("You're dragging the object");
    }

    public void onEndDrag()
    {
        Debug.Log("You stopped dragging the object");

        // Check if the child object has a parent and if it is close enough to magnetize
        if (transform.parent != null && Vector3.Distance(transform.position, parentTransform.position) <= magnetDistanceThreshold)
        {
            // Move the child object to the parent's position with magnetSpeed and apply the parent's rotation
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            isInARightPlace = true;
            gameObject.layer = 0;
            Debug.Log("Object is in place!");

            if (audioClips.Length > 0 && audioSource != null)
            {
                foreach (AudioClip clip in audioClips)
                {
                    audioSource.PlayOneShot(clip);
                }
            }

            /*// Play the audio clip
            if (audioClip != null && audioSource != null)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }*/
        }
        else
        {
            // Check if the object is outside the magnet collider and reposition it smoothly to its start position
            if (!magnetCollider.bounds.Contains(transform.position))
            {
                StartCoroutine(SmoothReturnToStart());
            }
        }
    }

    private System.Collections.IEnumerator SmoothReturnToStart()
    {
        float distanceToStart = Vector3.Distance(transform.position, startPosition);
        float journeyDuration = distanceToStart / magnetSpeed;
        float startTime = Time.time;

        while (Time.time < startTime + journeyDuration)
        {
            float fractionOfJourney = (Time.time - startTime) / journeyDuration;
            transform.position = Vector3.Lerp(transform.position, startPosition, fractionOfJourney);
            transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, fractionOfJourney);
            yield return null;
        }

        // Ensure the object is in its exact start position and rotation
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}







