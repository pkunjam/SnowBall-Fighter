
using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    
    private float h;
    private float horizontalSpeed = 1.0f;
    private float moveSpeed = 3.0f;

    void Update()
    {
        if (Input.touchCount >0)
        {
            Touch touch = Input.GetTouch(0);

                h = horizontalSpeed * touch.deltaPosition.y;
                transform.Rotate(0, -h, 0);
                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }
}
