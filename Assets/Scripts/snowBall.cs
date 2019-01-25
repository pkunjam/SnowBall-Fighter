using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class snowBall : MonoBehaviour
{
    const float lifeSeconds = 20;
    Timer deathTimer;
    float force = 5;
    void Start()
    {
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = lifeSeconds;
        deathTimer.Run();
    }

    void Update()
    {

        if (deathTimer.Finished)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("collision");
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(4f,4f,4f) * force, ForceMode.Impulse);
        }
    }
    //public void ApplyForce(Vector3 forceDirection)
    //{
    //    const float forceMagnitude = 10;
    //    GetComponent<Rigidbody>().AddForce(
    //        forceMagnitude * forceDirection,
    //        ForceMode.Impulse);
    //}

}
