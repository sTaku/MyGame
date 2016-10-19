using UnityEngine;
using System.Collections;

/// <summary>
/// 敵の移動クラス
/// </summary>
public class EnemyMove : MonoBehaviour {

    private Vector3 startPos;
    public Vector3 endPos;   //敵が攻撃にはいるポジション
    public float mToa;       //↑に到着するまでの時間
    private float time;

    private Vector3 startRot; 
    public Vector3 endRot;  //上と同様に向き
    public float rToa;      //上と同様に時間

    private EnemyScript enemyScript;
    private int k = 0;

    private bool isMove = true;
    private bool isRotate = false;
    [SerializeField]
    private string EnemyName;

	// Use this for initialization
	void Start () {
        startPos = this.transform.localPosition;
        startRot = this.transform.localEulerAngles;
        setStatus();
        enemyScript = GetComponent<EnemyScript>();
        }
	
	// Update is called once per frame
	void Update () {
        if (enemyScript.IsWakeUp())
        {
            Move();
            Rotate();
        }
	}

    void Move()
    {
        if (!isMove) return;
        addAttackTime(mToa);
        time += Time.deltaTime;
        this.transform.localPosition = Vector3.Lerp(startPos, endPos, time / mToa);
        if ((time / mToa) >= 1)
        {
            time = 0.0f;
            k = 0;
            isMove = false;
            isRotate = true;
        }
    }

    void Rotate()
    {
        if (!isRotate) return;
        addAttackTime(rToa);
        time += Time.deltaTime;
        this.transform.localEulerAngles = Vector3.Lerp(startRot, endRot, time / rToa);
        if (time / rToa >= 1)
        {
            isRotate = false;
        }
    }

    void addAttackTime(float t)
    {
        if (k != 0) return;
        enemyScript.attackTime += t;
        k++;
    }

    void setStatus()
    {
        if (endPos == Vector3.zero) endPos = this.transform.localPosition;
        if (endRot == Vector3.zero) endRot = this.transform.localEulerAngles;

    }
}
