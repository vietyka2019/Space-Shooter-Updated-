using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    Vector3 movement = new Vector3(0, 0, 0);
    [SerializeField] float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello world");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += new Vector3(-0.005f, 0, 0);
            movement.x = -speed;
            movement.y = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += new Vector3(0.005f, 0, 0);
            movement.x = speed;
            movement.y = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += new Vector3(0, 0.005f, 0);
            movement.x = 0;
            movement.y = speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.position += new Vector3(0, -0.005f, 0);
            movement.x = 0;
            movement.y = -speed;
        }

        // automatically move character in y-axis
        transform.Translate(movement * Time.deltaTime); 

    }
}
