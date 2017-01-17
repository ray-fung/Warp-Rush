using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour {

    //Button play;
    //play = this.gameObject.transform.Find("Play").GetComponent<Button>();

    public void OnStartGame ()
    {
        SceneManager.LoadScene(2);
    }

    public void OnExitGame ()
    {
        Application.Quit();
    }

    public void onScoresPress ()
    {
        SceneManager.LoadScene(4);
    }

}
