using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _moveSpeed = 65f;
    [Space(10)]
    [SerializeField] private MoveTypes _moveType;
    
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move(_moveSpeed);
    }

    public void Move(float speed)
    {
        _rigidbody.velocity = speed * Time.deltaTime * CheckCurrentMoveDirection();
    }

    private Vector2 CheckCurrentMoveDirection()
    {
        var direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction = SetDirectionMoveUp();
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = SetDirectionMoveDown();
        }

        return direction;
    }

    private Vector2 SetDirectionMoveUp()
    {
        var direction = Vector2.up;
        _moveType = MoveTypes.Top;

        return direction;
    }

    private Vector2 SetDirectionMoveDown()
    {
        var direction = Vector2.down;
        _moveType = MoveTypes.Bottom;

        return direction;
    }
}