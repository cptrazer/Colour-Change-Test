using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourMod : MonoBehaviour
{



    [SerializeField]
    GameObject GetGameObject;
    public List<GameObject> ColourTheHouse = new List<GameObject>();

    int colourState = 0;
    

    // Use this for initialization
    void Start()
    {


    }



    // Update is called once per frame
    void Update()
    {


    }


    private void OnMouseDown()
    {

        GameObject House;
        House = Instantiate(ColourTheHouse[0]) as GameObject;
        Debug.Log("getting there");
       /** House.transform.SetParent(transform);
        House.transform.position = new Vector3(0.0f, 0.5f, 5.0f);
        ColourTheHouse.Add(House);
    **/

        if (colourState == 0)
        {
            Debug.Log("Colour 0");
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }

        if (colourState == 1)
        {
            Debug.Log("Colour 1");
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

        if (colourState == 2)
        {
            Debug.Log("Colour 2");
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        }
                
        if (colourState == 3)
        {
            Debug.Log("Colour 3");
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

        colourState = (colourState + 1) % 4;


    }
}
