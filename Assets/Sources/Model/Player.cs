using UnityEngine;

public class Player
{
    public Vector3 MovementDirection {get; private set;}

    public Player()
    {
        MovementDirection = new Vector3();
    }

    public void ResetMoveDirection(Vector3 direction)
    {
        MovementDirection = direction;
    }
}