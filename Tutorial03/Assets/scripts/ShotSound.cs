using UnityEngine;
using System.Collections;

public class ShotSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        AudioSource source = GetComponent<AudioSource>();
        if (source.isPlaying == false)
        {
            Object.Destroy(gameObject);
        }
	}
}
