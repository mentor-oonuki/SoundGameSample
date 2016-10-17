using UnityEngine;
using System.Collections;

public class ResultController : MonoBehaviour {

	IEnumerator Start () {
        yield return StartCoroutine(SelfDestroy());
        Destroy(gameObject);
	}
	
	void Update () {
        transform.position += Vector3.up * Time.deltaTime;
	}

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(0.5f);
    }

}
