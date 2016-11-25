using UnityEngine;
using System.Collections;

public class ExplosionSound : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        AudioSource s = GetComponent<AudioSource>();
        if(s.isPlaying == false)
        {
            Destroy(gameObject);
        }
	}
}
