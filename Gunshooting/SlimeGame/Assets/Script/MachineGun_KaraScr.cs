using UnityEngine;
using System.Collections;

/// <summary>
/// 空薬莢(マシンガン)クラス
/// </summary>
public class MachineGun_KaraScr : MonoBehaviour
{
    private float dirY, dirZ;

    //追加-------------------------------------------
    private float angleZ;

    // Use this for initialization
    void Start()
    {
        dirY = Random.Range(-0.005f, 0.025f);
        dirZ = Random.Range(-0.05f, -0.01f);
        this.transform.Rotate(0.0f, 0.0f, 90.0f);

        //追加-----------------------------------------------
        angleZ = Random.Range(-0.08f, -0.03f);
    }

    // Update is called once per frame
    void Update()
    {
        //追加-----------------------------------------------
        var rote = this.gameObject.transform.localRotation;
        rote.Set(
            rote.x,
            rote.y,
            rote.z + angleZ,
            rote.w
        );
        this.gameObject.transform.localRotation = rote;
        //---------------------------------------------------

        this.transform.Translate(0.0f, dirY, dirZ);
        Destroy(gameObject, 1.0f);
    }
}
