using UnityEngine;

public class CrateExplodable : MonoBehaviour, Explodable
{

    public GameObject PowerupGameObject;

    private Animator anim;
    private BoxCollider2D bCollider;
    private AudioSource audioS;

    void Start()
    {
        anim = GetComponent<Animator>();
        bCollider = GetComponent<BoxCollider2D>();
        audioS = GetComponent<AudioSource>();
    }

    public void Explode(object caller, float pwr)
    {
        // remove box collider
        bCollider.enabled = false;

        // set off trigger
        anim.SetTrigger("Explode");
        // destroy after animation
        Destroy(gameObject, 3f);

        audioS.PlayDelayed(0.1f);
        // spawn in powerup
        Instantiate(PowerupGameObject, transform.position, Quaternion.identity);
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
        return GetHashCode() + ":CrateExplodable";
    }

}
