using UnityEngine;
using System.Collections;

/// <summary>
/// 銃(ロケットランチャー)の弾クラス
/// </summary>
public class LauncherBulletScript : MonoBehaviour {

    private GameObject Player;

    private float m_fSpeed;
    private float maxSpeed;
    private float x;

    public GameObject explosion;
    public GameObject explosionPar;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");

        m_fSpeed = 1;
        maxSpeed = 50;
        x = 0;
        this.gameObject.transform.Translate(0.0f, 0.0f, 2.6f);
    }

    // Update is called once per frame
    void Update()
    {
        x += 0.1f;
        m_fSpeed += x * x;
        m_fSpeed=Mathf.Min(m_fSpeed, maxSpeed);
        this.gameObject.transform.Translate(0.0f, 0.0f, m_fSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Particle")
        {
            //this.rigidbody.AddExplosionForce();
            //Instantiate(explosion, this.transform.position, Quaternion.identity);
            Instantiate(explosion, Player.transform.position + new Vector3(0.0f, 0.0f, 30.0f), Quaternion.identity);
            Instantiate(explosionPar, Player.transform.position+new Vector3(0.0f,0.0f,30.0f), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
