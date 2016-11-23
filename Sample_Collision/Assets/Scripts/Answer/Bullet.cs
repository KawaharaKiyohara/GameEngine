using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0.0f, 100.0f, 1000.0f);
        rb.AddForce(force);

    }
	
	// Update is called once per frame
	void Update () {
        /*Vector3 pos = transform.localPosition;
        pos.z += 0.1f;
        transform.localPosition = pos;*/
	}
}
