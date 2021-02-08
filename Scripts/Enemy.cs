using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{

    private Rigidbody rb;

    private bool isMove = false;

    private bool getPush;

    private Collider collider;

    [Range(1, 10)] public float enemy_Speed;

    private static Vector3 direct;



    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isMove) 
        {
            Moving(direct);
        }
        if (getPush) 
        {
            Moving(direct);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy" && !isMove)
        {
            isMove = false;
            getPush = true;

        }
        else if (collision.gameObject.tag == "enemy" && isMove)
        {
            isMove = false;
            rb.velocity = Vector3.zero;
        }


        if (collision.gameObject.tag == "player") 
        {
            isMove = true;
            getPush = false;
            direct = collision.contacts[0].point - transform.position;
        }
    }


    void Moving(Vector3 vector)
    {
        if (Mathf.Pow(vector.x, 2) > Mathf.Pow(vector.z, 2))
        {
            if (vector.x < 0)
            {
                transform.position += transform.right * 1 * enemy_Speed * Time.deltaTime;
            }
            else if (vector.x > 0)
            {
                transform.position += transform.right * -1 * enemy_Speed * Time.deltaTime;
            }
        }
        else if (Mathf.Pow(vector.x, 2) < Mathf.Pow(vector.z, 2))
        {
            if (vector.z < 0)
            {
                transform.position += transform.forward * 1 * enemy_Speed * Time.deltaTime;
            }
            else if (vector.z > 0)
            {
                transform.position += transform.forward * -1 * enemy_Speed * Time.deltaTime;
            }
        }
    }


    public bool IsGrounded()
    {
        bool grounded = (Physics.Raycast(collider.transform.position, Vector3.down, 1.0f, LayerMask.NameToLayer("roof")));

        if (grounded)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
