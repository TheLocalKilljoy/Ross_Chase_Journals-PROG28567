using Unity.VisualScripting;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public GameObject square;

    void Update()
    {
        //creates a vector 2 to get the position of where the mouse is
        Vector2 mousePos = Input.mousePosition;

        //creates a vector 2 and sets it equal to the mouse position in the screen space, keeping it on screen
        Vector2 pos = new Vector2();
        pos = Camera.main.ScreenToWorldPoint(mousePos);

        //creates 4 new vector 2s as the points of the square around the mouse 
        Vector2 topLeft = new Vector2(-1, 1);
        Vector2 topRight = new Vector2(1, 1);
        Vector2 bottomLeft = new Vector2(-1, -1);
        Vector2 bottomRight = new Vector2(1, -1);

        //function that only runs if the user clicks the left mouse button
        if (Input.GetMouseButton(0))
        {
            //creates 4 lines in a square around the mouse position
            Debug.DrawLine(pos + topLeft, pos + topRight);
            Debug.DrawLine(pos + bottomLeft, pos + bottomRight);
            Debug.DrawLine(pos + topLeft, pos + bottomLeft);
            Debug.DrawLine(pos + topRight, pos + bottomRight);
        }

        square.transform.position = pos;
    }
}
