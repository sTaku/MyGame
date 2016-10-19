using UnityEngine;
using System.Collections;
/// <summary>
/// 敵の反復移動スクリプト
/// alien用
/// </summary>
public class AlianMoveScript : MonoBehaviour {

    private EnemyScript enemyScript;
    private float Xpos;
    private float previousX;
    public float moveDirection;//移動する距離

    // Use this for initialization
    void Start()
    {
        enemyScript = GetComponent<EnemyScript>();
        previousX = this.transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.IsWakeUp())
        {
            Xpos = Mathf.Sin(Time.time) * moveDirection;
            transform.localPosition = new Vector3(previousX + Xpos, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
    