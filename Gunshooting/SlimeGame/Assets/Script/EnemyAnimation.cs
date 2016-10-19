using UnityEngine;
using System.Collections;

/// <summary>
/// 敵の共通アニメーションクラス
/// </summary>
public class EnemyAnimation : MonoBehaviour {

    
    private Animator anim;
    private bool walk;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("Walk", true);
        walk = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

    /// <summary>
    /// idleに入るときに呼ばれるアニメーション
    /// </summary>
    public void IdleAnim()
    {
        walk = false;
        anim.SetBool("Walk",false);
    }
    /// <summary>
    /// 攻撃時に呼ばれるアニメーション
    /// </summary>
    public void AttackAnim()
    {
        anim.Play("Attack");
    }

    /// <summary>
    /// 被ダメ時に呼ばれるのアニメーション
    /// </summary>
    public void GethitAnim()
    {
        if(walk == true)
        {
            anim.Play("Walk_GetHit");
        }
        else
        {
            anim.Play("GetHit");
        }
    }
    /// <summary>
    /// 死亡時に呼ばれるアニメーション
    /// </summary>
    public void IsDeadAnim()
    {
        anim.Play("Dead");
    }
}
