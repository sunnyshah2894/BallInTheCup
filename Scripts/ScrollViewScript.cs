using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollViewScript : MonoBehaviour 
{

	public Transform excellentLevel;
	public Transform goodLevel;
	public Transform poorLevel;
	public Transform lockLevel;
	public Transform currLevel;

	public GameObject inventory ; 
	public GameObject indicatorPrefabRef;
	public Sprite blankSpriteRef, SelectedSpriteRef;
	public GameObject HeaderPanel ;
	public int noofLevels ;
	public GameObject canvasObj ;

	public int currentLevel ; 
	private float currentPosition;

	private List<Transform> objects;
	private int inventoryWidth = 0 , inventoryHeight = 0 ;
	private int myvalue  = 0;

	void loadLevel( int levelNo ){

		print(levelNo);

	}

	void Start()
	{

		currentLevel = PlayerPrefs.GetInt( MyPlayerPreferences.CURRENT_LEVEL_STRING  , 66 ) ;
		objects = new List<Transform>() ; 

		inventoryWidth = (int)canvasObj.GetComponent<RectTransform> ().rect.width ;
		inventoryHeight = (int)canvasObj.GetComponent<RectTransform> ().rect.height ;

		for( int i= 0; i< noofLevels ; i++ ){
			int a = Random.Range(1,4) ;
			if( i == currentLevel ){

				a = 4 ; 

			}
			if( i> currentLevel){
				a=5 ; 
			}

			GameObject leveli = null ;
			if( a == 1 )
				leveli = Instantiate(excellentLevel.gameObject) as GameObject ;
			else if( a == 2)
				leveli = Instantiate(goodLevel.gameObject) as GameObject ;
			else if( a == 3 )
				leveli = Instantiate(poorLevel.gameObject) as GameObject ;
			else if( a == 4 )
				leveli = Instantiate(currLevel.gameObject) as GameObject ;
			else{
				leveli = Instantiate(lockLevel.gameObject) as GameObject ;
				leveli.GetComponent<Button>().interactable = false ;
				leveli.GetComponent<Button>().onClick.RemoveAllListeners();
			}

			leveli.transform.position = inventory.transform.position ;// Vector2( 3 , leveli.transform.position.y + 6 );
			leveli.transform.parent = inventory.transform ;
			leveli.transform.localScale = new Vector2(1f,1f) ;
			leveli.transform.GetChild(0).GetComponent<Text>().text = ""+ (i +1) ;
			leveli.transform.GetChild(0).localScale = new Vector2(1f,1f) ;
			int min = Mathf.Max( inventoryWidth/5 , inventoryHeight/5  ) ;
			print(min);
			leveli.GetComponent<RectTransform> ().sizeDelta = new Vector2( min,min); 
			leveli.transform.GetChild(0).GetComponent<RectTransform> ().sizeDelta = new Vector2( min/1.25f,min/1.25f ); 
			objects.Add( leveli.transform ) ;

		}

		int pixelsToMoveHeader = (int)(inventoryHeight*(2f/5f)) ;

		HeaderPanel.GetComponent<LayoutElement>().preferredHeight = (int)inventoryHeight /5 ;
		HeaderPanel.GetComponent<RectTransform>().localPosition = new Vector2( 0f ,  pixelsToMoveHeader ) ; 

		print( "size of back : " + pixelsToMoveHeader/1.25f );
		HeaderPanel.transform.GetChild(0).localScale = new Vector2(1f,1f) ;
		HeaderPanel.transform.GetChild(0).GetComponent<RectTransform> ().sizeDelta = new Vector2( inventoryHeight/6.25f , inventoryHeight/6.25f ) ;
		HeaderPanel.transform.GetChild(0).localPosition = new Vector2( - inventoryWidth/2 + inventoryHeight/5 , 0f ) ; 

		initializeScrollView();
	}

	void initializeScrollView()
	{
		arrangeAndInitializePositions();
	}
		

	void arrangeAndInitializePositions()
	{

		int counter = 0;

		int countWidth = (int)(inventoryWidth / 5) ;
		int halfWidth = (int)(inventoryWidth / 2 );
		int countHeight = Mathf.Max( (int)(inventoryHeight / 5 ) , countWidth );
		int halfHeight = (int)(inventoryHeight / 2 );
		currentPosition = 4* countHeight ;
		print( inventoryWidth + "," + (int)inventoryHeight ) ;

		int value = (int)(((-1)*(currentPosition - countHeight*((int)((noofLevels)/4)) ))/2)  ;

		myvalue = (int)(((-1)*(currentPosition - countHeight*((int)((1)/4)) ))/2)  ;
		print( value ) ; 
		foreach (Transform currentTransform in objects) 
		{
			if( (counter+1) % 4 == 1 )
				currentTransform.localPosition = new Vector3 ( countWidth -halfWidth , currentPosition - countHeight*((int)(counter/4)) - halfHeight + value  , currentTransform.position.z);
			else if( (counter+1) % 4 == 2  )
				currentTransform.localPosition = new Vector3 ( 2*countWidth -halfWidth , currentPosition - countHeight*((int)(counter/4)) - halfHeight + value , currentTransform.position.z);
			else if( (counter+1) % 4 == 3 )
				currentTransform.localPosition = new Vector3 ( 3* countWidth - halfWidth, currentPosition - countHeight*((int)(counter/4)) - halfHeight + value , currentTransform.position.z);
			else{
				currentTransform.localPosition = new Vector3 (4* countWidth - halfWidth, currentPosition - countHeight*((int)(counter/4)) - halfHeight + value , currentTransform.position.z);
			}
			counter++;

		}
		print("Current level : " + currentLevel ) ; 
		inventory.GetComponent<LayoutElement>().preferredHeight = 2*(currentPosition - halfHeight + value + halfHeight) ;  
		inventory.transform.localPosition = new Vector2( 0 , ((-1)*( (currentPosition - halfHeight + value + halfHeight) )) + countHeight *((int)((currentLevel+4)/4)) );

	}


	void Update ()   
	{
		

	}






}