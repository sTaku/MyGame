using UnityEngine;
using System.Collections;

public class waveManagerScript : MonoBehaviour {

    private int enemyCount;

    public GameObject[] enemys2;

    public GameObject[] enemys3;

    private bool IsHAKASE = false;

	// Use this for initialization
    void Start()
    {
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.childCount <= 0)
        {
            this.transform.tag = "Enemy";
        }

        if (transform.childCount <= 0 && enemys2.Length <= 0 && enemys3.Length <= 0) Destroy(this.gameObject);
	}

    bool IsEnemyO()
    {
        if (transform.childCount <= 0) return true;
        return false;
    }

    void WaveChange()
    {
        if (IsEnemyO())
        {
            if (enemys2.Length >= 1)
            {

            }
        }
    }
}
