using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ObjectiveExplodable : MonoBehaviour, Explodable
{

    public const float MAX_HEALTH = 30f;

    public ProgressBar ProgressBar;

    private AudioSource aSource;
    private Animator animator;

    private float health = MAX_HEALTH;

	void Start ()
	{
	    aSource = GetComponent<AudioSource>();
	    animator = GetComponent<Animator>();
	}

    public void Explode(object caller, float pwr)
    {
        // play sound
        aSource.Play();
        animator.SetTrigger("Damaged");
        // damage the objective itself
        health -= pwr;
        ProgressBar.SetProgress(health / MAX_HEALTH);
    }

    public bool DoShowExplosion()
    {
        return false;
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
        return GetHashCode() + ":Objective";
    }
}
