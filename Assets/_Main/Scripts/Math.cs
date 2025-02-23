using System;
using UnityEngine;

public class Math
{
    public static float TFromLerpLimits(float a, float b, float value)
    {
        float num = b - a;
        return Mathf.Clamp01((a + value) / num);
    }

    public static float Random(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    public static float Random(double min, double max)
    {
        return UnityEngine.Random.Range((float) min, (float) max);
    }

    public static int Random(int min, int max)
    {
        return UnityEngine.Random.Range(min, max + 1);
    }

    public static int Random(int min, int max, int step)
    {
        return UnityEngine.Random.Range(min / step, max / step) * step;
    }

    public static double Random(double min, double max, double step)
    {
        return (double) UnityEngine.Random.Range((float) (min / step), (float) (max / step)) * step;
    }

    public static float Random(float min, float max, float step)
    {
        return UnityEngine.Random.Range(min / step, max / step) * step;
    }

    public static T Random<T>(int min = 0)
    {
        Array values = Enum.GetValues(typeof(T));
        return (T) ((object) values.GetValue(Math.Random(min, values.Length - 1)));
    }

    public static bool Probably(int value)
    {
        return Math.Random(1, 100) <= value;
    }

    public static bool Probably()
    {
        return Math.Random(1, 100) <= 50;
    }

    public static bool Probably(double value)
    {
        return (double) Math.Random(0.001, 100.0) <= value;
    }

    public static int Chance(double value = 50.0)
    {
        if (!Math.Probably(value))
        {
            return -1;
        }

        return 1;
    }

    public static int Abs(int value)
    {
        return Mathf.Abs(value);
    }

    public static float Abs(float value)
    {
        return Mathf.Abs(value);
    }

    public static double Abs(double value)
    {
        return (double) Mathf.Abs((float) value);
    }

    public static int Max(int min, int max)
    {
        return Mathf.Max(min, max);
    }

    public static float Max(float min, float max)
    {
        return Mathf.Max(min, max);
    }

    public static double Max(double min, double max)
    {
        return (double) Mathf.Max((float) min, (float) max);
    }

    public static int Min(int min, int max)
    {
        return Mathf.Min(min, max);
    }

    public static float Min(float min, float max)
    {
        return Mathf.Min(min, max);
    }

    public static double Min(double min, double max)
    {
        return (double) Mathf.Min((float) min, (float) max);
    }

    public static int Range(int num, int min, int max)
    {
        return Mathf.Clamp(num, min, max);
    }

    public static float Range(float num, float min, float max)
    {
        return Mathf.Clamp(num, min, max);
    }

    public static double Range(double num, double min, double max)
    {
        return (double) Mathf.Clamp((float) num, (float) min, (float) max);
    }

    public static double Cos(double value)
    {
        return (double) Mathf.Cos((float) value);
    }

    public static double Sin(double value)
    {
        return (double) Mathf.Sin((float) value);
    }

    public static double Atan2(double x, double y)
    {
        return (double) Mathf.Atan2((float) x, (float) y);
    }

    public static double Rad2Deg(double value)
    {
        return value * 57.295780181884766;
    }

    public static double Deg2Rad(double value)
    {
        return value * 0.01745329238474369;
    }

    public static double Pow(double value, double pow)
    {
        return (double) Mathf.Pow((float) value, (float) pow);
    }

    public static double Lerp(double min, double max, double value)
    {
        return (double) Mathf.Lerp((float) min, (float) max, (float) value);
    }

    public static double Floor(double value)
    {
        return (double) Mathf.Floor((float) value);
    }

    public static double Round(double value)
    {
        return (double) Mathf.Round((float) value);
    }

    public static float WrapAngle(float angle)
    {
        angle %= 360f;
        if (angle > 180f)
        {
            return angle - 360f;
        }

        return angle;
    }

    public static float UnwrapAngle(float angle)
    {
        if (angle >= 0f)
        {
            return angle;
        }

        angle = -angle % 360f;
        return 360f - angle;
    }

    public static string Position(int value)
    {
        string result = string.Empty;
        int num = value % 10;
        if ((int) Math.Floor((double) value / 10.0) % 10 == 1)
        {
            result = "th";
        }
        else
        {
            switch (num)
            {
                case 1:
                    result = "st";
                    break;
                case 2:
                    result = "nd";
                    break;
                case 3:
                    result = "rd";
                    break;
                default:
                    result = "th";
                    break;
            }
        }

        return result;
    }

    public static float GetTriangle(float n)
    {
        return n * 0.5f * (n + 1f);
    }

    public static float InverceTriangle(float n)
    {
        return -0.5f + Mathf.Sqrt(0.25f + 2f * n);
    }
}