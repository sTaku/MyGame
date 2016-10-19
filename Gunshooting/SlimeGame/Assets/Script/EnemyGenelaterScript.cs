using UnityEngine;
using System.Collections;

/// <summary>
/// 敵のジェネレータクラス
/// </summary>

    //テストで使っていたクラス
public class EnemyGenelaterScript : MonoBehaviour {

    private float genelateTime;
    public GameObject enemy;
    private GameObject Player;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("PlayerObj");
        transform.LookAt(Player.transform);
        genelateTime = Random.Range(2, 5);
	}
	
	// Update is called once per frame
	void Update () {
        genelateTime -= 1 * Time.deltaTime;
        if (genelateTime <= 0)
        {
            Vector3 genelatePosition = new Vector3(transform.position.x + Random.Range(-10,10), 1,transform.position.z + Random.Range(-5,5));
            Instantiate(enemy, genelatePosition, transform.rotation);
            genelateTime = Random.Range(2, 5);
        }
	}
}
