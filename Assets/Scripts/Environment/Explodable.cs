using UnityEngine;
using UnityEngine.Internal;

public interface Explodable
{

    void Explode(object caller, float pwr);

    bool DoShowExplosion();

    bool DoShowIndirectExplosions();

    MonoBehaviour GetMono();

    string GetTag();
}
