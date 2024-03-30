using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DistinctColors
{
    public static readonly Color LightBlue = new Color(0.678f, 0.847f, 0.902f);
    public static readonly Color LightGreen = new Color(0.565f, 0.804f, 0.565f);
    public static readonly Color LightYellow = new Color(1f, 1f, 0.941f);
    public static readonly Color LightPink = new Color(1f, 0.714f, 0.757f);
    public static readonly Color LightOrange = new Color(1f, 0.843f, 0f);
    public static readonly Color LightPurple = new Color(0.902f, 0.902f, 0.980f);
    public static readonly Color LightCyan = new Color(0.878f, 1f, 1f);
    public static readonly Color Aqua = new Color(0f, 1f, 1f);
    public static readonly Color Lavender = new Color(0.902f, 0.902f, 0.980f);
    public static readonly Color Sage = new Color(0.596f, 0.984f, 0.596f);
    public static readonly Color Coral = new Color(1f, 0.498f, 0.314f);
    public static readonly Color Amber = new Color(1f, 0.749f, 0f);
    public static readonly Color DarkLavender = new Color(0.482f, 0.408f, 0.933f);
    public static readonly Color DarkTurquoise = new Color(0f, 0.807f, 0.819f);
    public static readonly Color DarkPink = new Color(1f, 0.078f, 0.576f);
    public static readonly Color Lime = new Color(0f, 1f, 0f);

    public static readonly List<Color> colors = new List<Color>
    {
        LightBlue, LightGreen, LightYellow, LightPink, LightOrange,
        LightPurple, LightCyan, Aqua, Lavender, Sage, Coral, Amber,
        DarkLavender, DarkTurquoise, DarkPink, Lime
    };
}


public class ColorEnum
{
    public List<Color> colors;

    public ColorEnum()
    {
        colors = DistinctColors.colors;
    }

    public Color GetRandomColor()
    {
        int index = Random.Range(0, colors.Count);
        Color c = colors[index];
        colors.RemoveAt(index);
        return c;
    }
    
    
    
}
