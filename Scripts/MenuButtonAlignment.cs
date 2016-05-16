using UnityEngine;
using System.Collections;

public class MenuButtonAlignment : MonoBehaviour {

	public GameObject playButton ;
	public GameObject settingsButton ; 
	public GameObject levelButton ;
	public GameObject rateUsButton ;

	private int screenWidth ; 
	private int screenHeight ;

	// Use this for initialization
	void Start () {
	
		screenWidth = (int)this.GetComponent<RectTransform> ().rect.width ;
		screenHeight = (int)this.GetComponent<RectTransform> ().rect.height ;

		print(screenWidth + " , " + screenHeight ) ;

		playButton.transform.localScale = new Vector2(1f,1f) ;
		playButton.transform.localPosition = new Vector2( 0f , 0 - (screenHeight/4) ) ; 
		playButton.GetComponent<RectTransform> ().sizeDelta = new Vector2( (screenHeight/2)*0.8f , (screenHeight/2)*0.8f ) ;

		settingsButton.transform.localScale = new Vector2(1f,1f) ;
		settingsButton.transform.localPosition = new Vector2( screenWidth/2 - (screenHeight/4) , screenHeight/2 - (screenHeight/4) ) ; 
		settingsButton.GetComponent<RectTransform> ().sizeDelta = new Vector2( (screenHeight/4) , (screenHeight/4) ) ;

		levelButton.transform.localScale = new Vector2(1f,1f) ;
		levelButton.transform.localPosition = new Vector2( 0 + screenWidth/4  , 0 - (screenHeight/6) ) ; 
		levelButton.GetComponent<RectTransform> ().sizeDelta = new Vector2( (screenHeight/4) , (screenHeight/4) ) ;

		rateUsButton.transform.localScale = new Vector2(1f,1f) ;
		rateUsButton.transform.localPosition = new Vector2( 0 - screenWidth/4  , 0 - (screenHeight/6) ) ; 
		rateUsButton.GetComponent<RectTransform> ().sizeDelta = new Vector2( (screenHeight/4) , (screenHeight/4) ) ;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
