using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class snowBall : MonoBehaviour {

    private const float lifeSeconds = 30;
    private Timer deathTimer;

    void Start ()
    {
	    deathTimer = gameObject.AddComponent<Timer>();
	    deathTimer.Duration = lifeSeconds;
        deathTimer.Run();
	}
	
	// Update is called once per frame
	void Update () {

	    if (deathTimer.Finished)
	    {
            Destroy(gameObject);
	    }
	}

    public void ApplyForce(Vector3 forceDirection)
    {
        const float forceMagnitude = 10;
        GetComponent<Rigidbody>().AddForce(
            forceMagnitude * forceDirection,
            ForceMode.Impulse);
    }
}
