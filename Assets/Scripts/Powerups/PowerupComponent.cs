using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class PowerupComponent : MonoBehaviour
{

    public Powerup Type;
    private Animator animator;
    private new AudioSource audio;

	void Start ()
	{
	    var pm = GameObject.FindGameObjectWithTag("PowerupManager").GetComponent<PowerupManager>();
	    Type = pm.GetRandomPowerup();

	    GetComponent<SpriteRenderer>().sprite = Type.Texture;

	    animator = GetComponent<Animator>();
	    audio = GetComponent<AudioSource>();
	}

    private bool isApplied;

    public void Apply(GameObject o)
    {
        if (!isApplied)
        {
            // start fade out sequence
            animator.SetTrigger("PickUp");
            // play boop sound
            audio.Play();

            isApplied = true;

            // destroy after 0.3s
            Destroy(gameObject, 0.3f);

            // apply to the other
            var p = o.GetComponent(typeof(PowerupAffectable)) as PowerupAffectable;
            if (p != null)
            {
                p.ApplyPowerup(Type);
            }
        }
    }
}
