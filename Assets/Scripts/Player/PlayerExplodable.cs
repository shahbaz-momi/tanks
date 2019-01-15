using UnityEngine;

public class PlayerExplodable : MonoBehaviour, Explodable
{
    public bool destructable = true;

    public void Explode(object caller, float pwr)
    {
        // this player has just been rekt, destroy him
        if(destructable)
            GameObject.Destroy(gameObject);
    }

    public string GetTag()
    {
        return GetHashCode() + "";
    }

    public bool DoShowIndirectExplosions()
    {
        return true;
    }

    public MonoBehaviour GetMono()
    {
        return this;
    }

    public bool DoShowExplosion()
    {
        return true;
    }

}
