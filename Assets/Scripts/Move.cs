using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using UnityEngine;

public class Move : MonoBehaviour
{
    float moveSpeed = 3f;
    public GameObject prefabsnowBall;
    float force = 20;
    GameObject snowBall;
    Vector3 touchPosition;
    Vector3 tempSize;

    void Update()
    {

        if (Input.touchCount > 0)
        {
            // The screen has been touched so store the touch
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    snowBall = Instantiate(prefabsnowBall, transform.position + (transform.forward * 1.5f), transform.rotation);
                    snowBall.transform.parent = gameObject.transform;
                    break;

                case TouchPhase.Moved:
                    touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                    transform.LookAt(new Vector3(touchPosition.x, transform.position.y, touchPosition.z));
                    transform.position = Vector3.Lerp(transform.position, touchPosition, moveSpeed * Time.deltaTime);
                    tempSize = snowBall.transform.localScale;
                    tempSize.x += Time.deltaTime * 2f;
                    tempSize.y += Time.deltaTime * 2f;
                    tempSize.z += Time.deltaTime * 2f;
                    snowBall.transform.localScale = tempSize;
                    break;

                case TouchPhase.Stationary:
                    touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                    transform.LookAt(new Vector3(touchPosition.x, transform.position.y, touchPosition.z));
                    transform.position = Vector3.Lerp(transform.position, touchPosition, moveSpeed * Time.deltaTime);
                    break;

                case TouchPhase.Ended:
                    snowBall.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
                    break;
            }
        }
    }

}


