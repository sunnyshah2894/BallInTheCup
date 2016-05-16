using UnityEngine;
using System.Collections;

public class CanvasSurroundColliders : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject []boundaries = GameObject.FindGameObjectsWithTag( "Boundary" ) ; 
		float canvasWidth = this.GetComponent<RectTransform> ().rect.width ; 
		float canvasHeight = this.GetComponent<RectTransform> ().rect.height ; 
		float wallWidth = 300f ; 

		foreach( GameObject ob in boundaries ){

			if( "LeftWall".Equals( ob.name ) ||  "RightWall".Equals( ob.name ) ){

				ob.GetComponent<RectTransform> ().sizeDelta = new Vector2( 300f , canvasHeight*2 ) ; 
				ob.GetComponent<BoxCollider2D> ().size = new Vector2( 300f , canvasHeight*2 ) ;
				if( "LeftWall".Equals( ob.name ) )
					ob.GetComponent<BoxCollider2D> ().offset = new Vector2( -150f , 0f ) ; 
				else ob.GetComponent<BoxCollider2D> ().offset = new Vector2( 150f , 0f ) ; 
			}
			else if( "TopWall".Equals( ob.name ) || "BottomWall".Equals( ob.name ) ){

				ob.GetComponent<RectTransform> ().sizeDelta = new Vector2( canvasWidth*2 , 300f ) ;
				ob.GetComponent<BoxCollider2D> ().size = new Vector2( canvasWidth*2 , 300f ) ;
				if( "BottomWall".Equals( ob.name ) )
					ob.GetComponent<BoxCollider2D> ().offset = new Vector2( 0f , -150f ) ; 
				else ob.GetComponent<BoxCollider2D> ().offset = new Vector2( 0f , 150f ) ; 
			}

		}

	}


}
