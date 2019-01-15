using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class ProgressBar : MonoBehaviour
{

    public float MinScale;
    public float MaxScale = 0.65f;

    public Color MaxColor = Color.green;
    public Color MidColor = Color.yellow;
    public Color MinColor = Color.red;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        SetProgress(1f);
    }

    public void SetProgress(float prog)
    {
        // set the scale based on the progress
        var newScale = MinScale + ((MaxScale - MinScale) * prog);
        transform.localScale = new Vector3(newScale, transform.localScale.y, transform.localScale.z);

        // transform the color from one to the other
        if (prog > 0.5f) {
            var colorScale = (prog - 0.5f) * 2f;
            // interpolate between the max and mid color
            sr.color = new Color(
                (MaxColor.r - MidColor.r) * colorScale + MidColor.r,
                (MaxColor.g - MidColor.g) * colorScale + MidColor.g,
                (MaxColor.b - MidColor.b) * colorScale + MidColor.b
                );
        } else if (prog < 0.5f) {
            var colorScale = prog * 2f;

            // interpolate between the mid and max color
            sr.color = new Color(
                (MidColor.r - MinColor.r) * colorScale + MinColor.r,
                (MidColor.g - MinColor.g) * colorScale + MinColor.g,
                (MidColor.b - MinColor.b) * colorScale + MinColor.b
                );
        } else {
            // exactly 0.5f, so mid color
            sr.color = MidColor;
        }
    }
}
