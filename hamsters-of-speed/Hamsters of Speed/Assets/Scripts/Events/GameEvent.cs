﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="GameEvent")]
public class GameEvent : ScriptableObject
{

    public List<ProtoGameEventListener> listeners = new List<ProtoGameEventListener>();

    // Raise event through different method signatures
    // ############################################################

    public void Raise() {
        Raise(null, null);
    }

    public void Raise(object data) {
        Raise(null, data);
    }

    public void Raise(Component sender) {
        Raise(sender, null);
    }

    public void Raise(Component sender, object data) {
        for (int i = listeners.Count -1; i >= 0; i--) {
            listeners[i].OnEventRaised(sender, data);
        }
    }

    // Manage Listeners
    // ############################################################

    public void RegisterListener(ProtoGameEventListener listener) {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void UnregisterListener(ProtoGameEventListener listener) {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }

}
