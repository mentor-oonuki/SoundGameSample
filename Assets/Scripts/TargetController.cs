using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour {

    private GameObject DeadLine;
    private GameObject CirclePosition;

	void Start () {
        DeadLine = GameObject.Find("DeadLine");
        CirclePosition = GameObject.Find("CirclePosition");
    }
	
	void Update () {
        float speed = SoundGameManager.Instance.Speed;
        gameObject.transform.position += Vector3.down * speed;
        if(gameObject.transform.position.y < DeadLine.transform.position.y)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        float offset = Mathf.Abs(CirclePosition.transform.position.y - gameObject.transform.position.y);
        GameObject resultPrefab;
        if (offset < SoundGameManager.Instance.PerfectOffset)
        {
            resultPrefab = SoundGameManager.Instance.PerfectPrefab;
        }
        else if(offset < SoundGameManager.Instance.GoodOffset)
        {
            resultPrefab = SoundGameManager.Instance.GoodPrefab;
        }
        else
        {
            resultPrefab = SoundGameManager.Instance.BadPrefab;
        }
        Instantiate(resultPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
