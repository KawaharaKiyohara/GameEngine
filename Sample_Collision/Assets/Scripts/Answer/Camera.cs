using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
    GameObject goPlayer;
    Vector3 toEyePos;
	// Use this for initialization
	void Start () {
        //追尾するプレイヤーを取得。
        goPlayer = GameObject.Find("Player");
        toEyePos = transform.localPosition - goPlayer.transform.localPosition ;

    }
	
	// Update is called once per frame
	void Update () {
        //プレイヤーに追尾する。
        Vector3 eyePos = goPlayer.transform.localPosition + toEyePos;
        transform.localPosition = eyePos;
	}
}
