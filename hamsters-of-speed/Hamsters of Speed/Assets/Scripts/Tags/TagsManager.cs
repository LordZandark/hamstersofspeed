using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TagsManager : MonoBehaviour
{
    [Tooltip("List of tags in this tag manager")]
    public List<Tag> tags;

    /* Does the Tag Manager contain a tag?
     * Parameter: string containing name of tag to look for
     * Return:  True if contains tag
     *          False if does not contain tag
     */
    public bool HasTag(string tag)
    {
        Tag itemtag = tags.FirstOrDefault(x => x.name == tag);

        bool returnval = (itemtag != null) ? true : false;
        return returnval;
    }

    /* Add a tag to the Tag Manager by name
     * Parameter: string containing the name of tag to add
     */
    public void AddTagByName(string name)
    {
        Tag tag = FindAnyObjectByType<TagsList>().GetTag(name);

        tags.Add(tag);
    }

    /* Remove a tag to the Tag Manager by name
     * Parameter: string containing the name of tag to remove
     */
    public void RemoveTagByName(string name)
    {
        Tag tag = FindAnyObjectByType<TagsList>().GetTag(name);

        tags.Remove(tag);
    }

    public void AddTag(Tag tag)
    {
        tags.Add(tag);
    }

    public void RemoveTag(Tag tag)
    {
        tags.Remove(tag);
    }
}
