// This example loads an OBJ file from the WWW, including the MTL file and any textures that might be referenced

using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections;

public class Example2_WWW : MonoBehaviour {
    public GameObject gml3;
	public string objFileName = "http://www.starscenesoftware.com/objtest/Spot.obj";
	public Material standardMaterial;   // Used if the OBJ file has no MTL file
    public static string objFileName2video, objFileName3video, objFileName4video, objFileName5video, objFileName6video, objFileName7video;
    public static string objFileName2;
    ObjReader.ObjData objData;
	string loadingText = "";
	bool loading = false;

    IEnumerator Loadt()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(Load());
    }

        IEnumerator Load () {
		loading = true;
		if (objData != null && objData.gameObjects != null) {
			for (var i = 0; i < objData.gameObjects.Length; i++) {
				Destroy (objData.gameObjects[i]);
			}
		}
		
		objData = ObjReader.use.ConvertFileAsync (objFileName, true, standardMaterial);
		while (!objData.isDone) {
			loadingText = "Loading... " + (objData.progress*100).ToString("f0") + "%";
			if (Input.GetKeyDown (KeyCode.Escape)) {
				objData.Cancel();
				loadingText = "Cancelled download";
				loading = false;
				yield break;
			}
			yield return null;
		}
		loading = false;
		if (objData == null || objData.gameObjects == null) {
			loadingText = "Error loading file";
			yield return null;
			yield break;
		}
		
		loadingText = "Import completed";
        CloudRecoTrackableEventHandler.on3 = false;

        FocusOnObjects();
	}

    void Update()
    {
        if (CloudRecoTrackableEventHandler.on3 == true && !loading)
        {
            StartCoroutine(Loadt());
            CloudRecoTrackableEventHandler.on3 = false;

        }


        objFileName2 = "http://37.187.147.129/projet/flashlive/files/" + CloudRecoTrackableEventHandler.names2 + ".obj";
        objFileName = Regex.Replace(objFileName2, @".jpg", "");
        objFileName2video = "http://37.187.147.129/projet/flashlive/rest.php?video=" + CloudRecoTrackableEventHandler.names2;

        objFileName3video = Regex.Replace(objFileName2video, @".jpg", "");
        objFileName4video = "http://37.187.147.129/projet/flashlive/rest.php?audio=" + CloudRecoTrackableEventHandler.names2;

        objFileName5video = Regex.Replace(objFileName4video, @".jpg", "");
        objFileName6video = "http://37.187.147.129/projet/flashlive/rest.php?html=" + CloudRecoTrackableEventHandler.names2;

        objFileName7video = Regex.Replace(objFileName6video, @".jpg", "");
    }
   
	
	void FocusOnObjects () {
        objData.gameObjects[0].transform.SetParent(gml3.transform);
	}
}