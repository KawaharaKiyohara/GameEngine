﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject bulletOriginal;
    float timer = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float moveSpeed = 0.1f;
        Vector3 pos = transform.localPosition;
        pos.x += Input.GetAxis("Horizontal") * moveSpeed;
        pos.y += Input.GetAxis("Vertical") * moveSpeed;
        transform.localPosition = pos;
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer > 0.05f)
        {
            GameObject newBullet = Object.Instantiate(bulletOriginal);
            newBullet.transform.localPosition = transform.localPosition;
            Bullet bullet = newBullet.GetComponent<Bullet>();
            bullet.moveDir.y = 1.0f;
            //to 井上 弾丸の発射のSEを再生する。
            //Unityのサウンドの出し方を調べるように。
            timer = 0.0f;
        }

	}
}
