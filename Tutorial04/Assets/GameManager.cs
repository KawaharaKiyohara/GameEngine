using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject go = GameObject.Find("Cube");
            go.SendMessage("ApplyDamage");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameObject go = GameObject.Find("Cube");
            go.BroadcastMessage("ApplyDamage");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject go = GameObject.Find("Cube (2)");
            go.SendMessageUpwards("ApplyDamage");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Cube[] cubes = FindObjectsOfType<Cube>();
            foreach (Cube c in cubes)
            {
                c.ApplyDamage();
            } 
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag("Player");
            foreach( GameObject g in go)
            {
                g.SendMessage("ApplyDamage");
            }
        }
	}
    
}
