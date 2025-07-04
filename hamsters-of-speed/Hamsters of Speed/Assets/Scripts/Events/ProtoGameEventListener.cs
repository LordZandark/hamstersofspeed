using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoGameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GameEvent gameEvent;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public virtual void OnEventRaised(Component sender, object data)
    {
        Debug.Log("OnEventRaised: " + sender + " data: " +  data);
    }
}
