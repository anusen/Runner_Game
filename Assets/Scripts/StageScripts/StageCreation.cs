using UnityEngine;
using System.Collections;

public class StageCreation : MonoBehaviour {

	public GameObject stageElementsContainer;	
	public float creationDistanceToPlayer;		// distance where new bars will be created
	public float destroyingDistanceToPlayer;	// distance where old bars will be destroyed

	private ArrayList currentStageElements = new ArrayList();
	private ArrayList frontStageElements = new ArrayList();
	private Vector3 playerPosition;
	private System.Random rnd = new System.Random();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}


	void createFirstBars () {

	}

	// Creates a new bar at the given position.
	// Builds it with prefab bar elements begin, middle, end.
	void createNewBar(Vector3 position) {

		// choose a random bar from the container
		Transform barContainer = stageElementsContainer.transform.GetChild(
			rnd.Next(stageElementsContainer.transform.childCount -1)).transform;

		// get the bar elements
		GameObject begin = barContainer.GetChild (0).gameObject;
		GameObject middle = barContainer.GetChild (1).gameObject;
		GameObject end = barContainer.GetChild (2).gameObject;

		// get bar length from Difficulty skript
		int barLength = (int)Difficulty.GetBarLength ();
		Vector3 barElementPosition = position;

		// create bar and save elements
		currentStageElements.Add (Instantiate (begin, barElementPosition, Quaternion.identity) as GameObject);
		barElementPosition += Vector3.forward * begin.renderer.bounds.size.z;
		for (int i = 1; i <= barLength; i++) {
			currentStageElements.Add (
				Instantiate (middle, barElementPosition, Quaternion.identity) as GameObject);
			barElementPosition += Vector3.forward * begin.renderer.bounds.size.z;
		}
		end = Instantiate(end, barElementPosition, Quaternion.identity) as GameObject;
		currentStageElements.Add (end);
		frontStageElements.Add (end);
	}
}
