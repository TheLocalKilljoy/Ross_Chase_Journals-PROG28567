using UnityEngine;

public class Pipeline : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mousePos = Input.mousePosition;
            Vector2 pos = new Vector2();
            pos = Camera.main.ScreenToWorldPoint(mousePos);

            Debug.Log(pos);
        }
    }
}
