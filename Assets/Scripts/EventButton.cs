using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EventButton : MonoBehaviour {

    public void OnStartButton()
    {
        SceneManager.LoadScene("Main");
    }

}
