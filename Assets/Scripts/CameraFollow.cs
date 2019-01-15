using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float animationSpeed = 0.1f;

    private Camera cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();	
	}

    private float shakeTimer, shakePwr;

    // Update is called once per frame
    void Update () {
        cam.orthographicSize = (Screen.height / 100f) / 2f;

        // if the target not null
        if(target)
        {
            // smooth panning
            transform.position = Vector3.Lerp(transform.position, target.position, animationSpeed) + new Vector3(0, 0, -10);
            // non smooth panning
            // transform.position = target.position + new Vector3(0, 0, -10);
        }

        if (shakeTimer > 0)
        {
            Vector2 v = Random.insideUnitCircle * shakePwr;
            transform.position = new Vector3(transform.position.x + v.x, transform.position.y + v.y, transform.position.z);
            shakeTimer -= Time.deltaTime;
        }
    }

    public void Shake(float time, float power)
    {
        shakeTimer = time;
        shakePwr = power;
    }
}
