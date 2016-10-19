using UnityEngine;
using System.Collections;

/// <summary>
/// ロケットランチャーの弾クラス
/// </summary>
public class ExplosionScr : MonoBehaviour {

    public float attack;

    private float timer;

	// Use this for initialization
	void Start () {

        GameObject[] obj = GameObject.FindGameObjectsWithTag("Enemy");
        for (var i = 0; i < obj.Length; i++)
        {
            obj[i].GetComponent<EnemyScript>().StartCoroutine("IsDead");
        }
	}
	
	// Update is called once per frame
	void Update () {
        timer+=Time.deltaTime;
        this.gameObject.GetComponent<Renderer>().material.color=
            Color.Lerp(new Color(1.0f,1.0f,1.0f,1.0f),
                       new Color(1.0f,1.0f,1.0f,0.0f),
                       timer/2.0f
                       );
        Destroy(gameObject, 3.0f);
	}
}
