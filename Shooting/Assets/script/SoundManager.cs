using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SoundManager : MonoBehaviour {
    public GameObject bulletShotSEOriginal;
    public static SoundManager instance { get; private set; }
    List<GameObject> goExplosionSoundList = new List<GameObject>();
    List<GameObject> goBulletShotSEList = new List<GameObject>();
    float playBulletShotInterval = 0.0f;
    // Use this for initialization
    void Start () {
        instance = this;

    }
	
	// Update is called once per frame
	void Update () {
        Predicate<GameObject> removeFunc = (go) =>
        {
            if (!go)
            {
                return true;
            }
            return false;
        };
        goExplosionSoundList.RemoveAll(removeFunc);
        goBulletShotSEList.RemoveAll(removeFunc);
        playBulletShotInterval -= Time.deltaTime;

    }
    public void RequestPlayExplosionSound()
    {
        if (goExplosionSoundList.Count < 2)
        {
            //同時発声数を制限する。
            GameObject go = Instantiate(Resources.Load("prefab/ExprosionSound")) as GameObject;
            goExplosionSoundList.Add(go);
        }
    }
    public void RequestPlayBulletSE()
    {
        if(playBulletShotInterval < 0.0f && goBulletShotSEList.Count < 16)
        {
            GameObject go = Instantiate(bulletShotSEOriginal) as GameObject;
            goBulletShotSEList.Add(go);
            playBulletShotInterval = 0.01f;
        }
    }
}
