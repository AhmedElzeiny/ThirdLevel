using UnityEngine.UI;
using UnityEngine;

public class Fadeout : MonoBehaviour
{
   

    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 10.0f;

    bool faded;

    private float startTime;
    public Text Text;

    void Start()
    {
        startTime = Time.time;

        faded = true;

    }

    void Update()
    {
        float t = (Time.time - startTime) / duration;

        if (faded)
        {
            Text.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));
            if (t > 1f && Input.GetKeyDown(KeyCode.O))
            {
                faded = false;
                startTime = Time.time;
            }
        }
        else
        {
            Text.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
            if (t > 1f && Input.GetKeyDown(KeyCode.O))
            {
                faded = true;
                startTime = Time.time;
            }
        }
    }
}

