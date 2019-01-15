using System;
using UnityEngine;

[Serializable]
public class Powerup
{

    public readonly string Name;
    public readonly Sprite Texture;
    public readonly int Type;

    public Powerup(string name, Sprite texture, int type)
    {
        Name = name;
        Texture = texture;
        Type = type;
    } 
}
