using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public Vector3 moveDir;
    public GameObject EnemyExplosion;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.localPosition;
        pos += moveDir * 0.05f;
        transform.localPosition = pos;
	}
    void OnBecameInvisible()
    {
        //画面外に行ったら削除。
        Object.Destroy(gameObject);
    }
    /// <summary>
    /// 弾丸が死ぬときに呼ばれるコールバック関数。
    /// </summary>
    private void OnDestroy()
    {
        
        GameObject Ps = Object.Instantiate(EnemyExplosion);
        Ps.transform.localPosition = transform.localPosition;
        //弾丸が消えるときにこれがコールされる。
        //ここに爆発のパーティクルだけ流すようにしてください。
        /*GameObject Ps = Object.Instantiate(EnemyExplosion);
        Ps.transform.localPosition = transform.localPosition;*/
    }
}
