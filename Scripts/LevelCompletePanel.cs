using UnityEngine;
using System.Collections;

public class LevelCompletePanel : MonoBehaviour {

	public static GameObject levelCompletePanelObj ;

	/*
	 * Resize the panel according to the screen size;
	 * 
	*/
	void Start () {
		levelCompletePanelObj = GameObject.FindGameObjectWithTag( "levelCompleteScreen" ) ;
		resizeLevelCompletePanel() ; 
	}

	/*
	 * Check the parameter values and compare them with the required parameter values for the level
	 * and appropriately show the no. of stars. Setting the animation parameter movePanelIn to true 
	 * will make the level complete screen to be shown on screen.
	 *
	 */
	public static void MoveInPanel( int noOfHogs , int timeTaken ){

		Animator a = levelCompletePanelObj.GetComponent<Animator>() ; 
		a.SetBool("movePanelIn", true);

	}

	public static void resizeLevelCompletePanel(){
		print( "canvas width" + MyCanvas.canvasWidth*2 ) ; 
		levelCompletePanelObj.transform.localPosition = new Vector3( MyCanvas.canvasWidth * 2 , 0 , 0f ) ;
		print( levelCompletePanelObj.transform.position ) ; 
	}

}
