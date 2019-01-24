using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    public GameObject prefabsnowBall;
    private Rigidbody rb;
    Vector3 thrustDirection;

    void Start()
    {
        thrustDirection = transform.forward;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GameObject snowBall = Instantiate(prefabsnowBall, transform.position + (transform.forward * 0.5f), transform.rotation) as GameObject;
                snowBall.transform.parent = gameObject.transform;
                //snowBall.GetComponent< Rigidbody > ().AddForce(transform.forward * moveSpeed, ForceMode.Impulse);
            }
    }
}