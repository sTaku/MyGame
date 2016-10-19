using UnityEngine;
using System.Collections;

/// <summary>
/// 銃(マシンガン)の弾クラス
/// </summary>
public class MachineGunBulletScript : MonoBehaviour {

    public float m_fSpeed;
    public GameObject particle;

    // Use this for initialization
    void Start()
    {

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
