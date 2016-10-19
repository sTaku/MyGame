using UnityEngine;
using System.Collections;

/// <summary>
/// 回復アイテムクラス
/// </summary>
public class RecoveryScr : MonoBehaviour {

    private PlayerScript playerScr;

	// Use this for initialization
	void Start () {
        var Player = GameObject.Find("PlayerObj");
        playerScr = Player.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name == "Bullet")
        if (collision.transform.tag == "Bullet" || collision.transform.tag == "MBullet")
        {
            playerScr.m_fLife += playerScr.m_fMaxLife / 100.0f * 30.0f;
            if (playerScr.m_fLife > playerScr.m_fMaxLife) playerScr.m_fLife = playerScr.m_fMaxLife;
            Destroy(this.gameObject);
        }
    }
}
