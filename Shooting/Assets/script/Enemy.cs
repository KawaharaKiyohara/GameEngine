using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public Vector3 moveDir;
    public GameObject bulletOriginal;
    float timer = 0.0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > 0.05f)
        {
            GameObject newBullet = Object.Instantiate(bulletOriginal);
            newBullet.transform.localPosition = transform.localPosition;
            Bullet bullet = newBullet.GetComponent<Bullet>();
            bullet.tag = "EnemyBullet";
            bullet.moveDir.y = -1.0f;
            timer = 0.0f;
        }
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
        if(collider.tag != "EnemyBullet" && collider.gameObject.GetComponent<Bullet>() != null)
        {
            //To 松澤
            //ここに機体が爆発す音を再生するコードを記入する。
            //Unityでの音の鳴らし方は自分で調べる。
            //弾丸と衝突した。
            Object.Destroy(gameObject);
            //スコアを加算する。
            GameObject scoreGo = GameObject.Find("Score");
            Score s = scoreGo.GetComponent<Score>();
            s.point += 10;
        }
    }
}
