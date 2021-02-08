using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody rb;

    [HideInInspector]
    public bool isMove = false;

    private Collider collider;

    

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag != "roof")
        {
            isMove = false;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }


    }
    // Update is called once per frame
    void Update()
    {
        
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
