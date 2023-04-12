using System;

public class GameplayEventHandler
{
    public static event Action<int> OnScoreInitialized;
    public static event Action<int> OnScoreChanged;

    public static event Action<float> OnHorizontalDirectionChanged;
    public static event Action<float> OnVerticalDirectionChanged;

    public static void SendScoreInitialized(int amount)
    {
        if (OnScoreInitialized != null)
        {
            OnScoreInitialized?.Invoke(amount);
        }
    }

    public static void SendScoreChanged(int amount) 
    {
        if (OnScoreChanged != null)
        {
            OnScoreChanged?.Invoke(amount);
        }
    }

    public static void SendHorizontalDirectionChanged(float direction)
    {
        if (OnHorizontalDirectionChanged != null)
        {
            OnHorizontalDirectionChanged?.Invoke(direction);
        }
    }

    public static void SendVerticalDirectionChanged(float direction)
    {
        if (OnVerticalDirectionChanged != null)
        {
            OnVerticalDirectionChanged?.Invoke(direction);
        }
    }
}