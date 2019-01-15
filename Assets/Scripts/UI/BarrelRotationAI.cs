using UnityEngine;
using System.Collections;

public class BarrelRotationAI : MonoBehaviour {

    private float prevAngle = 0f;
    private Waypoints waypoints;

    // Use this for initialization
    void Start () {
        waypoints = GetComponentInParent<Waypoints>();
	}

    private bool hasShot = false;

	// Update is called once per frame
	void Update () {
        BarrelAngle angle = waypoints.GetCurrentPoint().GetComponent<BarrelAngle>();
	    if(!waypoints.HasArrived())
        {
            hasShot = false;

            // set angle to 0
            transform.Rotate(0, 0, -prevAngle);

            prevAngle = 0;
        } else if(angle.angle != -1)
        {
            // arrived, set to new angle
            float bAngle = Mathf.Lerp(prevAngle, angle.angle - waypoints.GetCurrentAngle(), 0.2f);

            transform.Rotate(0, 0, bAngle - prevAngle);

            prevAngle = bAngle;

            if (Mathf.Abs(prevAngle - (angle.angle - waypoints.GetCurrentAngle())) <= 0.1f && angle.shoot && !hasShot)
            {
                // shoot
                waypoints.GetMissleLauncher().Shoot();
                // set has shot to true
                hasShot = true;
            }
        }
	}
}
