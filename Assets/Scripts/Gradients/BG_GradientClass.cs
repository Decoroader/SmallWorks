using System.Collections;
using UnityEngine;

public class BG_GradientClass : MonoBehaviour
{
    [SerializeField] private Gradient gradient;

    void Start()
    {
        gradient = new Gradient()
        {
            alphaKeys = new[]
            {
                new GradientAlphaKey(0.11f, 0.11f),
                new GradientAlphaKey(0.11f, 0.11f)
            },

            colorKeys = new[]
            {
                new GradientColorKey(Color.red, 0f),
                new GradientColorKey(new Color(1f, 0.5f, 0f), 0.17f),
                new GradientColorKey(Color.yellow, 0.34f),
                new GradientColorKey(Color.green, 0.51f),
                new GradientColorKey(Color.cyan, 0.73f),
                new GradientColorKey(Color.blue, 0.9f),
                new GradientColorKey(new Color(1f, 0f, 1f), 1f)
            }
        };

        // What's the color at the relative time 0.25 (25 %) ?
        Debug.Log(gradient.Evaluate(0.25f));
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.G))
            StartCoroutine(ColorTime());
    }
    IEnumerator ColorTime()
    {
        int c = 0;
        int timeColor = 300;
        while (c < timeColor)
        {
            gameObject.GetComponent<Renderer>().material.color = gradient.Evaluate((float)c/timeColor);
            yield return new WaitForFixedUpdate();
            c++;
        }
    }
}