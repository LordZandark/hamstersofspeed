using System.Collections;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocomotionAudio : MonoBehaviour
{
    public BallLocomotion locomotionScript;
    public AudioSource rollingSource;
    public AudioSource dashSource;
    private Rigidbody ballRb;

    public InputActionReference dashButton;
    public InputActionReference jumpButton;

    public float velocityThreshold = 0.1f;
    public float volumeFactor = 0.1f;
    public float pitchFactor = 0.1f;

    private void OnEnable()
    {
        dashButton.action.performed += DashAudio;
        dashButton.action.Enable();

        jumpButton.action.performed += JumpAudio;
        jumpButton.action.Enable();
    }

    private void OnDisable()
    {
        dashButton.action.performed -= DashAudio;
        dashButton.action.Disable();

        jumpButton.action.performed -= JumpAudio;
        jumpButton.action.Disable();
    }

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
            rollingSource.Pause();
            return;
        }

        if (!rollingSource.isPlaying)
        {
            rollingSource.Play();
        }

        //Adjust pitch and volume accordingly
        rollingSource.volume = ballRb.linearVelocity.magnitude * volumeFactor;
        rollingSource.pitch = ballRb.linearVelocity.magnitude * pitchFactor;
    }

    public void DashAudio(InputAction.CallbackContext context)
    {
        if (!locomotionScript.dashReady)
        {
            return;
        }

        dashSource.pitch = Random.Range(0.9f, 1.1f);
        dashSource.Play();
    }

    public void JumpAudio(InputAction.CallbackContext context)
    {
        if (!locomotionScript.jumpReady | !locomotionScript.isGrounded)
        {
            return;
        }

        dashSource.pitch = Random.Range(0.6f, 0.8f);
        dashSource.Play();
    }
}
