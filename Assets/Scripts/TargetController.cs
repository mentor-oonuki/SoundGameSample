using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour {

    public float Speed;
    private GameObject DeadLine;

	void Start () {
        DeadLine = GameObject.Find("DeadLine");
	}
	
	void Update () {
        gameObject.transform.position += Vector3.down * Speed;
        if(gameObject.transform.position.y < DeadLine.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
