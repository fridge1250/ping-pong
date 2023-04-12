using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(CollisionTagData.Player))
        {
            SetHorizontalDirection(-1f);
        }
    }

    private void CheckHorizontalDirection(WallData wall)
    {
        if (wall.CurrentDirection.x > 0f)
        {
            SetHorizontalDirection(1f);
            SetVerticalDirection(-1f);
        }
        else if (wall.CurrentDirection.x < 0f)
        {
            SetHorizontalDirection(-1f);
            SetVerticalDirection(1f);
        }
    }

    private void CheckVerticalDirection(WallData wall)
    {
        if (wall.CurrentDirection.y > 1f)
        {
            SetHorizontalDirection(-1f);
            SetVerticalDirection(1f);
        }
        else if (wall.CurrentDirection.y < 1f)
        {
            SetHorizontalDirection(1f);
            SetVerticalDirection(-1f);
        }
    }

    private void SetHorizontalDirection(float value)
    {
        var direction = new Vector2(value, 1f);

        GameplayEventHandler.SendHorizontalDirectionChanged(direction.x);
    }

    private void SetVerticalDirection(float value)
    {
        var direction = new Vector2(1f, value);

        GameplayEventHandler.SendVerticalDirectionChanged(direction.y);
    }
}