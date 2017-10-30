using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;
using UnityEngine;

public class ListsTesting : MonoBehaviour {

    //Have two funcstion for each of the buttons. one function for the consquences of the option A while the other is for option B
    // These funcstions will go through the database and take out the consequences and apply them to the Stats class 
   
    public Text descriptionText;
    public Text optionAButton;
    public Text optionBButton;
    private string connectionString;

    public Stats statsClassReference;
   

    public Button optionA;
    public Button optionB;

    public int treasuryConsequence;
    public float happinessConsequence;
    public float healthinessConsequence;
    public float infrastructureConsequence;

    private int rowNumber;
    private int questionindex;
    private System.Random rng = new System.Random();
    
    
	void Start () {

        //connection to the folder
        connectionString = "URI=file:" + Application.dataPath + "/statsgame.db";

        GetEvent();
        GetOptions();
        // EventAmount();
        
        
          
    }
    /*
    //Amount of events in the database
    public void EventAmount()
    {
        using (IDbConnection connection = new SqliteConnection(connectionString)) 
        {
            connection.Open();
            using (IDbCommand command = connection.CreateCommand())
            {
                string sqlQuery = "SELECT COUNT (*) FROM events";
                command.CommandText = sqlQuery;

                var count = (Int32)command.ExecuteScalar();

                rowNumber = new int[count];
                for(int i = 0; i < count; i++)
                    rowNumber[i] = i;
                Shuffle(rowNumber);
            }
            connection.Close();
        }
        
    }

    //Shuffling the array or list? 
    public static void Shuffle<T>(T [] list)
    {
        var rnd = new System.Random();
        int n = list.Length;
        while (n > 1)
        {
            int k = rnd.Next(n--);
            T temp = list[n];
            list[n] = list[k];
            list[k] = temp;
        }
    }

    **/

    // Update is called once per frame
    void Update () {

        Debug.Log(questionindex);
        Debug.Log("los" + rowNumber);

    }

     public void GetEvent()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //opens the connection to the database
            dbConnection.Open();
            rowNumber = rng.Next(1, 4);

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                
                //Selecting everything from the table 'events'
                string sqlQuery = String.Format("SELECT * FROM events INNER JOIN options on events.id = options.eventid WHERE events.id = ({0}) ", rowNumber);
                dbCmd.CommandText = sqlQuery;

                

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                        //Debug.Log(reader.GetInt32(2));
                        reader.Read(); descriptionText.text = reader.GetString(1);
                    
                        reader.Close();
                         dbConnection.Close();
                }
            }
        }
    }

   void GetOptions()
    {
        using (IDbConnection dbConnector = new SqliteConnection(connectionString))
        {
            dbConnector.Open();
            using (IDbCommand dbCommand = dbConnector.CreateCommand())
            {
                string sqlQueer = String.Format("SELECT * FROM options WHERE options.eventid = {0};", rowNumber);
                dbCommand.CommandText = sqlQueer;

                using (IDataReader reader = dbCommand.ExecuteReader()) 
                {

                    reader.Read();  optionAButton.text = reader.GetString(2);

                    reader.Read(); optionBButton.text = reader.GetString(2);

                    reader.Close();
                    
                }
                dbConnector.Close();
            }
        }
        
    }

    public void OptionAConsequence()
    {
        using (IDbConnection dbConnect = new SqliteConnection(connectionString))
        {
            dbConnect.Open();
            using (IDbCommand dbCommander = dbConnect.CreateCommand())
            {
                string sqlQuestion = String.Format("SELECT * FROM options WHERE options.eventid = {0};",rowNumber);
                dbCommander.CommandText = sqlQuestion;

                using (IDataReader reader = dbCommander.ExecuteReader())
                {

                    //Treasury Consequence
                    reader.Read(); treasuryConsequence = reader.GetInt32(3);
                        if (treasuryConsequence != 0)
                        {
                            statsClassReference.Treasury += treasuryConsequence;
                        }
                        Debug.Log(treasuryConsequence);
                    //Happiness Consequence
                    happinessConsequence = reader.GetInt32(4);
                        if (happinessConsequence != 0)
                        {
                            statsClassReference.Happiness += happinessConsequence;
                        }
                        Debug.Log(happinessConsequence);
                    //Healthiness Consequence
                    healthinessConsequence = reader.GetInt32(5);
                        if (healthinessConsequence != 0)
                        {
                            statsClassReference.Healthiness += healthinessConsequence;
                        }
                    Debug.Log(healthinessConsequence);
                    //Infrastructure Consequence
                     infrastructureConsequence = reader.GetInt32(6);
                        if (infrastructureConsequence != 0)
                        {
                            statsClassReference.Infrastructure += infrastructureConsequence;
                        }
                    Debug.Log(infrastructureConsequence);

                    reader.Close();
                }
                dbConnect.Close();
            }
        }
        GetEvent();
        GetOptions();
    }

    //Perhaps coroutine would work.

    public void OptionBConsequences()
    {
        using (IDbConnection dbConn = new SqliteConnection(connectionString))
        {
            dbConn.Open();
            using (IDbCommand dbComm = dbConn.CreateCommand())
            {
                string sqlQuery = String.Format("SELECT * FROM options WHERE options.eventid = {0};",rowNumber);
                dbComm.CommandText = sqlQuery;
                using (IDataReader reader = dbComm.ExecuteReader())
                {
                    //Reads row one then the other Reader reads the 2nd row
                    reader.Read();
                    reader.Read();

                    //Treasury Consequence
                    treasuryConsequence = reader.GetInt32(3);
                    if (treasuryConsequence != 0)
                    {
                        statsClassReference.Treasury += treasuryConsequence;
                    }
                    Debug.Log(treasuryConsequence);
                    //Happiness Consequence
                    happinessConsequence = reader.GetInt32(4);
                    if (happinessConsequence != 0)
                    {
                        statsClassReference.Happiness += happinessConsequence;
                    }
                    Debug.Log(happinessConsequence);
                    //Healthiness Consequence
                    healthinessConsequence = reader.GetInt32(5);
                    if (healthinessConsequence != 0)
                    {
                        statsClassReference.Healthiness += healthinessConsequence;
                    }
                    Debug.Log(healthinessConsequence);
                    //Infrastructure Consequence
                    infrastructureConsequence = reader.GetInt32(6);
                    if (infrastructureConsequence != 0)
                    {
                        statsClassReference.Infrastructure += infrastructureConsequence;
                    }
                    Debug.Log(infrastructureConsequence);
                    reader.Close();
                }
                dbConn.Close();
            }
        }
        GetEvent();
        GetOptions();
    }

   



}
