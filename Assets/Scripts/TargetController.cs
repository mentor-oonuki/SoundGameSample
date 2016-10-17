using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TargetController : MonoBehaviour
{

    private GameObject DeadLine;
    private GameObject CirclePosition;

    void Start()
    {
        DeadLine = GameObject.Find("DeadLine");
        CirclePosition = GameObject.Find("CirclePosition");
    }

    void Update()
    {
        float speed = SoundGameManager.Instance.Speed;
        gameObject.transform.position += Vector3.down * speed;
        if (gameObject.transform.position.y < DeadLine.transform.position.y)
        {
            GameObject resultPrefab = SoundGameManager.Instance.BadPrefab;
            Instantiate(resultPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

#if (UNITY_IOS || UNITY_ANDROID)
        if (IsTouchObject(gameObject))
        {
            TouchTarget();
        }
#endif
    }

#if !(UNITY_IOS || UNITY_ANDROID)
    void OnMouseDown()
    {
        float offset = Mathf.Abs(CirclePosition.transform.position.y - gameObject.transform.position.y);
        GameObject resultPrefab;
        if (offset < SoundGameManager.Instance.PerfectOffset)
        {
            resultPrefab = SoundGameManager.Instance.PerfectPrefab;
        }
        else if (offset < SoundGameManager.Instance.GoodOffset)
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
#endif

#if (UNITY_IOS || UNITY_ANDROID)
    void TouchTarget()
    {
        float offset = Mathf.Abs(CirclePosition.transform.position.y - gameObject.transform.position.y);
        GameObject resultPrefab;
        if (offset < SoundGameManager.Instance.PerfectOffset)
        {
            resultPrefab = SoundGameManager.Instance.PerfectPrefab;
        }
        else if (offset < SoundGameManager.Instance.GoodOffset)
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
#endif

#if (UNITY_IOS || UNITY_ANDROID)
    private bool IsTouchObject(GameObject aObject)
    {
        int srcId = aObject.gameObject.GetInstanceID();
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.touches[i];
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                Collider2D[] colliders = Physics2D.OverlapPointAll(pos);
                foreach (Collider2D collider in colliders)
                {
                    int dstId = collider.gameObject.GetInstanceID();
                    if (srcId == dstId)
                    {
                        Debug.Log("touch object name : " + aObject.gameObject.name);
                        return true;
                    }
                }
            }
        }
        return false;
    }
#endif
}
