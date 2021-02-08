using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public List<GameObject> prefabs;

    private Dictionary<string, string> posList = new Dictionary<string, string>();
    // Start is called before the first frame update

    public int maxUnit;

    public string unitType;

    public string unitPos;

    public bool unitSelected = false;
    public bool posSelected = false;


    public TextMeshProUGUI units;

    [HideInInspector]
    public bool playrIn = false;

    [HideInInspector]
    public bool firstPlayer = false;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        units.text = maxUnit.ToString();
        if (unitSelected && posSelected)
        {
            
            maxUnit--;
            posList.Add(unitPos, unitType);

            unitSelected = false;
            posSelected = false;
 
        }

    }

    public void BeginGame() 
    {
        
        foreach (var prefab in prefabs)
        {
            foreach (var unit in posList)
            {
                if (prefab.gameObject.tag == unit.Value)
                {
                    string[] list = unit.Key.Split('_');

                    float X = float.Parse(list[0], CultureInfo.InvariantCulture);
                    float Z = float.Parse(list[1], CultureInfo.InvariantCulture);

                    Instantiate(prefab, new Vector3(X, 1.5f, Z), Quaternion.identity);

                    if (unit.Value == "player") 
                    {
                        playrIn = true;
                    }
                }
            }
        }
    }
}
