using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public float speed;

    public Transform target;
    public GameObject CoinPrefab;
    public Camera cam;

    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    public void StartCoinMove(Vector3 _initial, Action onComplete)
    {
        Vector3 targetPos = cam.ScreenToWorldPoint(new Vector3(target.position.x, target.position.y, cam.transform.position.z * -1));
        GameObject _coin = Instantiate(CoinPrefab, transform);

        StartCoroutine(MoveCoin(_coin.transform, _initial, targetPos, onComplete));
    }

    IEnumerator MoveCoin(Transform obj, Vector3 startPos, Vector3 endPos, Action onComplete)
    {
        float time = 0;

        while (time < 1)
        {
            time += speed * Time.deltaTime;
            obj.position = Vector3.Lerp(startPos, endPos, time);

            yield return new WaitForEndOfFrame();
        }

        onComplete.Invoke();
        Destroy(obj.gameObject);
    }
}
