using Assets.Scripts;
using System;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Paddle _paddle;
    private Vector3 _paddleToBallVector;
    private bool _hasGameStarted = false;

    void Start()
    {
        _paddle = FindObjectOfType<Paddle>();
        _paddleToBallVector = transform.position - _paddle.transform.position;
    }

    void Update()
    {
        if (!_hasGameStarted)
        {
            transform.position = _paddle.transform.position + _paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                _hasGameStarted = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().velocity += new Vector2(UnityEngine.Random.Range(0f, 0.2f), UnityEngine.Random.Range(0f, 0.2f));
        if (_hasGameStarted)
        {
            GetComponent<AudioSource>().Play();
        };
    }
}
