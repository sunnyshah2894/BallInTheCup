using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour {

	private static GameObject leftWall ; 
	private static GameObject rightWall ; 
	private static GameObject topWall ; 
	private static GameObject bottomWall ; 

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
