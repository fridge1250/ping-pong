using UnityEngine;

[RequireComponent(typeof(GateData))]
public class GateCollision : MonoBehaviour
{
    [SerializeField] private float _minDirectionChangeRange;
    [SerializeField] private float _maxDirectionChangeRange;

    private GateData _gateData;

    private void Awake()
    {
        _gateData = GetComponent<GateData>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            var award = _gateData.AwardAmount;

            GameplayEventHandler.SendScoreInitialized(award);

            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2
            (Utility.SetRandomFloatValue(_minDirectionChangeRange,
            _maxDirectionChangeRange),
            Utility.SetRandomFloatValue(_minDirectionChangeRange,
            _maxDirectionChangeRange)));
        }
    }
}