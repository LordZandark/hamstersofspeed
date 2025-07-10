using System.Collections.Generic;
using UnityEngine;

public class PlayEventFromTrigger : MonoBehaviour
{
    public GameEvent eventToSend;

    public bool triggerOnce = false;
    private bool triggerEnabled = true;

    public List<Tag> targetTags = new List<Tag>();
    private bool targetTagPresent = false;

    private void OnTriggerEnter(Collider other)
    {
        //Don't do anything if the trigger is disabled
        if (!triggerEnabled)
        {
            return;
        }

        TagsManager tags = other.gameObject.GetComponentInParent<TagsManager>();

        if (targetTags.Count > 0 )
        {
            foreach ( Tag t in targetTags )
            {
                if (tags.HasTag(t.name))
                {
                    targetTagPresent = true;
                }
            }
        }
        
        //If the target tag is found in the triggering object, send the event
        if (targetTagPresent)
        {
            eventToSend.Raise();
            targetTagPresent = false;
        }
        //If no target tag has been defined, send the event
        else if (targetTags.Count <= 0)
        {
            eventToSend.Raise();
        }

        //Disables trigger if this trigger is only meant to trigger once
        if (triggerOnce)
        {
            triggerEnabled = false;
        }
    }
}
