using UnityEngine;
using System.Collections;

public class PlayerPickUp : MonoBehaviour
{

    public float SuckUpRange = 0.5f;

    void OnTriggerStay2D(Collider2D other)
    {
        // if distance is less than PICKUP_RANGE, init suck up protocol
        if ((other.transform.position - transform.position).magnitude <= SuckUpRange)
        {
            // other should have a powerup attached to it
            var pc = other.gameObject.GetComponent<PowerupComponent>();
            pc.Apply(transform.parent.gameObject);
        }
    }
}
