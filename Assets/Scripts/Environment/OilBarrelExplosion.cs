using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBarrelExplosion : MonoBehaviour, Explodable
{
    public GameObject explosion;

    public float BarrelExplosionPwr = 3f;

    private List<Collider2D> colliders = new List<Collider2D>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            return;
        }

        if(!colliders.Contains(other))
        {
            colliders.Add(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(colliders.Contains(other))
        {
            colliders.Remove(other);
        }
    }

    public bool DoShowExplosion()
    {
        return false;
    }

    public bool DoShowIndirectExplosions()
    {
        return false;
    }

    public void Explode(object caller, float pwr) /* pwr is insignifact to us */
    {
        // create large explosion
        GameObject o = Instantiate(explosion, transform.position + new Vector3(0.5f, -0.5f), transform.rotation) as GameObject;
        o.transform.localScale = new Vector3(3f, 3f, 1f);
        o.gameObject.GetComponentInChildren<PointEffector2D>().forceMagnitude *= 2f;
        o.gameObject.GetComponent<PostAnimDestruct>().EffectorDestroyDelay *= 3f;

        // affect any one in area of explosion using the circle collider
        Collider2D[] objects = colliders.ToArray();
        if(objects != null && objects.Length > 0)
        {
            for(int i = 0; i < objects.Length; i ++)
            {
                Collider2D other = objects[i];
                if(other != null && other.gameObject != null)
                {
                    Explodable expl = other.gameObject.GetComponent(typeof(Explodable)) as Explodable;
                    if(expl != null)
                    {
                        // show an explosion at that point
                        expl.GetMono().StartCoroutine(ShowExplosion(other.transform.position, other.transform.rotation, expl, 0.1f));
                    }
                } else
                {
                    // remove from list
                    OnTriggerExit2D(other);
                }
            }

        }

        gameObject.SetActive(false);
        // destroy self after 3 seconds
        Destroy(gameObject, 3f);
    }

    public MonoBehaviour GetMono()
    {
        return this;
    }

    public string GetTag()
    {
        return GetHashCode() + "";
    }

    public IEnumerator ShowExplosion(Vector3 pos, Quaternion rotation, Explodable expl, float delay)
    {
        yield return new WaitForSeconds(delay);

        if(expl.DoShowIndirectExplosions())
            Instantiate(explosion, pos, rotation);
        // explode it for real
        expl.Explode(this, BarrelExplosionPwr);
    }
}
