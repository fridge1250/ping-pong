using UnityEngine;

public static class Utility
{
    public static float SetRandomFloatValue(float min, float max)
    {
        var result = Random.Range(min, max);

        return result;
    }

    public static int SetRandomIntValue(int min, int max)
    {
        var result = Random.Range(min, max);

        return result;
    }
}