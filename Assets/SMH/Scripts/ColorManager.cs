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

public class ColorManager : MonoBehaviour
{
    public ColorType[] colorList = {
        ColorType.White,
        ColorType.Red,
        ColorType.Blue,
        ColorType.Green,
        ColorType.Yellow
    };

    // Player sprites
    public Sprite[] playerSprites = new Sprite[5];

    public Sprite getSprite(int colorIndex)
    {
        return playerSprites[colorIndex];
    }

    public bool isSameColor(int playercolorIndex, int objectcolorIndex)
    {
        return playercolorIndex == objectcolorIndex;
    }

    public string getColor(int colorIndex)
    {
        return colorList[colorIndex].ToString();
    }
}