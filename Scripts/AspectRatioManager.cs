using UnityEngine;
using System.Collections;

public class AspectRatioManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		float canvasWidth = MyCanvas.canvasWidth ;
		float canvasHeight = MyCanvas.canvasHeight ;
		float currentScreenWidth = 520f ;
		float currentScreenHeight = 320f ; 
		print( canvasWidth +"," +canvasHeight );
		foreach( Transform obj in transform ){

			if( !("Boundary".Equals(obj.tag)) /*&& !( "SlidingButton" ).Equals( obj.tag ) && !("SlidingButtonBig").Equals( obj.tag )*/ ){

				Vector3 myLocation = obj.transform.localPosition ; 
				float objWidth = obj.GetComponent<RectTransform>().rect.width ; 
				float objHeight = obj.GetComponent<RectTransform>().rect.height ; 
				print( obj.name + "::" + myLocation ) ; 

				if( !( "SlidingButton" ).Equals( obj.tag ) && !("SlidingButtonBig").Equals( obj.tag ) )
					obj.transform.localPosition = new Vector3( ((myLocation.x)/currentScreenWidth) * ( canvasWidth ) ,((myLocation.y)/canvasHeight) * ( canvasHeight ) , 0f  ); 


				/*if( !"Glass".Equals( obj.tag ) ){

					obj.GetComponent<RectTransform>().sizeDelta = new Vector2( obj.GetComponent<RectTransform>().rect.width * ( canvasWidth / currentScreenWidth ) , obj.GetComponent<RectTransform>().rect.height * ( canvasHeight / currentScreenHeight ) ) ; 

					if( "Player".Equals( obj.tag ) ){
						obj.GetComponent<RectTransform>().sizeDelta = new Vector2( obj.GetComponent<RectTransform>().rect.width * ( canvasWidth / currentScreenWidth ) , obj.GetComponent<RectTransform>().rect.width * ( canvasWidth / currentScreenWidth ) ) ; 
						print( "setting radius as : " + ( ( obj.GetComponent<RectTransform>().rect.width * ( canvasWidth / currentScreenWidth )) / 2f ));
						obj.GetComponent<CircleCollider2D>().radius = ( obj.GetComponent<RectTransform>().rect.width ) / 2f ; 
					}

				}
				else{*/
				print(( canvasWidth / currentScreenWidth ));
				obj.transform.localScale *= ( canvasWidth / currentScreenWidth ) ;


				//}

				print( obj.name+ "::::::" + new Vector3( ((myLocation.x)/currentScreenWidth) * ( canvasWidth ) ,((myLocation.y)/currentScreenHeight) * ( canvasHeight ) , 0f  ) ); 

			}

		}
		LevelCompletePanel.resizeLevelCompletePanel() ; 



	}


}
