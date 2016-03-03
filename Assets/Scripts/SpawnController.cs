using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour {

	public Transform spawnStartPoint;
	public Transform spawnEndPoint;
	public List<GameObject> itemsToSpawn;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	//<summary> Spawns an item from our itemsToSpawn list at a random point between spawnStartPoint and spawnEndPoint</summary>
	public void SpawnObject() {
		//Lerp is short for linearly interpolate. These lines pick a random number between the start and end points on each axis
		float x = Mathf.Lerp (spawnStartPoint.position.x, spawnEndPoint.position.x, Random.value);
		float y = Mathf.Lerp (spawnStartPoint.position.y, spawnEndPoint.position.y, Random.value);
		float z = Mathf.Lerp (spawnStartPoint.position.z, spawnEndPoint.position.z, Random.value);

		//Pick a random object from our spawn list
		int itemIndex = (int)(Random.value * itemsToSpawn.Count);
		Instantiate (itemsToSpawn [itemIndex], new Vector3 (x, y, z), Quaternion.identity);
	}
}
