using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{

    public Transform Finish;

    NavMeshAgent agent;

    public Rigidbody rb;
    public float distance;
    private float jumpspeed = 150;
    private float sayac = 0;
    Vector3 jump = Vector3.zero;
    Animator AnimAI;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        AnimAI = GetComponent<Animator>();    
    }

    void FixedUpdate()
    {
        AnimAI.SetFloat("speed", agent.velocity.magnitude);
        distance = Vector3.Distance(transform.position, Finish.position);
        agent.destination = Finish.position;
    }

    private void OnTriggerEnter(Collider c)
    {
        sayac -= Time.deltaTime;
        if ((c.gameObject.tag == "jump") && sayac < 0)
        {
            AnimAI.SetBool("Isjump", true);
            rb.velocity = Vector3.up * Time.deltaTime * jumpspeed;
            jump = new Vector3(0, 10, 0) * Time.deltaTime;
            rb.MovePosition(transform.position + transform.TransformDirection(jump));
            sayac = 1;
        }

        if (c.gameObject.tag == "Finish")
        {
            //agent.enabled = false;
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            AnimAI.SetBool("dance", true);
        }
        else
        {
            AnimAI.SetBool("Isjump", false);
        }
    }



}
