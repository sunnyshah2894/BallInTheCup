using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScreenAdjustment : MonoBehaviour {



	// Use this for initialization
	void Start()
	{
		
		// set the desired aspect ratio (the values in this example are
		// hard-coded for 16:9, but you could make them into public
		// variables instead so you can set them at design time)
		float targetaspect = (float)Screen.width / (float)Screen.height;

		// determine the game window's current aspect ratio
		float windowaspect = (float)Screen.width / (float)Screen.height;

		// current viewport height should be scaled by this amount
		float scaleheight = windowaspect / targetaspect;

		// obtain camera component so we can modify its viewport
		Camera camera = GetComponent<Camera>();

		// if scaled height is less than current height, add letterbox
		if (scaleheight < 1.0f)
		{
			Rect rect = camera.rect;

			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;

			camera.rect = rect;
		}
		else // add pillarbox
		{
			float scalewidth = 1.0f / scaleheight;

			Rect rect = camera.rect;

			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;

			camera.rect = rect;
		}


		drawBoundary();

	}

	private float colThickness = 4f;
	private float zPosition = 0f;
	private Vector2 screenSize;

	void drawBoundary ()
	{//Create a Dictionary to contain all our Objects/Transforms
		System.Collections.Generic.Dictionary<string,Transform> colliders = new System.Collections.Generic.Dictionary<string,Transform>();
		//Create our GameObjects and add their Transform components to the Dictionary we created above
		foreach( Transform t in transform ){

			colliders.Add( t.name , t ) ;

		}

		/*colliders.Add("Top",t[0]); //new GameObject().transform);
		colliders.Add("Bottom",t[1]);//new GameObject().transform);
		colliders.Add("Right",t[2]);//new GameObject().transform);
		colliders.Add("Left",t[3]);//new GameObject().transform);*/
		//Generate world space point information for position and scale calculations
		Vector3 cameraPos = Camera.main.transform.position;
		screenSize.x = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)),Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f; //Grab the world-space position values of the start and end positions of the screen, then calculate the distance between them and store it as half, since we only need half that value for distance away from the camera to the edge
		screenSize.y = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)),Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;
		//For each Transform/Object in our Dictionary
		foreach(KeyValuePair<string,Transform> valPair in colliders)
		{
			//valPair.Value.gameObject.AddComponent<BoxCollider2D>(); //Add our colliders. Remove the "2D", if you would like 3D colliders.
			valPair.Value.name = valPair.Key + "Collider"; //Set the object's name to it's "Key" name, and take on "Collider".  i.e: TopCollider

			valPair.Value.parent = transform; //Make the object a child of whatever object this script is on (preferably the camera)

			if(valPair.Key == "LeftWall" || valPair.Key == "RightWall") //Scale the object to the width and height of the screen, using the world-space values calculated earlier
				valPair.Value.localScale = new Vector3(colThickness, screenSize.y * 2, colThickness);
			else
				valPair.Value.localScale = new Vector3(screenSize.x * 2, colThickness, colThickness);
		}  
		//Change positions to align perfectly with outter-edge of screen, adding the world-space values of the screen we generated earlier, and adding/subtracting them with the current camera position, as well as add/subtracting half out objects size so it's not just half way off-screen
		colliders["RightWall"].position = new Vector3(cameraPos.x + screenSize.x + (colliders["RightWall"].localScale.x * 0.5f), cameraPos.y, zPosition);
		colliders["LeftWall"].position = new Vector3(cameraPos.x - screenSize.x - (colliders["LeftWall"].localScale.x * 0.5f), cameraPos.y, zPosition);
		colliders["TopWall"].position = new Vector3(cameraPos.x, cameraPos.y + screenSize.y + (colliders["TopWall"].localScale.y * 0.5f), zPosition);
		colliders["BottomWall"].position = new Vector3(cameraPos.x, cameraPos.y - screenSize.y - (colliders["BottomWall"].localScale.y * 0.5f), zPosition);

		MyCamera.setWallObjects() ; 

	}

}
