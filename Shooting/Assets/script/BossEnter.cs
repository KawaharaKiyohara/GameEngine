using UnityEngine;
using System.Collections;

/// <summary>
/// ボスの入場演出
/// </summary>
public class BossEnter : MonoBehaviour {
    float waitTimer = 2.0f;
    const float bosEnterEndPosY = 6.7f; //ボスの登場演出が終了するY座標。
    Camera mainCamera;
    float cameraYureRate = 0.0f;        //sinカーブでカメラを揺らすための種。
    
    // Use this for initialization
    void Start () {
        //ボスの初期位置は画面外。
        transform.localPosition = new Vector3(0.0f, 15.0f, 0.0f);
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        waitTimer -= Time.deltaTime;
        if (waitTimer < 0.0f)
        {
            //カメラ揺れ。
            cameraYureRate += Time.deltaTime * 50.0f;
            float angle = Mathf.Sin(cameraYureRate) * 0.5f;
            mainCamera.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //落ちてくる。
            Vector3 pos = transform.localPosition;
            pos.y -= 1.0f * Time.deltaTime;
            if (pos.y < bosEnterEndPosY)
            {
                pos.y = bosEnterEndPosY;
                mainCamera.transform.localRotation = Quaternion.identity;
                Destroy(this);
            }
            transform.localPosition = pos;
            
        }
	}
    
}
