using UnityEngine;
using System.Collections;
using System;

public class Boss : MonoBehaviour {
    BossEnter bossEnter;
    Camera mainCamera;
    BossDamageEffect bossDamageEffect;
    public GameObject bulletOriginal;
    public GameObject EnemyExplosion;
    enum State
    {
        Enter,      //入場。
        Battle,     //バトル。
        Dead,       //死亡。
    };
    State state = State.Enter;
    float timer = 0.0f;
    Vector3 moveDir = new Vector3(1.0f, 0.0f, 0.0f);
    public int HP = 500;
    // Use this for initialization
    void Start () {
        bossEnter = gameObject.AddComponent<BossEnter>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case State.Enter:
                if (!bossEnter)
                {
                    state = State.Battle;
                }
                break;
            case State.Battle:
                UpdateStateBattle();
                Debug.Log("State.Battle");
                break;
            case State.Dead:
                UpdateStateDead();
                break;
        }
	}
    /// <summary>
    /// 死亡状態の時の更新処理。
    /// </summary>
    private void UpdateStateDead()
    {
        if(UnityEngine.Random.Range(0, 100) < 20)
        {
            //20%の確率で爆発パーティクルを発生させる。
            GameObject Ps = UnityEngine.Object.Instantiate(EnemyExplosion);
            BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
            Ps.transform.parent = transform;
            Vector3 pos = boxCollider.center;
            Vector3 halfSize = boxCollider.size * 0.4f;
            pos.x += UnityEngine.Random.Range(-halfSize.x, halfSize.x);
            pos.y += UnityEngine.Random.Range(-halfSize.y, halfSize.y);
            Ps.transform.localPosition = pos;
        }
        Vector3 scale = transform.localScale;
        scale *= 0.997f;
        transform.localScale = scale;
    }

    private void UpdateStateBattle()
    {
        Vector3 oldPos = transform.localPosition;
        Vector3 pos = transform.localPosition;
        pos += moveDir * 0.05f;
        transform.localPosition = pos;
        Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);
        float margin = mainCamera.pixelWidth * 0.2f;
        if(screenPos.x < mainCamera.pixelRect.xMin + margin)
        {
            moveDir.x = 1.0f;
            transform.localPosition = oldPos;
        }
        if (screenPos.x > mainCamera.pixelRect.xMax - margin)
        {
            moveDir.x = -1.0f;
            transform.localPosition = oldPos;
        }   
        timer += Time.deltaTime;
        if (timer > 0.1f)
        {
            {
                //同心円状に飛ぶ弾丸を生成。
                float angle = 20.0f;
                float randomAngle = UnityEngine.Random.Range(0.0f, 360.0f);
                //いくつ生成する。
                int numBullet = (int)(360.0f / 15.0f);
                for (int i = 0; i < numBullet; i++)
                {
                    GameObject newBullet = UnityEngine.Object.Instantiate(bulletOriginal);
                    newBullet.transform.localPosition = transform.localPosition;
                    Bullet bullet = newBullet.GetComponent<Bullet>();
                    bullet.tag = "EnemyBullet";
                    bullet.moveDir.x = Mathf.Cos(Mathf.Deg2Rad * (angle * i + randomAngle));
                    bullet.moveDir.y = Mathf.Sin(Mathf.Deg2Rad * (angle * i + randomAngle));
                }
            }
            timer = 0.0f;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (HP != 0 && collider.tag != "EnemyBullet" && collider.gameObject.GetComponent<Bullet1>() != null)
        {
            HP -= 1;
            if (!bossDamageEffect)
            {
                bossDamageEffect = gameObject.AddComponent<BossDamageEffect>();
            }
            if(HP == 0)
            {
                //ボスのHPが0になった。
                Rigidbody rb = gameObject.AddComponent<Rigidbody>();
                Vector3 angularVelocity = rb.angularVelocity;
                angularVelocity.z = 30.0f;
                angularVelocity.x = 5.0f;
                angularVelocity.y = 5.0f;
                rb.angularVelocity = angularVelocity;
                rb.AddRelativeForce(100.0f, 250.0f, 0.0f);
                state = State.Dead;
            }
        }
    }
}
