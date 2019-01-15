using UnityEngine;
using System.Collections;

public class SelfDestructExplodable : MonoBehaviour, Explodable
{

    public bool ShowExplosion = true, ShowIndirectExplosions = true;

    public void Explode(object caller, float pwr)
    {
        Destroy(gameObject, 0);
    }

    public bool DoShowExplosion()
    {
        return ShowExplosion;
    }

    public bool DoShowIndirectExplosions()
    {
        return ShowIndirectExplosions;
    }

    public MonoBehaviour GetMono()
    {
        return this;
    }

    public string GetTag()
    {
        return GetHashCode() + "";
    }
}
