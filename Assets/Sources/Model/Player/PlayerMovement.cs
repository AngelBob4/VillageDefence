using UnityEngine;

public class PlayerMovement
{
    public Vector3 MovementDirection { get; private set; }
    public Vector3 PositionToRotate { get; private set; }
    public float MovementSpeed { get; private set; }

    private AttackZone _attackZone;
    private Player _player;

    public PlayerMovement(float movementSpeed, AttackZone attackZone, Player player)
    {
        MovementSpeed = movementSpeed;
        _attackZone = attackZone;
        _player = player;
    }

    public void ResetMoveDirection(Vector2 direction)
    {
        Vector3 newDirection = ConvertVector2ToVector3(direction);
        MovementDirection = newDirection;
    }

    public void Rotate()
    {
        if (_attackZone.Target != null)
        {
            PositionToRotate = _attackZone.Target.Position;
        }
        else
        {
            Vector3 forwardPosition = _player.Position + MovementDirection;
            PositionToRotate = forwardPosition;
        }

        PositionToRotate = new Vector3
            (
            PositionToRotate.x,
            _player.Position.y,
            PositionToRotate.z
            );
    }

    private Vector3 ConvertVector2ToVector3(Vector2 vector)
    {
        return new Vector3(vector.x, 0, vector.y);
    }
}