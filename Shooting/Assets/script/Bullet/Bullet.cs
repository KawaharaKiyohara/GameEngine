﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public Vector3 moveDir;
    public GameObject EnemyExplosion;
    Camera mainCamera;
    float explosionTimer = 0;
    // Use this for initialization
    void Start () {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); ;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.localPosition;
        pos += moveDir * 0.05f;
        transform.localPosition = pos;
        pos = mainCamera.WorldToScreenPoint(pos);
        if((int)pos.x < mainCamera.pixelRect.xMin
            || (int)pos.x > mainCamera.pixelRect.xMax
            || (int)pos.y < mainCamera.pixelRect.yMin
            || (int)pos.y > mainCamera.pixelRect.yMax
        )
        {
            //画面外。
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "EnemyBullet" && collider.gameObject.GetComponent<Bullet1>() != null)
        {
            RequestExplosion(0.0f);
        }
    }
    IEnumerator Explosion()
    {
        while (true)
        {
            explosionTimer -= Time.deltaTime;
            if(explosionTimer < 0.0f)
            {
                break;
            }
            yield return null;
        }
        Destroy(gameObject);
        GameObject Ps = Object.Instantiate(EnemyExplosion);
        Ps.transform.localPosition = transform.localPosition;
        SoundManager.instance.RequestPlayExplosionSound();
    }
    /// <summary>
    /// 破壊リクエスト。
    /// </summary>
    public void RequestExplosion(float explosionTimer)
    {
        this.explosionTimer = explosionTimer;
        StartCoroutine(Explosion());
    }
}
