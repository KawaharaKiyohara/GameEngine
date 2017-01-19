using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public Vector3 moveDir;
    public GameObject EnemyExplosion;
    Camera mainCamera;
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
   
    /// <summary>
    /// この弾丸を発射したエネミーが死んだことを通知。
    /// </summary>
    public void NotifyEnemyDestroy()
    {
        GameObject Ps = Object.Instantiate(EnemyExplosion);
        Ps.transform.localPosition = transform.localPosition;
    }
    /// <summary>
    /// 弾丸が死ぬときに呼ばれるコールバック関数。
    /// </summary>
    private void OnDestroy()
    {
        //弾丸が消えるときにこれがコールされる。
        //ここに爆発のパーティクルだけ流すようにしてください。
        /*GameObject Ps = Object.Instantiate(EnemyExplosion);
        Ps.transform.localPosition = transform.localPosition;*/
    }
}
