using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Swipe : MonoBehaviour
{
    private Player_Movement player;
    [Range(1, 10)] public float plr_Speed;

    private Vector2 startPos;
    private Vector2 direction;

    private Game_Manager gmManager;


    public float X;
    public float Y;

    
    // Start is called before the first frame update
    void Start()
    {
        gmManager = FindObjectOfType<Game_Manager>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gmManager.playrIn)
        {
            player = FindObjectOfType<Player_Movement>();

            if (Input.touchCount > 0 && !player.isMove)
            {
                X = 0;
                Y = 0;
                player.rb.isKinematic = false;

                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {

                    case TouchPhase.Began:
                        startPos = touch.position;
                        break;

                    case TouchPhase.Moved:
                        direction = touch.position - startPos;
                        break;



                    case TouchPhase.Ended:
                        player.isMove = true;
                        X = direction.x;
                        Y = direction.y;

                        //distance = Vector3.Magnitude(touch.position - startPos);
                        break;
                }
            }
            if (Mathf.Pow(X, 2) > Mathf.Pow(Y, 2) && player.IsGrounded() && player.isMove)
            {
                if (X > 0)
                {
                    player.transform.position += transform.right * 1 * plr_Speed * Time.deltaTime;
                    player.transform.rotation = Quaternion.LookRotation(Vector3.right);
                }
                else if (X < 0)
                {
                    player.transform.position += transform.right * -1 * plr_Speed * Time.deltaTime;
                    player.transform.rotation = Quaternion.LookRotation(-Vector3.right);
                }
            }
            else if (Mathf.Pow(X, 2) < Mathf.Pow(Y, 2) && player.IsGrounded() && player.isMove)
            {
                if (Y > 0)
                {
                    player.transform.position += transform.forward * 1 * plr_Speed * Time.deltaTime;
                    player.transform.rotation = Quaternion.LookRotation(Vector3.forward);
                }
                else if (Y < 0)
                {
                    player.transform.position += transform.forward * -1 * plr_Speed * Time.deltaTime;
                    player.transform.rotation = Quaternion.LookRotation(-Vector3.forward);
                }
            }
        }
    }
}
