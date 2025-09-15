using UnityEngine;

public class NormalizeExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(Normalizer(new Vector2(3, 4)));
        Debug.Log(Normalizer(new Vector2(-3,2)));
        Debug.Log(Normalizer(new Vector2(1.5f,-3.5f)));
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector2 Normalizer (Vector3 inVector) 
    {
        Vector3 normalize;

        float magnitude = inVector.magnitude;
        normalize = new Vector2(inVector.x/magnitude, inVector.y/magnitude);

        return normalize;
    }
}
