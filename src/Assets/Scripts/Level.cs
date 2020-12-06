using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour {
    [SerializeField] float delayForLoad = 2f;
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayForLoad);
        SceneManager.LoadScene("GameOver");
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }
    public void LoadNextScene()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeScene+1);
    }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void LoadGameScene(string Name)
    {
        SceneManager.LoadScene(Name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
