using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float speed = 4f;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -14.43f)
        {
            transform.position = startPosition;
        }
    }
}
