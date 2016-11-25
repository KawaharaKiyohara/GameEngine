using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public GameObject bulletOriginal;
    public GameObject bulletShotSEOriginal;
    public GameObject bulletShotParticle;
    public GameObject bulletExplosion;
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
            Bullet1 bullet = newBullet.GetComponent<Bullet1>();
            bullet.tag = "PlayerBullet";
            //to 井上 弾丸の発射のSEを再生する。
            //Unityのサウンドの出し方を調べるように。
            //弾丸を発射する。
            //SEサウンド
            Instantiate(bulletShotSEOriginal);
            timer = 0.0f;
            //サウンド↓
            //Object.Instantiate(bulletShotSEOriginal);

            GameObject newPs = Object.Instantiate(bulletShotParticle);
            newPs.transform.localPosition = transform.localPosition;
        }

	}
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "PlayerBullet" && collider.gameObject.GetComponent<Bullet>() != null)
        {
            GameObject newPs = Object.Instantiate(bulletExplosion);
            newPs.transform.localPosition = transform.localPosition;
            //ゲームオーバー。
            //ゲームオーバーを通知する。
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            gm.isGameOver = true;
            //ゲームオーバーテキストを表示する。
            GameObject.Find("GameOver").GetComponent<Text>().enabled = true;
            Object.Destroy(gameObject);
        }
    }
}
