using UnityEngine;

public class MovementVector : MonoBehaviour
{
    public Transform movementVector;
    public Transform head;
    public Transform ball;
    public Vector3 ballOffset;

    public Vector3 targetPosition;
    private Vector3 moveHere;

    private void FixedUpdate()
    {
        //Manufactures a target position by using the x and z values of the head
        targetPosition = new Vector3(head.position.x, movementVector.position.y, head.position.z);
        //Orients in the direction of the newly created target position
        movementVector.LookAt(targetPosition);

        //Moves the movement vector to the ball (taking the offset into account)
        moveHere = ball.transform.position + ballOffset;
        movementVector.position = moveHere;
    }
}
