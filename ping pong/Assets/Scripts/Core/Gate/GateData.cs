using UnityEngine;

[RequireComponent(typeof(GateCollision))]
public class GateData : MonoBehaviour
{
    [SerializeField] private int _awardAmount;

    public int AwardAmount => _awardAmount;
}