using UnityEngine;
using System.Collections;

public class PowerupManager : MonoBehaviour
{
    public Sprite Bolt, Shield, Star;

    public Powerup[] POWERUPS;

    private readonly System.Random random = new System.Random();

    void Start()
    {
        Powerup[] a =
        {
            new Powerup("Bolt", Bolt, 0),
            new Powerup("Shield", Shield, 1),
            new Powerup("EMP", Star, 2)
        };

        POWERUPS = a;
    }

    public Powerup GetRandomPowerup()
    {
        return POWERUPS[random.Next(POWERUPS.Length)];
    }
}
