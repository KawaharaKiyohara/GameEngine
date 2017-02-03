using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームマネージャークラス。
/// </summary>
public class GameManager : MonoBehaviour {
    public bool isGameOver;
    public GameObject GameBGM;
    public GameObject bossPrefab;
    public Score score { get; private set; }
    AudioSource bgmSource;
    int Count = 0;
    public enum GameState
    {
        Normal,             //通常
        NormalBGMFadeOut,   //通常BGMフェードアウト。
        Boss,               //ボス戦。
    };
    public GameState gameState = GameState.Normal;
    // Use this for initialization
    void Start()
    {
        bgmSource = Instantiate(GameBGM).GetComponent<AudioSource>();
        score = GameObject.Find("Score").GetComponent<Score>();
    }
	// Update is called once per frame
	void Update () {
        if (isGameOver)
        {
            if (Count == 280)
            {
                SceneManager.LoadScene("Title");
            }
            else
            {
                Count++;
            }
        }
        switch (gameState)
        {
            case GameState.Normal:
                //
                if (score.point > 3000)
                {
                    //すべての敵を爆発させる。
                    Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
                    foreach( Enemy enemy in enemies)
                    {
                        enemy.RequestDead();
                    }
                    //すべての弾丸を爆発させる。
                    Bullet[] bullets = GameObject.FindObjectsOfType<Bullet>();
                    foreach(Bullet bullet in bullets)
                    {
                        bullet.RequestExplosion(Random.Range(0.0f, 1.0f));
                    }
                    //スコアのポイントが1000より大きくなったら。
                    //gameState = GameState.Boss;
                    gameState = GameState.NormalBGMFadeOut;
                }
                break;
            case GameState.NormalBGMFadeOut:
                float volume = bgmSource.volume;
                volume -= Time.deltaTime * 0.5f;
                if (volume < 0.0f)
                {
                    volume = 0.0f;
                    //ここでボスのブレハブをロードする。
                    GameObject boss = Object.Instantiate(bossPrefab);
                    gameState = GameState.Boss;
                }
                bgmSource.volume = volume;
                break;
            case GameState.Boss:
                break;
        }
            
	}
}