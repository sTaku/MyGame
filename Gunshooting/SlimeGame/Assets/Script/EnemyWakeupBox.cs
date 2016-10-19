using UnityEngine;
using System.Collections;

/// <summary>
/// エネミーを起動させる
/// </summary>
public class EnemyWakeupBox : MonoBehaviour {

    public GameObject[] WakeUpEnemys;

    [SerializeField]
    private string ChildEnemyName;

	// Use this for initialization
	void Start () {
        transform.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider collider)
    {//プレイヤーが通ったらエネミーを起動
        if (collider.gameObject.tag == "Player")
        {
            for (int i = 0; i < WakeUpEnemys.Length; i++)
            {
                WakeUpEnemys[i].GetComponent<EnemyScript>().Wakeup();
            }
        }
    }
}
