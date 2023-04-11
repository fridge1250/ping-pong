using UnityEngine;

public class WallData : MonoBehaviour
{
    [SerializeField] private Vector2 _currentDirection;

    public Vector2 CurrentDirection => _currentDirection;
}