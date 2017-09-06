using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INFO : MonoBehaviour {
    public int i;
    public GameObject gm;

	// Use this for initialization
	void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    
    public void If()
    {
        
            gm.SetActive(true);

    }


    public void If2()
    {
       
        {
            gm.SetActive(false);
           
        }
    }
    public void Ifv()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        {
            
                Screen.orientation = ScreenOrientation.AutoRotation;
                Handheld.PlayFullScreenMovie(Example2_WWW.objFileName3video, Color.black, FullScreenMovieControlMode.CancelOnInput);
            }
        }
    }

