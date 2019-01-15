using UnityEngine;
using System.Collections;

public class MissleLauncher : MonoBehaviour {

    public float shotCooldown, bulletSpeed;

    public GameObject bulletOrg;

    public GameObject barrelSmoke;

    public AudioSource AudioSource;

    public bool ignoreMouseInput = false;

    private Animator animator, bSmokeAnim;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        bSmokeAnim = barrelSmoke.GetComponent<Animator>();
	}

    private float lastShot = 0;

	// Update is called once per frame
	void Update () {
        /* Replace this with the revalent way to detect missle shot requested */
        if(Input.GetMouseButtonDown(0) && !ignoreMouseInput) //Shoot missle
        {
            if(Time.time - lastShot > shotCooldown)
            {
                Shoot();

                lastShot = Time.time;
            }
        }
    }
    
    public void Shoot()
    {
        GameObject bull = Instantiate(bulletOrg, transform.position, transform.rotation) as GameObject;
        bull.SetActive(true);
        bull.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletSpeed));

        // get parent's parent's (Player) explodable object and set it to the bullet's parent
        Explodable playerExplodable = transform.parent.parent.gameObject.GetComponent(typeof(Explodable)) as Explodable;

        bull.GetComponent<BulletController>().SetParentExplodable(playerExplodable);

        animator.SetTrigger("shot");
        // add smoke shot effect
        bSmokeAnim.SetTrigger("shot");
        AudioSource.Play();
    }   
}
