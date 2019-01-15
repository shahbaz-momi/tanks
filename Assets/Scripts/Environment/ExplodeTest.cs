using UnityEngine;

public class ExplodeTest : MonoBehaviour, Explodable {
    
    public void Explode(object other, float pwr)
    {
        print("Ahhh... I exploded!");
    }

    public string GetTag()
    {
        return "ExplodableTest";
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
