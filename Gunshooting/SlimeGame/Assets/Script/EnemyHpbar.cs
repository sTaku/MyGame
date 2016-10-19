using UnityEngine;
using System.Collections;


/// <summary>
/// 敵のHPクラス
/// </summary>
public class EnemyHpbar : MonoBehaviour {

    private GameObject Player;
    public GameObject ParentEnemy;
    private Transform Enemy;
    public EnemyScript enemyScript;
    public float sideScale;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("PlayerObj");
        ParentEnemy = gameObject.transform.parent.gameObject;
        Enemy = ParentEnemy.transform;
        enemyScript = Enemy.GetComponent<EnemyScript>();
        if (sideScale == 0)
        {
            sideScale = 3;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Player.transform.position);
        transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), 180.0f);
        transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), -transform.rotation.z);

        SizeChange();
	}

    //親の現在体力の割合にバーの大きさを調整する.
    void SizeChange()
    {
        Vector3 Hpbar = transform.localScale;

        Hpbar.x = (enemyScript.hp / enemyScript.maxhp) * sideScale;

        transform.localScale = Hpbar;
    }
}
