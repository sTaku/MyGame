using UnityEngine;
using System.Collections;

/// <summary>
/// マウスカーソルのクラス
/// </summary>
public class CursolObjectScript : MonoBehaviour {

    public Texture2D cursol;
    
    public Vector2 cursolPosition;
    private Vector2 truePosition;

    //マウス感度
    [SerializeField]
    private float mouseSpeed;

    //反動から戻すスピード
    [SerializeField]
    private float modosuyo_Speed;

	// Use this for initialization
	void Start () {
        cursolPosition = new Vector2(Screen.width / 2, Screen.height / 2);
        truePosition = new Vector2(Screen.width / 2, Screen.height / 2);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void LateUpdate()
    {
        mouse();
        
        Screen.lockCursor = true;
        //反動を自動で戻す
        Vector2 velocity = (truePosition - cursolPosition) / 6.0f;
        cursolPosition += velocity;

        velocity.Normalize();
        velocity *= modosuyo_Speed;
        if (Vector2.Distance(truePosition, cursolPosition)
            >= Vector2.Distance(cursolPosition + velocity, cursolPosition))
        {
            cursolPosition += velocity;
        }
        else
        {
            cursolPosition = truePosition;
        }

        cursolPosition.x = Mathf.Clamp(cursolPosition.x, 0.0f, Screen.width);
        cursolPosition.y = Mathf.Clamp(cursolPosition.y, 0.0f, Screen.height);

        truePosition.x = Mathf.Clamp(truePosition.x, 0.0f, Screen.width);
        truePosition.y = Mathf.Clamp(truePosition.y, 0.0f, Screen.height);
    }

    /// <summary>
    /// マウスの移動量に関する関数
    /// </summary>
    void mouse() {
        Vector2 velocity = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSpeed;
        cursolPosition += velocity;
        truePosition += velocity;
    }
    /// <summary>
    /// 銃を撃った時の反動に関する関数
    /// </summary>
    void kick(Vector2 velocity){
        cursolPosition += velocity;
    }

    void OnGUI()
    {
        Rect rect = new Rect(cursolPosition.x - (cursol.width / 2),
            -cursolPosition.y + Screen.height - (cursol.height / 2),
            cursol.width,
            cursol.height);

        GUI.DrawTexture(rect,cursol);
    }

    Vector2 Lerp(Vector2 my, Vector2 target, float t)
    {
        if (t < 0.0f)
        {
            t = 0.0f;
        }
        else if (t > 1.0f)
        {
            t = 1.0f;
        }
        return my * (1.0f - t) + target * t;
    }
}
