using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("< Walk >")]
    public float speed = 5f;
    public float maxSpeed = 10f;

    [Header("< Gravity >")]
    public float jumpForce = 6f;
    public bool jumpRead;
    public float gravity = 9.81f;
    public float gravityMult = 9.81f;


    [Header("< Strings >")]
    public string groundTag;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float move_X = Input.GetAxisRaw("Horizontal");
        float move_Z = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(move_X, rb.velocity.y, move_Z) * speed;

    }

}
