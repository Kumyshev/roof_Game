using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Get_Touch : MonoBehaviour
{
    private Vector2 firstTouch;
    private Player_Move player;

    public int swipeDist = 50;

    private bool touchState;

    private float dist; 
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touchState == false && Input.touchCount > 0 &&
            Input.touches[0].phase == TouchPhase.Began) 
        {
            firstTouch = Input.touches[0].position;
            touchState = true;
        }
        if (touchState) 
        {
            if (Input.touches[0].position.y >= firstTouch.y + swipeDist) 
            {
                var result = Input.touches[0].position - firstTouch;
                var length = result.magnitude;
                Debug.Log(length);

                touchState = false;
                player.MoveF();
            }
            else if (Input.touches[0].position.y <= firstTouch.y - swipeDist)
            {
                var result = Input.touches[0].position - firstTouch;
                var length = result.magnitude;
                Debug.Log(length);

                touchState = false;
                player.MoveB();
            }
            else if (Input.touches[0].position.x <= firstTouch.x - swipeDist)
            {
                var result = Input.touches[0].position - firstTouch;
                var length = result.magnitude;
                Debug.Log(length);

                touchState = false;
                player.MoveL();
            }
            else if (Input.touches[0].position.x >= firstTouch.x + swipeDist)
            {
                var result = Input.touches[0].position - firstTouch;
                var length = result.magnitude;
                Debug.Log(length);

                touchState = false;
                player.MoveR();
            }
        }


        


        if (touchState && Input.touchCount > 0 &&
            Input.touches[0].phase == TouchPhase.Ended) 
        {
            
            touchState = false;
        }
    }
}
