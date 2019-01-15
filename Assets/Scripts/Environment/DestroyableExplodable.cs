using UnityEngine;
using System.Collections;

public class DestroyableExplodable : MonoBehaviour, Explodable
{

    public float DestroyPwr = 2f;

    public GameObject wallNN, wallNE, wallEE, wallSE, wallSS, wallSW, wallWW, wallNW;

    public void Explode(object caller, float pwr)
    {
        // determine distance of object
        var distance = (caller as Explodable).GetMono().transform.position - transform.position;
        pwr /= distance.magnitude;

        if (pwr >= DestroyPwr)
        {
            // destroy this
            Destroy(gameObject);
            return;
        }

        Vector2 otherPos = ((MonoBehaviour) caller).gameObject.transform.position;
        // get angle between us and other
        float ang = AngleBetweenVector2(transform.position, otherPos);
        if (ang < 0)
            ang += 360;

        // map of angles
        //  NW       NN       NE
        //     135 120 90 60 45
        //    150 X X X X X 30
        // WW 180 X X X X X 0 EE
        //    210 X X X X X 330
        //   225 240 270 300 315
        // SW       SS       SE
        object o = null;
        if (Within(ang, 0, 30) || Within(ang, 330, 360)) // EE
        {
            o = Instantiate(wallEE, transform.position, transform.rotation);
        } else if (Within(ang, 30, 60)) // NE
        {
            o = Instantiate(wallNE, transform.position, transform.rotation);
        }
        else if (Within(ang, 60, 120)) // NN
        {
            o = Instantiate(wallNN, transform.position, transform.rotation);
        }
        else if (Within(ang, 120, 150)) // NW
        {
            o = Instantiate(wallNW, transform.position, transform.rotation);
        }
        else if (Within(ang, 150, 210)) // WW
        {
            o = Instantiate(wallWW, transform.position, transform.rotation);
        }
        else if (Within(ang, 210, 240)) // SW
        {
            o = Instantiate(wallSW, transform.position, transform.rotation);
        }
        else if (Within(ang, 240, 300)) // SS
        {
            o = Instantiate(wallSS, transform.position, transform.rotation);
        }
        else if (Within(ang, 300, 330)) // SE
        {
            o = Instantiate(wallSE, transform.position, transform.rotation);
        }
        if (o == null)
        {
            print("Unable to create new wall!");
        }
        Destroy(gameObject);
    }

    private static bool Within(float ang, float lower, float upper)
    {
        return ang >= lower && ang <= upper;
    }

    public bool DoShowExplosion()
    {
        return true;
    }

    public bool DoShowIndirectExplosions()
    {
        return false;
    }

    public MonoBehaviour GetMono()
    {
        return this;
    }

    public string GetTag()
    {
        return GetHashCode() + ":DestroyableExplodable";
    }

    public static float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }
}
