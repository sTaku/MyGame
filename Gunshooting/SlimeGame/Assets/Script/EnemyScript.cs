using UnityEngine;
using System.Collections;

/// <summary>
/// 敵のスクリプト
/// </summary>
public class EnemyScript : MonoBehaviour {

    private GameObject Player;
    private GameObject my;
    public float hp;
    public float maxhp;
    private float damagetime = 1f;//アニメーションが終わる時間
    private float walkEndtime = 0f;
    private float atime;
    public float attackTime; //攻撃するまでの時間.
    public float attackPower = 150;  //プレイヤーにどれだけのダメージを与えられるか.

    private bool IsSleep = true;

    private EnemyMove eMove;
    private EnemyAnimation eAnime;
    private BoxCollider boxCol;


	// Use this for initialization
	void Start ()
    {
        hp = maxhp;
        atime = attackTime;
	    Player = GameObject.Find("PlayerObj");
        eAnime = GetComponent<EnemyAnimation>();
        eMove = GetComponent<EnemyMove>();
        boxCol = GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update () {

        EnemyMove();

	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            if (collision.transform.name == "HandGunBullet(Clone)")
            {
                eAnime.GethitAnim();
                hp -= 50;
            }
            if (collision.transform.name == "MachineGunBullet(Clone)")
            {
                eAnime.GethitAnim();
                hp -= 25;
            }
        }
    }

    void EnemyMove()
    {
        if (!IsSleep)
        {
            Attack();
            walkEndtime += Time.deltaTime;
            if(walkEndtime >= eMove.mToa)
            {
                eAnime.IdleAnim();
            }
            if (hp <= 0)
            {
                StartCoroutine("IsDead");
            }
        }
    }

    /// <summary>
    /// 敵が起動するときに呼び出される
    /// </summary>
    public void Wakeup()
    {
        IsSleep = false;
        transform.tag = "Enemy";
    }


    /// <summary>
    /// 敵が起きているか
    /// </summary>
    /// <returns></returns>
    public bool IsWakeUp()
    {
        return !IsSleep;
    }

    /// <summary>
    /// 攻撃
    /// </summary>
    void Attack()
    {
        attackTime -= Time.deltaTime;

        if (attackTime <= 0)
        {
            eAnime.AttackAnim();
            Invoke("Attackdamage", damagetime);
            attackTime = atime;
        }
    }

    /// <summary>
    /// ダメージを与える
    /// </summary>
    void Attackdamage()
    {
        Player.GetComponent<PlayerScript>().Damage(attackPower);
    }

    /// <summary>
    /// 死亡クラス
    /// </summary>
    /// <returns></returns>
    public IEnumerator IsDead()
    {
        IsSleep = true;

        boxCol.enabled = false;
        eAnime.IsDeadAnim();
        this.transform.tag = "Untagged";
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
