using UnityEngine;

public class PlayerMovement
{
    private Player _player;

    public PlayerMovement(Player player)
    {
        _player = player;
    }

    public void ResetMoveDirection(Vector2 direction)
    {
        Vector3 newDirection = ConvertVector2ToVector3(direction);
        _player.ResetMoveDirection(newDirection);
    }

    public void Rotate()
    {

    }

    private Vector3 ConvertVector2ToVector3(Vector2 vector)
    {
        return new Vector3(vector.x, 0, vector.y);
    }
}