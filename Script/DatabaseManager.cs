using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase;
using Firebase.Database;
using UnityEngine.Events;

public class DatabaseManager 
{
    public TMP_InputField inp;

    private DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    private string userID;

    // Start is called before the first frame update
    void Start()
    {
        //if (!PlayerPrefs.HasKey("device_id"))
        //{
        //    PlayerPrefs.SetString("device_id",SystemInfo.deviceUniqueIdentifier);
        //}
        //userID = PlayerPrefs.GetString("device_id");
        //Debug.Log(PlayerPrefs.GetString("device_id"));

        userID = SystemInfo.deviceUniqueIdentifier;
        //userID = "3070664ce83ebbacffa3a47a73ecfa13758e8966";
        Debug.Log(userID);


        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        //Debug.Log("Clicked");
        //It should not be user (it should be data) but I am too lazy to edit the code

        //this is the input, mapped according to class "User"
        User newUser = new User(inp.text);

        //To JSON (cuz data is parse to JSON)
        string json = JsonUtility.ToJson(newUser);

        //DO NOT EDIT THIS (it's complicated shit)
        
        //Save Data Here
        reference.Child("users").Child(userID).SetRawJsonValueAsync(json);
    }

    public void SaveHeightData(string height, string username)
    {
        //Debug.Log("Clicked");
        //It should not be user (it should be data) but I am too lazy to edit the code

        //this is the input, mapped according to class "User"
        User newUser = new User(height);

        //To JSON (cuz data is parse to JSON)
        string json = JsonUtility.ToJson(newUser);

        //DO NOT EDIT THIS (it's complicated shit)

        //Save Data Here

         reference.Child("users").Child(username).SetRawJsonValueAsync(json);
        
    }

    //Get Data
        public IEnumerator GetData(Action<List<string[]>> onCallback)
    {
        //List for dynamically add
        List<string[]> playerDataArr = new List<string[]>();

        //DO NOT EDIT THIS
        var myData = reference.Child("users").GetValueAsync();

        //API Call
        yield return new WaitUntil(predicate: () => myData.IsCompleted);

        //IF data completed
        if (myData != null)
        {

            //Data returned as Snapshot
            DataSnapshot snapshot = myData.Result;

            //Translate Value into "Actual" dictionary (There were some reasons why it is broken)
            Dictionary<string, object> snapData = snapshot.Value as Dictionary<string, object>;

            //Debug.Log(snapData.Keys);

            //Get Keys (Declare type for safety purpose)
            Dictionary<string, object>.KeyCollection keyColl = snapData.Keys;

            //Run all possible keys
            foreach (string s in keyColl)
            {
                //Debug.Log(s);
                //Debug.Log((snapData[s]).GetType());

                //Get Child (cuz bugging shit happened)
                 Dictionary<string, object> snapChild = snapData[s] as  Dictionary<string, object>;

                //Actual get Child Data
                 foreach (string t in snapChild.Keys)
                 {
                    // Debug.Log(t);
                    // Debug.Log(s + ": " + snapChild[t].ToString());
                    string[] tmpArr = {s,snapChild[t].ToString()};
                    playerDataArr.Add(tmpArr);
                 }
            }

            //Return on Callback
            onCallback.Invoke(playerDataArr);
        }
    }
}

#region UNUSED_CODE
    // public IEnumerator GetData(Action<string> onCallback)
    // {
    //     var myData = reference.Child("users").Child(userID).Child("data").GetValueAsync();

    //     yield return new WaitUntil(predicate: () => myData.IsCompleted);

    //     if (myData != null)
    //     {
    //         DataSnapshot snapshot = myData.Result;

    //         onCallback.Invoke(snapshot.Value.ToString());
    //     }
    // }

    // public void PrintGetData()
    // {
    //     StartCoroutine(GetData((string data) =>
    //     {
    //         Debug.Log(data);
    //     }));
    // }
#endregion
