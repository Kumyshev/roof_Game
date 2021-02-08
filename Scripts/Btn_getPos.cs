using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_getPos : MonoBehaviour
{
    private Button button;
    private Image image;

    private Game_Manager gmManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        gmManager = FindObjectOfType<Game_Manager>();

        button.onClick.AddListener(GetPos);
    }


    public void GetPos()
    {
        while (gmManager.maxUnit != 0 && !gmManager.posSelected) 
        {
            gmManager.unitPos = this.gameObject.name;
            this.image.color = Color.blue;
            this.button.interactable = false;
            gmManager.posSelected = true;
        }
    }

}
