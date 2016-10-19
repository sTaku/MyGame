using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤーの移動クラス
/// </summary>
public class PlayerMoveScript : MonoBehaviour {

    public GameObject startPas;
    private GameObject nextPas;

    private float currentToa;
    private float nextToa;

    private Vector3 currentPosition;

    private Vector3 currentDegree;
    private Vector3 nextDegree;

    private MovePasScript movePasScript;

    private float frametime;
    private float moveTimer = 0.0f;
    private float rotTimer = 0.0f;
    private float rotTime = 0.0f;
    private bool isMove = false;
    private bool isRotate = false;
    public bool isGOGOGO = true;

	// Use this for initialization
	void Start () {
        transform.position = startPas.transform.position;
        transform.rotation = startPas.transform.rotation;

        currentPosition = startPas.transform.position;
        currentDegree = transform.localEulerAngles;

        nextPas = startPas;
        movePasScript = nextPas.GetComponent<MovePasScript>();
        currentToa = movePasScript.Pass[0].nextToa;
    }
	
	// Update is called once per frame
	void Update () {
        frametime = Time.deltaTime;
        movePasScript = nextPas.GetComponent<MovePasScript>();
        if (isGOGOGO && !isMove) 
        {
            currentToa = nextToa;
            nextToa = movePasScript.getNextToa();
            nextPas = movePasScript.getNextPas();
            isMove = true;
        }

        move();
        Rotate();
        go();
	}

    /// <summary>
    /// 前進
    /// </summary>
    void move()
    {
        if (!isMove)
        {
            return;
        }

        moveTimer += frametime;
        float moveTime = moveTimer / nextToa;
        transform.position = Vector3.Lerp(currentPosition, nextPas.transform.position, moveTime);
        if (moveTime >= 1)
        {
            moveTimer = 0.0f;
            currentPosition = this.transform.position;
            isMove = false;
        }
    }

    /// <summary>
    /// 回転
    /// </summary>
    void Rotate()
    {
        if (!isRotate)
        {
            return;
        }

        rotTimer += frametime;
        float time = rotTimer / rotTime;

        transform.localEulerAngles = Vector3.Lerp(currentDegree,nextDegree,time);
        if (time >= 1)
        {
            rotTimer = 0.0f;
            currentDegree = this.transform.eulerAngles;
            isRotate = false;
        }
    }

    void setDegree(Vector3 degree)
    {
        nextDegree = degree;
    }

    void setTime(float time)
    {
        rotTime = time;
        isRotate = true;
        if (currentDegree.y >= 180)
        {
            nextDegree.y += 360;
        }
        if (currentDegree.x >= 180)
        {
            nextDegree.x += 360;
        }
        if (currentDegree.z >= 180)
        {
            nextDegree.z += 360;
        }
    }
    //isGOGOGOの時に動く
    public void setIsGOGOGO(bool flag)
    {
        isGOGOGO = flag;
    }

    private bool checkGOGOGO()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        return enemy.Length <= 0;
    }

    private void go()
    {
        if (checkGOGOGO() && !isGOGOGO)
        {
            setIsGOGOGO(true);
        }
    }
}
