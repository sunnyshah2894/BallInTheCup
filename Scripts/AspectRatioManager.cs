using UnityEngine;
using System.Collections;

public class AspectRatioManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		float canvasWidth = MyCanvas.canvasWidth ;
		float canvasHeight = MyCanvas.canvasHeight ;
		float currentScreenWidth = 512f ;
		float currentScreenHeight = 320f ; 
		print( canvasWidth +"," +canvasHeight );
		foreach( Transform obj in transform ){

			if( !("Boundary".Equals(obj.tag)) && !( "SlidingButton" ).Equals( obj.tag ) && !("SlidingButtonBig").Equals( obj.tag ) ){

				Vector3 myLocation = obj.transform.localPosition ; 
				float objWidth = obj.GetComponent<RectTransform>().rect.width ; 
				float objHeight = obj.GetComponent<RectTransform>().rect.height ; 
				print( obj.name + "::" + myLocation ) ; 
				obj.transform.localPosition = new Vector3( ((myLocation.x)/currentScreenWidth) * ( canvasWidth ) ,((myLocation.y)/canvasHeight) * ( canvasHeight ) , 0f  ); 
				//obj.transform.localScale *= canvasWidth/currentScreenWidth ; 
				print( obj.name+ "::::::" + new Vector3( ((myLocation.x)/currentScreenWidth) * ( canvasWidth ) ,((myLocation.y)/currentScreenHeight) * ( canvasHeight ) , 0f  ) ); 

			}

		}


	}
	

}
