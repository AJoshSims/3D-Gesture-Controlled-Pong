using UnityEngine;
using System.Collections;

public class BallBounce : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(6f, 0f, 6f);

    }
	
	// Update is called once per frame
	void Update () {
        if(rb.transform.position.z >= 51)
        {
            rb.transform.position = new Vector3(0f, 0f, 25.5f);
        
        }
        if(rb.transform.position.z <= -2.9)
        {
            rb.transform.position = new Vector3(0f, 0f, 25.5f);
        }
    }
}
