using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public Vector3 moveDir;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.localPosition;
        pos += moveDir * 0.2f;
        transform.localPosition = pos;
        if(gameObject.GetComponent<Renderer>().isVisible == false)
        {
            //画面外に行ったら削除。
            Object.Destroy(gameObject);
        }
	}
}
