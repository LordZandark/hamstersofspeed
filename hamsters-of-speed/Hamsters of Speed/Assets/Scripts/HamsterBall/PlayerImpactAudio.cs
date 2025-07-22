using System.Collections.Generic;
using UnityEngine;

public class PlayerImpactAudio : MonoBehaviour
{
    public List<AudioClip> impactSounds = new List<AudioClip>();
    public AudioSource impactSource;

    private Rigidbody ballRb;

    private int clipIndex;

    public float volumeFactor = 0.2f;

    private void Awake()
    {
        //Fetch the player's rigidbody
        ballRb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        //Sets the target impact sound to a random sound in the list
        clipIndex = Random.Range(0, (impactSounds.Count - 1));
        //Set the volume and pitch of the sound
        UpdateVolumeAndPitch();

        //Set impact sound based on clip index value, and then play the sound
        impactSource.clip = impactSounds[clipIndex];
        impactSource.Play();
    }

    private void UpdateVolumeAndPitch()
    {
        //Determine volume based on velocity
        impactSource.volume = ballRb.linearVelocity.magnitude * volumeFactor;
        //Determine pitch randomly within a range
        impactSource.pitch = Random.Range(0.8f, 1.2f);

        //Debug.Log("Impact volume set to " +  impactSource.volume);
        //Debug.Log("Impact pitch set to " + impactSource.pitch);
    }
}
