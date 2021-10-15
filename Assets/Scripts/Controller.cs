using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    float inputX;
    float inputY;
    public Transform Model;
    public Rigidbody rb;
    private float speed = 1;
    public float jumpspeed = 150;
    private float sayac = 0;
    public float damp = 3;
    public float playerDistance;
    public Transform Finish;
    Vector3 move = Vector3.zero;
    Vector3 jump = Vector3.zero;
    Animator Anim;
    Vector3 StickDirection;
    Camera mainCam;


    [Range(1,20)]
    public float rotationSpeed;

    void Start()
    {

        Anim = GetComponent<Animator>();
        mainCam = Camera.main;

    }

    private void FixedUpdate()
    {
        
        InputMove();
        InputRotation();
        Movement();
        playerDistance = Vector3.Distance(transform.position, Finish.position);

    }

    void Movement()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        move = new Vector3(inputX, 0, inputY) * Time.deltaTime * speed;   
        rb.MovePosition(transform.position + transform.TransformDirection(move));

        StickDirection = new Vector3(inputX, 0, inputY);
        sayac -= Time.deltaTime;

        if ((Input.GetKey(KeyCode.Space)) && sayac < 0)
        {
            Anim.SetBool("Isjump", true);
            rb.velocity = Vector3.up * Time.deltaTime * jumpspeed;
            jump = new Vector3(inputX * 6, 0, inputY * 6) * Time.deltaTime;
            rb.MovePosition(transform.position + transform.TransformDirection(jump));
            sayac = 1;
        }
        else
        {
            Anim.SetBool("Isjump", false);
        }

    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Finish")
        {
            Anim.SetBool("dance", true);
            speed = 0;
        }
    }

    void InputMove()
    {
        Anim.SetFloat("speed", Vector3.ClampMagnitude(StickDirection, 1).magnitude, damp , Time.deltaTime * 10);
    }

    void InputRotation()
    {
        Vector3 rotOfset = mainCam.transform.TransformDirection(StickDirection);
        rotOfset.y = 0;

        Model.forward = Vector3.Slerp(Model.forward, rotOfset, Time.deltaTime * rotationSpeed);
    }


}
