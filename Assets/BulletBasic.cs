using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D.velocity = speed * transform.up;
    }
}

