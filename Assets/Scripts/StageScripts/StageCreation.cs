using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageCreation : MonoBehaviour {

	public GameObject stageElementsContainer;		// prefab container for all bar elements	
	public float creationDistanceToPlayer;			// distance where new bars will be created
	
	private List<GameObject> frontBars 
		= new List<GameObject>();
	private List<GameObject> creationBars 
		= new List<GameObject>();
	private GameObject player;
	private float barDistance;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		barDistance = StageProperties.barDistance;
		CreateFirstBars ();
	}

	void Update () {
		CreateStageAtRuntime ();
	}

	void CreateStageAtRuntime() {
		// go through all creation bars
		for(int i = 0; i < creationBars.Count; i++) {
			// check distance to player. if not far away enough, create a new bar
			if(creationBars[i].transform.position.z < 
			   		(player.transform.position.z + creationDistanceToPlayer)) {
				GameObject newBar = CreateBar();
				// set position of new bar to that of the old bar
				newBar.transform.position = creationBars[i].transform.position;
				// set new bar to the front
				newBar.transform.position += Vector3.back *
					(creationBars[i].renderer.bounds.size.z - Difficulty.GetBarDistance());
				// decide random to set newBar right or left to the old bar
				if(Random.Range(0,1) == 0) {
					// check whether the old bar is rightmost
					if(creationBars[i].transform.position.x < StageProperties.barAmount / 2)
						newBar.transform.position += Vector3.right * barDistance;
				} 
				else {
					// check whether the old bar is leftmost
					if(creationBars[i].transform.position.x > -StageProperties.barAmount / 2)
					 	newBar.transform.position += Vector3.left * barDistance;
				}
				// add bar to front list
				frontBars.Add(newBar);
				creationBars.Add(newBar);
			}
		}
		cutList (creationBars, StageProperties.creationBarAmount);
		cutList (frontBars, 10);
	}

	// creates bars around the origin
	void CreateFirstBars () {
		float i = - StageProperties.barAmount / 2;
		while(i < StageProperties.barAmount / 2 + 1) {
			GameObject newBar = CreateBar();
			newBar.transform.position = new Vector3(i * barDistance ,0 ,0);
			frontBars.Add(newBar);
			creationBars.Add(newBar);
			i++;
		}
		cutList (creationBars, StageProperties.creationBarAmount);
	}


	// Creates a new bar at the given position.
	// Builds it with prefab bar elements front, middle, end.
	GameObject CreateBar () {

		// choose a random bar from the container
		Transform barContainer = stageElementsContainer.transform.GetChild(
			Random.Range(0,stageElementsContainer.transform.childCount -1)).transform;

		// create empty GameObject to return
		GameObject newBar = new GameObject ();
		Vector3 pos = Vector3.zero	;
		int barLength = ((int)Difficulty.GetBarLength ()) + 2;

		GameObject barElm = new GameObject();

		for (int i = 0; i < barLength; i++) {
			// choose bar element and instatiate it
			if(i == 0)
				barElm = (Instantiate (barContainer.GetChild (0).gameObject, pos, Quaternion.identity))
					as GameObject;
			else 
			if(i == barLength)
				barElm = (Instantiate(barContainer.GetChild (2).gameObject, pos, Quaternion.identity))
					as GameObject;
			else
				barElm = (Instantiate(barContainer.GetChild (1).gameObject, pos, Quaternion.identity))
					as GameObject;
			// set new bar element as child of return bar
			barElm.transform.parent = newBar.transform;
			pos += Vector3.forward * barElm.renderer.bounds.size.z;
		}
		// adds script to bar for self destruction
		newBar.AddComponent ("BarSelfDestruct");
		newBar.AddComponent ("MeshRenderer"); 
		return newBar;
	}

	// sorts the given list and removes the overflow
	void cutList (List<GameObject> list, int capacity) {
		// use BarComparer to sort GameObjects by their front position
		if(list.Count > capacity) {
			list.Sort(new BarComparer());
			list.RemoveRange (capacity, list.Count - capacity);
		}
	}
}
