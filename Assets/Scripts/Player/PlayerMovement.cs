using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 5f, angleLerpTime = 0.2f;

    public float ambientLight = 10f;

    private Rigidbody2D body;
    private Animator animator;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}

    private float currentAngle = 0f, newAngle = 0f;

	// Update is called once per frame
	void Update () {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1f);
        body.MovePosition(body.position + input * moveSpeed);

        float angle = Mathf.Rad2Deg * Mathf.Atan2(input.y, input.x) - 90;
        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
            newAngle = angle;

        if(newAngle != currentAngle)
        {
            float f = Mathf.LerpAngle(currentAngle, newAngle, angleLerpTime);
            currentAngle = f;
            body.MoveRotation(f);
        }

        animator.SetFloat("speed", input.magnitude);
	}

    public float GetCurrentAngle()
    {
        return currentAngle;
    }

}
