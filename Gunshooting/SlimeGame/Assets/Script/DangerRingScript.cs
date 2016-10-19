using UnityEngine;
using System.Collections;

/// <summary>
/// 敵が攻撃してくるまでの時間のクラス
/// デンジャーリング
/// </summary>
public class DangerRingScript : MonoBehaviour {

    private GameObject Player;
    private GameObject ParentEnemy;
    private Transform Enemy;
    private EnemyScript enemyScript;

    [SerializeField]
    private float greenTime;   //緑の円が出てくるタイミング.２だったら「攻撃してくるまであと２秒」のタイミングで出てくることになる
    [SerializeField]
    private float yellowTime;   //緑の円が消えて黄色の円が出てくるタイミング
    [SerializeField]
    private float greenPow;  //円の色が緑から黄色になる時に緩急をつける場合の数値.通常は１.早めに黄色に変える時は少数以下の数字にする、出来るだけ緑を維持したいなら数字を１より大きくする
    [SerializeField]
    private float yellowPow;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("PlayerObj");
        ParentEnemy = gameObject.transform.parent.gameObject;
        Enemy = ParentEnemy.transform;
        enemyScript = Enemy.GetComponent<EnemyScript>();

        this.gameObject.GetComponent<Renderer>().material.color = Color.clear;

	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Player.transform.position);

        if (enemyScript.attackTime > greenTime)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.clear;
        }

        if (enemyScript.attackTime <= yellowTime)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.yellow, Color.red, Mathf.Pow( (yellowTime - enemyScript.attackTime),yellowPow));
        } 
        else if (enemyScript.attackTime <= greenTime)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.green, Color.yellow, Mathf.Pow( (greenTime - enemyScript.attackTime),greenPow));
        }
	}
}
