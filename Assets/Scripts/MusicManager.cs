using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    private AudioSource audioSource;
    private int Level;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.Play();
	}
	
	void Update () {
        Level = SoundGameManager.Instance.Level;
        audioSource.pitch = Level * 0.001f + 1;
	}
}
