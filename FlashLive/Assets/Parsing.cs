using UnityEngine;
using LitJson;
using System;
using System.Collections;
public class Parsing : MonoBehaviour
{
    private string url = "http://37.187.147.129/projet/flashlive/rest.php";
    private string id;
    public static string str;
 
    parseJSON parsejson;
    private string s;

    // Use this for initialization
    IEnumerator Cloud()
    {
        id = PlayerPrefs.GetInt("time").ToString();
        WWW mmm = new WWW(url);




        yield return mmm;
        if (mmm.error == null)
        {

            ProcessBooks(mmm.text);

        }
        else
        {

        }

    }


    // Update is called once per frame
    void Update()
    {


        StartCoroutine(Cloud());


    }

    private void ProcessBooks(string jsonString)
    {

        JsonData jsonvale = JsonMapper.ToObject(jsonString);
        parsejson = new parseJSON();

      
        {
            
            s = jsonvale[0]["file_3d"].ToString();

            //OBJ.objPath = s;
            Debug.Log(s);
        }


    }
}
