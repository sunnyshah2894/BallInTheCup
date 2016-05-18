using UnityEngine;
using System.Collections;

public class CanvasSurroundColliders : MonoBehaviour {

	private static GameObject leftWall ; 
	private static GameObject rightWall ; 
	private static GameObject topWall ; 
	private static GameObject bottomWall ; 

	// Use this for initialization
	void Start () {

		GameObject []boundaries = GameObject.FindGameObjectsWithTag( "Boundary" ) ; 
		float canvasWidth = MyCanvas.canvasWidth ; 
		float canvasHeight = MyCanvas.canvasHeight ;
		float wallWidth = 300f ; 

		foreach( GameObject ob in boundaries ){

			if( "LeftWall".Equals( ob.name ) ||  "RightWall".Equals( ob.name ) ){

				ob.GetComponent<RectTransform> ().sizeDelta = new Vector2( 300f , canvasHeight*2 ) ; 
				ob.GetComponent<BoxCollider2D> ().size = new Vector2( 300f , canvasHeight*2 ) ;
				if( "LeftWall".Equals( ob.name ) ){
					ob.GetComponent<BoxCollider2D> ().offset = new Vector2( -150f , 0f ) ; 
					leftWall = ob ;
				}
				else {
					ob.GetComponent<BoxCollider2D> ().offset = new Vector2( 150f , 0f ) ; 
					rightWall = ob ; 
				}
			}
			else if( "TopWall".Equals( ob.name ) || "BottomWall".Equals( ob.name ) ){

				ob.GetComponent<RectTransform> ().sizeDelta = new Vector2( canvasWidth*2 , 300f ) ;
				ob.GetComponent<BoxCollider2D> ().size = new Vector2( canvasWidth*2 , 300f ) ;
				if( "BottomWall".Equals( ob.name ) ){
					ob.GetComponent<BoxCollider2D> ().offset = new Vector2( 0f , -150f ) ; 
					bottomWall = ob ; 
				}
				else{
					ob.GetComponent<BoxCollider2D> ().offset = new Vector2( 0f , 150f ) ; 
					topWall = ob ; 
				}
			}

		}

		chooseAppropriatePauseButton() ; 
		MyCanvas.glass.GetComponent<Rigidbody2D>().isKinematic = false ; 

	}

	public static void chooseAppropriatePauseButton(){

		GameObject slidingButtonSmall = GameObject.FindGameObjectWithTag( "SlidingButton" );
		GameObject slidingButtonBig = GameObject.FindGameObjectWithTag( "SlidingButtonBig" );

		if( MyCanvas.canvasWidth > 900 && MyCanvas.canvasHeight >400 ){

			Destroy(slidingButtonSmall);

		}
		else{

			Destroy( slidingButtonBig );

		}

	}

	public static void setWallObjects(){

		GameObject [] walls = new GameObject[4] ; 
		walls = GameObject.FindGameObjectsWithTag( "Boundary" );
		foreach( GameObject go in walls ) {

			if( "LeftWallCollider".Equals( go.name ) ){

				leftWall = go ; 
			}
			else if( "RightWallCollider".Equals( go.name ) ){

				rightWall = go ; 

			}
			else if( "TopWallCollider".Equals( go.name ) ){

				topWall = go ; 

			}
			else if( "BottomWallCollider".Equals( go.name ) ){

				bottomWall = go ;

			}

		}

	}

	public static void removeLeftBoundary(){

		Destroy( leftWall ) ;

	}
	public static void removeRightBoundary(){

		Destroy( rightWall ) ;

	}
	public static void removeTopBoundary(){

		Destroy( topWall ) ;

	}
	public static void removeBottomBoundary(){

		Destroy( bottomWall ) ;

	}







}
