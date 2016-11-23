using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClashBox : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != gameObject)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject != gameObject)
        {
            GameObject goClearText = GameObject.Find("Canvas/GameClearText");
            Text text = goClearText.GetComponent<Text>();
            text.enabled = true;
        }
    }
    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}