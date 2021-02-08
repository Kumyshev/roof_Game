using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plr_grid_mvnt : MonoBehaviour
{

    public float Speed = 10.0f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MoveX(float direct) 
    {
        rb.velocity = (transform.forward * direct) * Speed;
    }

    public void MoveY(float direct)
    {
        rb.velocity = (transform.right * direct) * Speed;
    }
}
