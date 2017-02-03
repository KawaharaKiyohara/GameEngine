using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    static readonly int NUM_BULLET_TYPE = 2;        //弾丸の種類。
    public Vector3 moveDir;
    public GameObject bulletOriginal;
    public GameObject EnemyExplosion;
    List<GameObject> goBullets = new List<GameObject>();
    //
    float timer = 0.0f;
    // Use this for initialization
    void Start()
    {
        GameObject gCamera = GameObject.Find("Main Camera");
        Camera cam = gCamera.GetComponent<Camera>();
        
        //初期位置に乱数を加える。
        float t = Random.Range(0.1f, 0.9f);

        Vector3 screenPos = new Vector3();
        screenPos.x = t * Screen.width;
        screenPos.y = Screen.height;
        Vector3 worldPos = cam.ScreenToWorldPoint(screenPos);
        worldPos.z = 0.0f; 
        transform.localPosition = worldPos;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            {
                //同心円状に飛ぶ弾丸を生成。
                float angle = 24.0f;
                //いくつ生成する。
                int numBullet = (int)( 360.0f / 15.0f ) ;
                for(int i = 0; i < numBullet; i++)
                {
                    GameObject newBullet = Object.Instantiate(bulletOriginal);
                    goBullets.Add(newBullet);
                    newBullet.transform.localPosition = transform.localPosition;
                    Bullet bullet = newBullet.GetComponent<Bullet>();
                    bullet.tag = "EnemyBullet";
                    bullet.moveDir.x = Mathf.Cos(Mathf.Deg2Rad * (angle * i));
                    bullet.moveDir.y = Mathf.Sin(Mathf.Deg2Rad * (angle * i));

                }

            }
            
            timer = 0.0f;
        }
        Vector3 pos = transform.localPosition;
        pos += moveDir * 0.01f;
        transform.localPosition = pos;
        if (GetComponentInChildren<Renderer>().isVisible == false)
        {
            Object.Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "EnemyBullet" && collider.gameObject.GetComponent<Bullet1>() != null)
        {
            GameObject Ps = Object.Instantiate(EnemyExplosion);
            Ps.transform.localPosition = transform.localPosition;
            //To 松澤
            //ここに機体が爆発する音を再生するコードを記入する。
            //Unityでの音の鳴らし方は自分で調べる。
            //弾丸と衝突した。
            Object.Instantiate(Resources.Load("prefab/ExprosionSound"));
            Object.Destroy(gameObject);
            //スコアを加算する。
            GameObject scoreGo = GameObject.Find("Score");
            Score s = scoreGo.GetComponent<Score>();
            s.point += 10;
            EnemyManager.instance.numEnemy--;
        }
    }
}
