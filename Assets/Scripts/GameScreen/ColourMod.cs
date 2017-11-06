using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColourMod : MonoBehaviour
{



    [SerializeField]

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

        if (colourState == 0)
        {
            Debug.Log("Colour 0");
            Material newMat = Resources.Load("Blue", typeof(Material)) as Material;
            gameObject.GetComponent<Renderer>().material = newMat;
        }

        if (colourState == 1)
        {
            Debug.Log("Colour 1");
            Material newMat = Resources.Load("Orange", typeof(Material)) as Material;
            gameObject.GetComponent<Renderer>().material = newMat;
            Selection.activeGameObject = gameObject;
        }

        if (colourState == 2)
        {
            Debug.Log("Colour 2");
            Material newMat = Resources.Load("Green", typeof(Material)) as Material;
            gameObject.GetComponent<Renderer>().material = newMat;
        }
                
        if (colourState == 3)
        {
            Debug.Log("Colour 3");
            Material newMat = Resources.Load("Yellow", typeof(Material)) as Material;
            gameObject.GetComponent<Renderer>().material = newMat;
        }

        colourState = (colourState + 1) % 4;


    }
}
