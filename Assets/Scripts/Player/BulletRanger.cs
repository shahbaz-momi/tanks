using UnityEngine;
using System.Collections;

public class BulletRanger : MonoBehaviour {

    public ArrayList Objects = new ArrayList();

    public bool IgnoreTriggers = true;
    public bool IgnorePlayer = false;

    void Update()
    {
        // set the same position as parent
        transform.position = transform.parent.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet") || (other.gameObject.CompareTag("Player") && IgnorePlayer) || (IgnoreTriggers && other.isTrigger))
            return;
        if (!Objects.Contains(other.gameObject))
            Objects.Add(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet") || (other.gameObject.CompareTag("Player") && IgnorePlayer) || (IgnoreTriggers && other.isTrigger))
            return;
        if (Objects.Contains(other.gameObject))
            Objects.Remove(other.gameObject);
    }
}
