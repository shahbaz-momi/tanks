using UnityEngine;

public class BarrelRotation : MonoBehaviour {

    private PlayerMovement _movement;

	// Use this for initialization
	void Start () {
        _movement = GetComponentInParent<PlayerMovement>();
	}

    private float _prevAngle;

	// Update is called once per frame
	void Update () {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 bLoc = transform.position;

        float bAngle = AngleBetweenVector2(mouseRay.origin, bLoc) + 90 - _movement.GetCurrentAngle();

        transform.Rotate(0, 0, bAngle - _prevAngle);

        _prevAngle = bAngle;
    }

    public static float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }
}
