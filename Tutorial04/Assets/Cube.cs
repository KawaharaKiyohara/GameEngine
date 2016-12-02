using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ApplyDamage()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material.SetColor("_Color", Color.red);
        //Destroy(gameObject);
    }
    void OnMouseDown()
    {
        gameObject.BroadcastMessage("ApplyDamage");
    }
}
