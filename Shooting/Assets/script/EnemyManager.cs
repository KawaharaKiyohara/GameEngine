using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
    float timer;
    public GameObject enemyOriginal;
    public Camera mainCamera;
	// Use this for initialization
	void Start () {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > 1.0f)
        {
            //敵を生成。
            GameObject newEnemy = GameObject.Instantiate(enemyOriginal);
            Enemy enemy = newEnemy.GetComponent<Enemy>();
            enemy.moveDir.y = -1.0f;
            //初期位置をランダムで決める。
            int pos = Random.Range(0, Screen.width);
            Vector3 vPos = mainCamera.ScreenToWorldPoint(new Vector3(pos, 0.0f, 0));
            vPos.y = enemy.transform.localPosition.y;
            vPos.z = 0.0f;
            enemy.transform.localPosition = vPos;
            timer = 0.0f;
        }
	}
}
