using UnityEngine;
using System.Collections;

public class Bullet1 : MonoBehaviour {
    public float moveSpeed = 0.1f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.localPosition;
        pos.y += moveSpeed;
        transform.localPosition = pos;
        MeshRenderer mr = GetComponent<MeshRenderer>();
        if (mr.isVisible == false)
        {
            //画面外に行った。
            Destroy(gameObject);
        }
    }
}
