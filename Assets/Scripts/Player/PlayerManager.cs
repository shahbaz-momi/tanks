using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour, PowerupAffectable {

    public void ApplyPowerup(Powerup p)
    {
        print("TODO: implement pick up of " + p.Name + " [Type:" + p.Type + "]");
    }

}
