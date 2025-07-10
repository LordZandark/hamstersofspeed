using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TutorialSequence : MonoBehaviour
{
    //Animations for the doors
    public Animation door1Anim;
    public Animation door2Anim;
    public Animation door3Anim;
    public Animation door4Anim;

    //Audio source and clips
    public AudioSource voiceoverSource;
    public AudioClip voiceoverClip1;
    public AudioClip voiceoverClip2;
    public AudioClip voiceoverClip3;
    public AudioClip voiceoverClip4;

    //Door trigger flags
    private bool doorTrigger1 = false;
    private bool doorTrigger2 = false;
    private bool doorTrigger3 = false;

    //Delay variables
    private bool flagDelayDone = false;
    private float stepDelayTime = 3f;

    /* Step in the sequence
     * 0 = Delay for a few seconds before playing the first voiceline
     * 1 = Play the introductory voiceline; Once the voiceline finishes, open the first door
     * 2 = Wait for the player to reach the end of the first hallway
     * 3 = Play the second voiceline; Once the voiceline finishes, open the second door
     * 4 = Wait for the player to reach the end of the second hallway
     * 5 = Play the third voiceline; Once the voiceline finishes, open the third door
     * 6 = Wait for the player to reach the fourth door
     * 7 = Play the fourth voiceline; Once the voiceline finishes, open the fourth door
     * 
     * The final door will have a trigger that will house its own script to send the player to the next scene
     */

    [SerializeField]
    private int sequenceStep = 0;
    private int prevSequenceStep = -1;

    private void Update()
    {
        //Update the sequence
        SequenceStep();
    }

    private void SequenceStep()
    {
        switch (sequenceStep)
        {
            case 0:
                SS0();
                break;

            case 1:
                SS1();
                break;

            case 2:
                SS2();
                break;

            case 3:
                SS3();
                break;

            case 4:
                SS4();
                break;

            case 5:
                SS5();
                break;

            case 6:
                SS6();
                break;

            case 7:
                SS7();
                break;
        }
    }

    private void SS0()
    {
        if (prevSequenceStep != sequenceStep)
        {
            //Every step info
            prevSequenceStep = sequenceStep;

            //Step specific info
            flagDelayDone = false;
            stepDelayTime = 3f;
        }

        //Check delay
        delayCheck();

        //Exit step if delay is finished
        if (flagDelayDone)
        {
            //Go to next sequence step
            sequenceStep++;
        }
    }

    private void SS1()
    {
        if (prevSequenceStep != sequenceStep)
        {
            //Every step info
            prevSequenceStep = sequenceStep;

            //Step specific info
            voiceoverSource.clip = voiceoverClip1;
            voiceoverSource.Play();
        }


        //Exit step if delay is finished
        if (!voiceoverSource.isPlaying)
        {
            //Go to next sequence step
            door1Anim.Play();
            sequenceStep++;
        }
    }

    private void SS2()
    {
        if (prevSequenceStep != sequenceStep)
        {
            //Every step info
            prevSequenceStep = sequenceStep;

            //Step specific info
            
        }


        //Exit step if delay is finished
        if (doorTrigger1)
        {
            //Go to next sequence step
            sequenceStep++;
        }
    }

    private void SS3()
    {
        if (prevSequenceStep != sequenceStep)
        {
            //Every step info
            prevSequenceStep = sequenceStep;

            //Step specific info
            voiceoverSource.clip = voiceoverClip2;
            voiceoverSource.Play();
        }


        //Exit step if delay is finished
        if (!voiceoverSource.isPlaying)
        {
            //Go to next sequence step
            door2Anim.Play();
            sequenceStep++;
        }
    }

    private void SS4()
    {
        if (prevSequenceStep != sequenceStep)
        {
            //Every step info
            prevSequenceStep = sequenceStep;

            //Step specific info
            
        }


        //Exit step if delay is finished
        if (doorTrigger2)
        {
            //Go to next sequence step
            sequenceStep++;
        }
    }

    private void SS5()
    {
        if (prevSequenceStep != sequenceStep)
        {
            //Every step info
            prevSequenceStep = sequenceStep;

            //Step specific info
            voiceoverSource.clip = voiceoverClip3;
            voiceoverSource.Play();
        }


        //Exit step if delay is finished
        if (!voiceoverSource.isPlaying)
        {
            //Go to next sequence step
            door3Anim.Play();
            sequenceStep++;
        }
    }

    private void SS6()
    {
        if (prevSequenceStep != sequenceStep)
        {
            //Every step info
            prevSequenceStep = sequenceStep;

            //Step specific info
            
        }


        //Exit step if delay is finished
        if (doorTrigger3)
        {
            //Go to next sequence step
            sequenceStep++;
        }
    }

    private void SS7()
    {
        if (prevSequenceStep != sequenceStep)
        {
            //Every step info
            prevSequenceStep = sequenceStep;

            //Step specific info
            voiceoverSource.clip = voiceoverClip4;
            voiceoverSource.Play();
        }


        //Exit step if delay is finished
        if (!voiceoverSource.isPlaying)
        {
            //Go to next sequence step
            door4Anim.Play();
            sequenceStep++;
        }
    }

    private bool delayCheck()
    {
        stepDelayTime -= Time.deltaTime;
        if (stepDelayTime <= 0f)
        {
            flagDelayDone = true;
            return true;
        }

        return false;
    }

    public void Door1Triggered(Component sender, object data)
    {
        doorTrigger1 = true;
    }

    public void Door2Triggered(Component sender, object data)
    {
        doorTrigger2 = true;
    }

    public void Door3Triggered(Component sender, object data)
    {
        doorTrigger3 = true;
    }
}
