using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    public Transform initialObject;
    public Transform targetObject;
    public bool exact;
    public bool rotationEnabled;
    public bool followEnabled;
    public float moveSpeed;

    public Vector3 positionOffset;

    private void Update()
    {
        if (!followEnabled)
        {
            return;
        }

        if (exact)
        {
            FollowExact();
        }
        else if (!exact)
        {
            FollowMoveTo();
        }
    }

    public void FollowExact()
    {
        initialObject.position = targetObject.position + positionOffset;
        if (rotationEnabled)
        {
            initialObject.rotation = targetObject.rotation;
        }
    }

    public void FollowMoveTo()
    {
        initialObject.position = Vector3.MoveTowards(initialObject.position, (targetObject.position + positionOffset), moveSpeed * Time.deltaTime);
        if (rotationEnabled)
        {
            initialObject.rotation = targetObject.rotation;
        }
    }
}
