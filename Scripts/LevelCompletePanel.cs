using UnityEngine;
using System.Collections;

public class LevelCompletePanel : MonoBehaviour {

	/*
	 * Resize the panel according to the screen size;
	 * 
	*/
	void Start () {
	
	}

	/*
	 * Check the parameter values and compare them with the required parameter values for the level
	 * and appropriately show the no. of stars. Setting the animation parameter movePanelIn to true 
	 * will make the level complete screen to be shown on screen.
	 *
	 */
	public static void MoveInPanel( int noOfHogs , int timeTaken ){

		Animator a = GameObject.FindGameObjectWithTag( "levelCompleteScreen" ).GetComponent<Animator>() ; 
		a.SetBool("movePanelIn", true);

	}

}
