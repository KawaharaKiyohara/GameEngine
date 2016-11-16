using UnityEngine;
using System.Collections;

public class BulletShotSE : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        AudioSource s = GetComponent<AudioSource>();
        if (!s.isPlaying)
        {
            Destroy(gameObject);
        }
	}
}
