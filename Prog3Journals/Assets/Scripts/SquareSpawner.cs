using Unity.VisualScripting;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 pos = new Vector2();
        pos = Camera.main.ScreenToWorldPoint(mousePos);


        Vector2 topLeft = new Vector2(-1, 1);
        Vector2 topRight = new Vector2(1, 1);
        Vector2 bottomLeft = new Vector2(-1, -1);
        Vector2 bottomRight = new Vector2(1, -1);


        if (Input.GetMouseButton(0))
        {
            Debug.DrawLine(pos + topLeft, pos + topRight);
            Debug.DrawLine(pos + bottomLeft, pos + bottomRight);
            Debug.DrawLine(pos + topLeft, pos + bottomLeft);
            Debug.DrawLine(pos + topRight, pos + bottomRight);
        }
    }
}
