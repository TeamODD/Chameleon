using UnityEngine;

// Player color enumeration
public enum ColorType
{
    White = 0,
    Red = 1,
    Blue = 2,
    Green = 3,
    Yellow = 4
}

public class ScriptManager : MonoBehaviour
{
    public ColorType[] colorList = {
        ColorType.White,
        ColorType.Red,
        ColorType.Blue,
        ColorType.Green,
        ColorType.Yellow
    };

    public bool isSameColor(int playercolorIndex, int objectcolorIndex)
    {
        return playercolorIndex == objectcolorIndex;
    }

    public string getColor(int colorIndex)
    {
        return colorList[colorIndex].ToString();
    }
}
