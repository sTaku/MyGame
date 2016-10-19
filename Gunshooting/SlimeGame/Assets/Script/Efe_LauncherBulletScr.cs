using UnityEngine;
using System.Collections;

public class Efe_LauncherBulletScr : MonoBehaviour
{
    private float m_fSpeed;
    private float maxSpeed;
    private float x;

	// Use this for initialization
	void Start () {
        m_fSpeed = 1;
        maxSpeed = 50;
        x = 0;
        this.gameObject.transform.Translate(0.0f, 0.0f, -0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        x += 0.1f;
        m_fSpeed += x * x;
        m_fSpeed = Mathf.Min(m_fSpeed, maxSpeed);
        this.gameObject.transform.Translate(0.0f, 0.0f, m_fSpeed * Time.deltaTime);
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
