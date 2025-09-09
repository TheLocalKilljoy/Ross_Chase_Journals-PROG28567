using UnityEngine;

public class RowGeneration : MonoBehaviour
{
    Vector2 startPos = new Vector2(-8, 0);

    public void Generator()
    {
        SquareDraw();
    }

    void SquareDraw()
    {
        Debug.DrawLine(startPos, startPos + new Vector2(0, 1), Color.white, 1000f * Time.deltaTime);
        Debug.DrawLine(startPos, startPos + new Vector2(1, 0), Color.white, 1000f * Time.deltaTime);
        Debug.DrawLine(startPos + new Vector2(1, 1), startPos - new Vector2(0, -1), Color.white, 1000f * Time.deltaTime);
        Debug.DrawLine(startPos + new Vector2(1, 1), startPos - new Vector2(-1, 0), Color.white, 1000f * Time.deltaTime);
    }
}
