using UnityEngine;

public class PostAnimDestruct : MonoBehaviour {

    public float delay = 0f;

    public GameObject Effector;
    public float EffectorDestroyDelay = 0.1f;

    public bool forceEnableShake = true;

    void Start()
    {
        // add camera shake
        Vector3 point = Camera.main.WorldToViewportPoint(transform.position);
        // check if point is in space and then shake if it is
        if (((point.x >= 0 && point.y >= 0 && point.x <= 1 && point.y <= 1f) || forceEnableShake) && Camera.main.GetComponent<CameraFollow>() != null)
            Camera.main.GetComponent<CameraFollow>().Shake(0.08f, 0.1f);

        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        Destroy(Effector, EffectorDestroyDelay);
    }

}
