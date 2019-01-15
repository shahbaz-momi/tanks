using UnityEngine;

public class BulletController : MonoBehaviour, Explodable {

    public GameObject explosion;

    public BulletRanger ranger;

    public float BulletPwr = 1f;

    private Explodable parent;

	public void SetParentExplodable(Explodable e)
    {
        parent = e;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // don't collide with triggers except if its a bullet
        if (other.isTrigger && !other.CompareTag("Bullet"))
            return;

        // check if can blow up
        var explodable = other.GetComponent(typeof(Explodable)) as Explodable;

        if(explodable != null)
        {
            // check if parent
            if (explodable.GetTag().Equals(parent.GetTag()))
                return;

            Explode(explodable, BulletPwr);
        }
        else
        {
            Explode(other, BulletPwr);
        }
    }

    public void Explode(object other, float pwr)
    {
        print("Vibrate!");
        // Handheld.Vibrate();
        GameObject.Destroy(this.gameObject);
        if (other is Explodable)
        {
            Explodable e = other as Explodable;

            // check if its not a bullet as it will explode on its own
            if (!e.GetTag().Equals(GetTag()))
            {
                e.Explode(this, pwr);
            }
            else
            {
                // handle bullet double explosion, make sure only one explodes
                if(GetHashCode() > e.GetHashCode())
                    GameObject.Instantiate(explosion, transform.position, transform.rotation);

                return;
            }
        }

        // blow up the rest of the things
        if (ranger.Objects.Count != 0)
        {
            // blow those guys up aswell
            for (var i = 0; i < ranger.Objects.Count; i ++)
            {
                GameObject o = (GameObject) ranger.Objects[i];
                // trigger explosion if explodable
                var e = o.GetComponent(typeof(Explodable)) as Explodable;
                if (e != null && e != other)
                {
                    // explode it
                    e.Explode(this, pwr);
                    if (e.DoShowIndirectExplosions())
                    {
                        GameObject.Instantiate(explosion, o.transform.position, o.transform.rotation);
                    }
                }
                else if(e != other)
                {
                    // show explosions
                    GameObject.Instantiate(explosion, o.transform.position, o.transform.rotation);
                }
                
            }
        }

        if(other is Explodable && !(other as Explodable).DoShowExplosion())
        {
            // do nothing
        } else
        {
            GameObject.Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    // the default tag for a bullet is Bullet, so this way we know that we are hitting a bullet
    public string GetTag()
    {
        return "Bullet";
    }

    public MonoBehaviour GetMono()
    {
        return this;
    }

    public bool DoShowExplosion()
    {
        return true;
    }

    public bool DoShowIndirectExplosions()
    {
        return true;
    }
}
