using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float maxlifetime = 10.0f;
    public float speed = 500.0f;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void Project (Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxlifetime);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }


}
