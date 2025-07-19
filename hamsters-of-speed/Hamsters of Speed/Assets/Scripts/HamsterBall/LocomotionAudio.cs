using System.Collections;
using UnityEngine;

public class LocomotionAudio : MonoBehaviour
{
    public BallLocomotion locomotionScript;
    public AudioSource source;
    private Rigidbody ballRb;

    public float velocityThreshold = 0.1f;
    public float volumeFactor = 0.1f;
    public float pitchFactor = 0.1f;

    private void Awake()
    {
        ballRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Ensure the ball makes sound while rolling
        UpdateRollingAudio();
    }

    public void UpdateRollingAudio()
    {
        //Pause the rolling audio if the ball is not on the ground, or if it is not moving
        if (!locomotionScript.isGrounded | ballRb.linearVelocity.magnitude < velocityThreshold)
        {
            source.Pause();
            return;
        }

        if (!source.isPlaying)
        {
            source.Play();
        }

        //Adjust pitch and volume accordingly
        source.volume = ballRb.linearVelocity.magnitude * volumeFactor;
        source.pitch = ballRb.linearVelocity.magnitude * pitchFactor;
    }
}
