using UnityEngine;
using System.Collections;

public class DefaultExplodable : MonoBehaviour, Explodable
{

    public bool DoShowExplosion_ = true, DoShowIndirectExplosions_ = true;

    public void Explode(object caller, float pwr)
    {
        // do nothing
    }

    public bool DoShowExplosion()
    {
        return DoShowExplosion_;
    }

    public bool DoShowIndirectExplosions()
    {
        return DoShowIndirectExplosions_;
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
