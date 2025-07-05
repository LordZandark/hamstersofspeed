using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TagsList : MonoBehaviour
{
    [Tooltip("All tags go here")]
    public Tag[] tags;

    public Tag GetTag(string tag)
    {
        Tag itemTag = tags.FirstOrDefault(x => x.name == tag);

        return itemTag;
    }
}
