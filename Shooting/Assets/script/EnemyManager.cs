using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
    float timer;
    public GameObject enemyOriginal;
	// Use this for initialization
	void Start () {
	
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
            timer = 0.0f;
        }
	}
}
