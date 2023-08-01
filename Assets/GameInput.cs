using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 45f;
    void Update()
    {
        Vector3 inputVector = Vector3.zero;


        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1;
            //transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0);
        transform.position += moveDir * Time.deltaTime * moveSpeed;
    }
}