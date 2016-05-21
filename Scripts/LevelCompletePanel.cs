using UnityEngine;
using System.Collections;
using DG.Tweening ;

public class LevelCompletePanel : MonoBehaviour {

	public static GameObject levelCompletePanelObj ;

	/*
	 * Resize the panel according to the screen size;
	 * 
	*/
	void Start () {
		levelCompletePanelObj = GameObject.FindGameObjectWithTag( "levelCompleteScreen" ) ;
	}
	void update(){

		print("hello") ;
		print("glass :  " +  MyCanvas.glass.transform.position ) ; 

	}

	/*
	 * Check the parameter values and compare them with the required parameter values for the level
	 * and appropriately show the no. of stars. Setting the animation parameter movePanelIn to true 
	 * will make the level complete screen to be shown on screen.
	 *
	 */
	public static void MoveInPanel( int noOfHogs , int timeTaken ){

		//Animator a = levelCompletePanelObj.GetComponent<Animator>() ; 
		//a.SetBool("movePanelIn", true);
		print( "canvas width and size : " + MyCanvas.canvasWidth + " , " + MyCanvas.canvasHeight ) ; 
		levelCompletePanelObj.transform.DOLocalMoveX( 0f , 1f , true ) ; 
		print( "my levelCP : " + levelCompletePanelObj.transform.position ) ; 


	}


	public static void resizeLevelCompletePanel(){
		print( "canvas width" + MyCanvas.canvasWidth*2 ) ; 
		levelCompletePanelObj.transform.localPosition = new Vector3( MyCanvas.canvasWidth * 2 , 0 , 0f ) ;
		levelCompletePanelObj.transform.localScale = new Vector3(1f,1f,1f); 
		levelCompletePanelObj.GetComponent<RectTransform>().sizeDelta = new Vector2( MyCanvas.canvasWidth*( 0.7f ) , MyCanvas.canvasHeight*( 0.7f ) ) ; 

		float canvasWidth = MyCanvas.canvasWidth*( 0.7f ) ;
		float canvasHeight = MyCanvas.canvasHeight*( 0.7f ) ;
		float currentScreenWidth = 500f ;
		float currentScreenHeight = 300f ;


		for( int i = 0 ; i < levelCompletePanelObj.transform.childCount ; i++ ){

			GameObject obj = levelCompletePanelObj.transform.GetChild( i ).gameObject ; 
			Vector3 myLocation = obj.transform.localPosition ; 
			float objWidth = obj.GetComponent<RectTransform>().rect.width ; 
			float objHeight = obj.GetComponent<RectTransform>().rect.height ; 
			print( obj.name + "::" + myLocation ) ; 
			obj.transform.localPosition = new Vector3( ((myLocation.x)/currentScreenWidth) * ( canvasWidth ) ,((myLocation.y)/currentScreenHeight) * ( canvasHeight ) , 0f  ); 

			obj.GetComponent<RectTransform>().sizeDelta = new Vector2( obj.GetComponent<RectTransform>().rect.width * ( canvasWidth / currentScreenWidth ) , obj.GetComponent<RectTransform>().rect.height * ( canvasHeight / currentScreenHeight ) ) ; 


		}


		print( levelCompletePanelObj.transform.position ) ; 
	}

}
