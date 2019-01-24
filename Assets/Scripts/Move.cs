using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float moveSpeed = 1.5f;
    public GameObject prefabsnowBall;
    private float force = 4;
    private bool allowInstance = true;
    private GameObject snowBall;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            // The screen has been touched so store the touch
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                    snowBall = Instantiate(prefabsnowBall, transform.position + (transform.forward * 0.5f), transform.rotation);
                    snowBall.transform.parent = gameObject.transform;
            }

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // If the finger is on the screen, move the object smoothly to the touch position
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                transform.LookAt(new Vector3(touchPosition.x, transform.position.y, touchPosition.z));
                transform.position = Vector3.Lerp(transform.position, touchPosition, moveSpeed * Time.deltaTime);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                snowBall.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
            }
        }
    }

}


