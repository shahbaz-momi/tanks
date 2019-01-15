using UnityEngine;
using System.Collections;

public class Waypoints : MonoBehaviour {

    public GameObject[] points;

    public float moveForce = 5f;

    public GameObject barrel;

    public int moveCooldown = 100;

    private int current;
    private Rigidbody2D body;
    private Animator animator;
    private MissleLauncher missleLauncher;

	// Use this for initialization
	void Start () {
        // set current to a random point
        current = Random.Range(0, points.Length);
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        missleLauncher = barrel.GetComponent<MissleLauncher>();
    }

    private int frame = 0;

    private float currentAngle;

    private bool hasArrived;

	// Update is called once per frame
	void Update () {
	    // check if we have reached the current point
        if(transform.position == points[current].transform.position)
        {
            hasArrived = true;

            frame++;

            if(frame >= moveCooldown)
            {
                // new random position that is not the same
                int newPos = current;

                while(newPos == current)
                {
                    newPos = Random.Range(0, points.Length);
                }

                current = newPos;
                frame = 0;
                hasArrived = false;
            }

            animator.SetFloat("speed", 0f);
        }
        else
        {
            Vector2 target = new Vector2(points[current].transform.position.x, points[current].transform.position.y);

            Vector2 newPos = Vector2.MoveTowards(body.position, target, moveForce);

            // compute delta for input things
            Vector2 normalizedMovement = Vector2.MoveTowards(body.position, target, 1f);
            Vector2 delta = body.position - normalizedMovement;

            body.MovePosition(newPos);

            animator.SetFloat("speed", 1f);

            currentAngle = Mathf.Rad2Deg * Mathf.Atan2(delta.y, delta.x) + 90;
            body.MoveRotation(currentAngle);
        }
    }

    public float GetCurrentAngle()
    {
        return currentAngle;
    }

    public GameObject GetCurrentPoint()
    {
        return points[current];
    }

    public bool HasArrived()
    {
        return hasArrived;
    }

    public MissleLauncher GetMissleLauncher()
    {
        return missleLauncher;
    }
}
