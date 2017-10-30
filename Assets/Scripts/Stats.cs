using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Stats : MonoBehaviour {

    //I want to have different stats in here which will be affected by the decisions and the colouring in at the begining of the game
    //stats should be of Type Float since they will be changed around
    //Stats will corresspond to different colours
    /*
     * Treasury = Yellow #FFF800FF
     * Happiness = Orange #FF8E00FF
     * Healthiness = Green #28FF00FF
     * Infrastructure = Blue #1300FFFF
     * 
     * */
    public ListsTesting eventsDatabase;

    public Text treasuryText;
    public Text happinessText;
    public Text healthinessText;
    public Text infrastructureText;

    public float Treasury;
    public float Happiness;
    public float Healthiness;
    public float Infrastructure;

    // Use this for initialization
    void Start () {

        Treasury = 100;
        Happiness = 100;
        Healthiness = 100;
        Infrastructure = 100;

        

	}
	
	// Update is called once per frame
	void Update () {

        treasuryText.text = Treasury.ToString();
        happinessText.text = Happiness.ToString();
        healthinessText.text = Healthiness.ToString();
        infrastructureText.text = Infrastructure.ToString();

    }
}
