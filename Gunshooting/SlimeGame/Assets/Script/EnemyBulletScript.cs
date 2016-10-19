using UnityEngine;
using System.Collections;

/// <summary>
/// 敵の弾のクラス
/// </summary>

//未実装
public class EnemyBulletScript : MonoBehaviour {

    public float m_fSpeed;
    public GameObject particle;
    private GameObject player;
    private PlayerScript pscript;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        pscript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(0.0f, 0.0f, m_fSpeed * Time.deltaTime);
        Destroy(this.gameObject, 3f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(particle, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
