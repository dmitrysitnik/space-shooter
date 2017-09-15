using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSide : MonoBehaviour {
    public float startWait;
    public float speed;
    private Rigidbody rb;
    private Rigidbody firstWay;
    private bool isStart;
    public bool isNeedMove;

	// Use this for initialization
	void Start () {
        speed = speed + GameController.upSpeed;
        rb = GetComponent<Rigidbody>();
        StartCoroutine( Move());
    }
	
	// Update is called once per frame
	void Update () {
        if (isStart)
        {
            CheckMove();
        }
    }
    /// <summary>
    /// Move enemy ship into random position
    /// </summary>
    /// <returns></returns>
    IEnumerator Move()
    {
        yield return new WaitForSeconds(startWait);
        firstWay = rb;
        rb.velocity = (firstWay.velocity + new Vector3(Random.Range(-5.8f,5.8f), 0.0f, 0.0f)) * speed;
        isStart = true;
    }

    /// <summary>
    /// Проверяет можно ли продолжать движение
    /// в сторону
    /// </summary>
    void CheckMove()
    {
        isNeedMove = (rb.position.x < 6 && rb.position.x > -6);
        while (isNeedMove)
        {
            return;
        }
        rb.velocity = new Vector3(0.0f,0.0f,-4);
    }
}
