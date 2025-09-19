using System;
using Unity.VisualScripting;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    Vector2 pos = new Vector2();

    Vector2 newPos = new Vector2();

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            pos = Camera.main.ScreenToWorldPoint(mousePos);

            Debug.Log(pos);

            for (int i = 0; i < 10; i++) { }
            
            if (Input.GetMouseButtonDown(0) == true) 
            {
                newPos = Camera.main.ScreenToWorldPoint(mousePos);

                Debug.DrawLine(pos, newPos);

                Debug.Log(pos);

            }
        }
    }
}
