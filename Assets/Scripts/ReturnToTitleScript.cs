using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnToTitleScript : MonoBehaviour {

	private static ReturnToTitleScript _instance;

	// ReturnToTitle is a Singleton that persists across scene changes
	// This way we don't need to add a ReturnToTitle in each of our scenes, just the title screen
	void Awake () {
		if (!_instance) {
			_instance = this;
		} else {
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject); // Never destroy this object
	}
	
	// Update is called once per frame
	void Update () {
		//If we hit escape and we aren't in the title scene, load it!
		if (Input.GetKeyDown (KeyCode.Escape) && SceneManager.GetActiveScene().name != "title") {
			SceneManager.LoadScene ("title");
		}
	}
}
