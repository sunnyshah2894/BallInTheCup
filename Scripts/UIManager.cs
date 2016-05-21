using UnityEngine;
using System.Collections;
using DG.Tweening ;

public class UIManager : MonoBehaviour {

	bool isOpen = false ;

	public void ToggleMenu() {
		
		if( !isOpen )
			MyCanvas.pauseButton.transform.GetChild(0).GetChild(0).DOLocalMoveY( 192f, 0.3f , true ) ; 
		else
			MyCanvas.pauseButton.transform.GetChild(0).GetChild(0).DOLocalMoveY( 0f, 0.3f , true ) ; 
		isOpen = !isOpen ; 

	}

}
