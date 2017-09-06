// This example loads an OBJ file from the WWW, including the MTL file and any textures that might be referenced

#pragma strict

var objFileName = "http://www.starscenesoftware.com/objtest/Spot.obj";
var standardMaterial : Material;	// Used if the OBJ file has no MTL file
private var objData : ObjReader.ObjData;
private var loadingText = "";
private var loading = false;

function Load () {
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
			return;
		}
		yield;
	} 
	
	loading = false;
	if (objData == null || objData.gameObjects == null) {
		loadingText = "Error loading file";
		yield;
		return;
	}
	
	loadingText = "Import completed";
//	var numberOfObjects = objData.gameObjects.Length;
//	loadingText = "Generated " + numberOfObjects + " GameObject" + ((numberOfObjects > 1)? "s" : "");
	FocusOnObjects();
}

function OnGUI () {
	GUILayout.BeginArea (Rect(10, 10, 400, 400));
	objFileName = GUILayout.TextField (objFileName, GUILayout.Width(400));
	GUILayout.Label ("Also try pig.obj, car.obj, and cube.obj");
	if (GUILayout.Button ("Import") && !loading) {
		Load();
	}
	GUILayout.Label (loadingText);
	GUILayout.EndArea();
}

function FocusOnObjects () {

}