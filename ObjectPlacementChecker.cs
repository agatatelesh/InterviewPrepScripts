using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementChecker : MonoBehaviour
{
    public List<DraggbleScript> draggableScripts;
    public Animator characterAnimator;
    public AudioSource loopAudioSource; // AudioSource for the loop sound
    public AudioSource soundAudioSource; // AudioSource for the additional sounds
    public AudioClip loopAudioClip; // Audio clip for the loop sound
    public AudioClip soundClip1; // Audio clip for "IsStandingUp_1"
    public AudioClip soundClip2; // Audio clip for "IsStandingUp_2"
    public AudioClip soundClip3; // Audio clip for "IsStandingUp_3"

    private int numObjectsInRightPlace = 0;
    private bool isPlayingLoopSound = false;

    private void Start()
    {
        if (loopAudioSource != null && loopAudioClip != null)
        {
            loopAudioSource.clip = loopAudioClip;
            loopAudioSource.loop = true;
            loopAudioSource.Play();
            isPlayingLoopSound = true;
        }
    }

    private void Update()
    {
        numObjectsInRightPlace = 0;

        foreach (DraggbleScript draggableScript in draggableScripts)
        {
            if (draggableScript.isInARightPlace)
            {
                numObjectsInRightPlace++;
            }
        }

        if (numObjectsInRightPlace == 1 && !characterAnimator.GetBool("IsStandingUp_1"))
        {
            characterAnimator.SetBool("IsStandingUp_1", true);

            // Stop the loop sound if it's playing
            if (isPlayingLoopSound && loopAudioSource != null)
            {
                loopAudioSource.Stop();
                isPlayingLoopSound = false;
            }

            // Play audio clip for "IsStandingUp_1"
            if (soundClip1 != null && soundAudioSource != null)
            {
                soundAudioSource.clip = soundClip1;
                soundAudioSource.loop = true;
                soundAudioSource.Play();
            }
        }
        else if (numObjectsInRightPlace == 2 && !characterAnimator.GetBool("IsStandingUp_2"))
        {
            characterAnimator.SetBool("IsStandingUp_2", true);

            // Play audio clip for "IsStandingUp_2" with the same looped sound
            if (soundClip2 != null && soundAudioSource != null)
            {
                soundAudioSource.clip = soundClip2;
                soundAudioSource.loop = true;
                soundAudioSource.Play();
            }
        }
        else if (numObjectsInRightPlace == 3 && !characterAnimator.GetBool("IsStandingUp_3"))
        {
            characterAnimator.SetBool("IsStandingUp_3", true);

            // Stop the loop sound if it's playing
            if (isPlayingLoopSound && loopAudioSource != null)
            {
                loopAudioSource.Stop();
                isPlayingLoopSound = false;
            }

            // Play audio clip for "IsStandingUp_3" (not on loop)
            if (soundClip3 != null && soundAudioSource != null)
            {
                soundAudioSource.loop = false;
                soundAudioSource.PlayOneShot(soundClip3);
            }
        }
    }
}



