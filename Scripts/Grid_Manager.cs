using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Manager : MonoBehaviour
{
    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFSET = 0.5f;

    private int set_X;
    private int set_Y;
  
    // Start is called before the first frame update 
    void Start()
    {
        
    }

    void DrowGrid() 
    {
        Vector3 width_line = Vector3.right * 6;
        Vector3 height_line = Vector3.forward * 6;




        for (int i = 0; i < 7; i++) 
        {
            Vector3 begin = Vector3.forward * i;
            Debug.DrawLine(begin, begin + width_line);

            for (int j = 0; j < 7; j++)
            {
                begin = Vector3.right * j;
                Debug.DrawLine(begin, begin + height_line);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        DrowGrid();
        UpdateSelect();
    }

    void UpdateSelect() 
    {
        if (!Camera.main)
            return;


        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
            out hit, 25.0f, LayerMask.GetMask("ground"))) 
        {
            Debug.Log(hit.point);
        }
    }
}
