using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void MoveF() 
    {
        rb.AddForce(transform.forward * 30000f * Time.deltaTime);
    }
    public void MoveB()
    {
        rb.AddForce(-transform.forward * 30000f * Time.deltaTime);
    }
    public void MoveR()
    {
        rb.AddForce(transform.right * 30000f * Time.deltaTime);
    }
    public void MoveL()
    {
        rb.AddForce(-transform.right * 30000f * Time.deltaTime);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
