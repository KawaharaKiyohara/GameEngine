﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public Vector3 moveDir;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.localPosition;
        pos += moveDir * 0.02f;
        transform.localPosition = pos;
        if(GetComponentInChildren<Renderer>().isVisible == false)
        {
            Object.Destroy(gameObject);
        }
	}
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.GetComponent<Bullet>() != null)
        {
            //To 松澤
            //ここに機体が爆発す音を再生するコードを記入する。
            //Unityでの音の鳴らし方は自分で調べる。
            //弾丸と衝突した。
            Object.Destroy(gameObject);
        }
    }
}