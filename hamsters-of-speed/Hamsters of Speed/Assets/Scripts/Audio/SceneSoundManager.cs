using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SoundGroup
{
    public string name;
    public Tag associatedTag;
    public List<AudioClip> sounds = new List<AudioClip>();
}

public class SceneSoundManager : MonoBehaviour
{
    public List<SoundGroup> soundGroups = new List<SoundGroup>();
}
