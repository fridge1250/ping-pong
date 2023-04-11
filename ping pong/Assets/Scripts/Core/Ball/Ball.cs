using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour, IMovable
{
    [SerializeField] private float _moveSpeed = 10f;
    [Space(10)]
    [SerializeField] private float _horizontalDirectionValue;
    [SerializeField] private float _verticalDirectionValue;
    [Space(10)]
    [SerializeField] private float _minDirectionChangeRange;
    [SerializeField] private float _maxDirectionChangeRange;

    private Rigidbody2D _rigidbody;

    private Vector2 _currentDirection;
    public float MoveSpeed => _moveSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        GameplayEventHandler.OnHorizontalDirectionChanged += SetHorizontalDirection;
    }

    private void OnDisable()
    {
        GameplayEventHandler.OnVerticalDirectionChanged -= SetVerticaDirection;
    }

    private void Start()
    {
        InitDirection();

        _currentDirection = new Vector2(_horizontalDirectionValue, _verticalDirectionValue);
    }

    private void FixedUpdate()
    {
        Move(_moveSpeed);
    }

    public void Move(float speed)
    {
        _rigidbody.velocity = speed * _currentDirection.normalized;
    }

    private void InitDirection()
    {
        _horizontalDirectionValue = Utility.SetRandomFloatValue(_minDirectionChangeRange, 
            _maxDirectionChangeRange);
        _verticalDirectionValue = Utility.SetRandomFloatValue(_minDirectionChangeRange, 
            _maxDirectionChangeRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(CollisionTagData.Player))
        {
            _currentDirection.x = -_currentDirection.x;
        }
        else if (collision.gameObject.CompareTag(CollisionTagData.LeftWall))
        {   
            _currentDirection.y = -_currentDirection.y;
        }
        else if (collision.gameObject.CompareTag(CollisionTagData.RightWall))
        {
            _currentDirection.x = _currentDirection.y;
        }
        else if (collision.gameObject.CompareTag(CollisionTagData.TopWall))
        {
            _currentDirection.y = -_currentDirection.y;
        }
        else if (collision.gameObject.CompareTag(CollisionTagData.BottomWall))
        {
            _currentDirection.x = _currentDirection.y;
        }
    }

    private void SetHorizontalDirection(float value)
    {
        _currentDirection.x = value;
    }

    private void SetVerticaDirection(float value)
    {
        _currentDirection.y = value;
    }
}