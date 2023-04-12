using UnityEngine;

[RequireComponent(typeof(ScoreView))]
public class Score : MonoBehaviour, IScoreChangable
{
    [SerializeField] private int _score;

    private void OnEnable()
    {
        GameplayEventHandler.OnScoreInitialized += Increase;
    }

    private void OnDisable()
    {
        GameplayEventHandler.OnScoreInitialized -= Increase;
    }

    public void Increase(int score)
    {
        _score += score;

        GameplayEventHandler.SendScoreChanged(_score);
    }

    public void Decrease(int score)
    {
        _score -= score;

        GameplayEventHandler.SendScoreChanged(_score);
    }
}