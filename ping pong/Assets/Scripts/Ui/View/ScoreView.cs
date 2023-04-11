using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI), typeof(Score))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private readonly int _currentScore;

    private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        GameplayEventHandler.OnScoreChanged += SetScore;
    }

    private void OnDisable()
    {
        GameplayEventHandler.OnScoreChanged -= SetScore;
    }

    private void SetScore(int amount)
    {
        _scoreText.text = $"{amount}$";
    }
}