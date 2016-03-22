using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSchtuff : MonoBehaviour {

	public void ButtonStart(){
		SceneManager.LoadScene (1);
	}

	public void QuitButton(){
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
		Application.Quit ();
	}

}
