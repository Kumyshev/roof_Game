using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Btn_getUnit : MonoBehaviour
{

    private Button button;

    private Game_Manager gmManager;

    public bool limitation;

    

    // Start is called before the first frame update

    
    void Start()
    {
        gmManager = FindObjectOfType<Game_Manager>();
        button = GetComponent<Button>();
    }

    public void GetUnit() 
    {

        if (limitation)
        { 
            int maxUnit = 1;
            while (maxUnit != 0 && !gmManager.unitSelected)
            {
                gmManager.unitType = gameObject.tag;
                gmManager.firstPlayer = true;
                gmManager.unitSelected = true;
                maxUnit--;
            }
        }
        else 
        {
            while (gmManager.maxUnit != 0 && !gmManager.unitSelected && gmManager.firstPlayer) 
            {
                gmManager.unitType = gameObject.tag;

                gmManager.unitSelected = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if ((!gmManager.firstPlayer && !limitation) || (gmManager.maxUnit == 0 || gmManager.unitSelected)) 
        {
            button.interactable = false;
        }
        else 
        {
            if (!limitation)
            {
                button.interactable = true;
            }
        }
    }
}
