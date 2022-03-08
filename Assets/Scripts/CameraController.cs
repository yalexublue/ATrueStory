using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool canMove = true;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove == false) return;

        float xin = Input.GetAxis("Horizontal");
        float yin = Input.GetAxis("Vertical");
        Vector3 moveVector = new Vector3(xin, 0, yin);
        moveVector *= moveSpeed;

        transform.position += moveVector;
    }
}
