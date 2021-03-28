using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    Transform destination;

    [SerializeField]
    GameObject coinPrefab;

    [SerializeField]
    Camera cam;

    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    public void StartCoinMove(Vector3 initialPosition, Action onComplete)
    {
        GameObject coinObject = Instantiate(coinPrefab, transform);

        StartCoroutine(MoveCoin(coinObject.transform, initialPosition, destination.position, onComplete));
    }

    IEnumerator MoveCoin(Transform flyingCoin, Vector3 startPos, Vector3 endPos, Action onComplete)
    {
        Vector3 endPoint = cam.ScreenToWorldPoint(new Vector3(endPos.x, endPos.y, cam.transform.position.z * -1));
        
        float time = 0;

        while (time < 1)
        {
            time += speed * Time.deltaTime;
            flyingCoin.position = Vector3.Lerp(startPos, endPoint, time);

            yield return new WaitForEndOfFrame();

            endPoint = cam.ScreenToWorldPoint(new Vector3(endPos.x, endPos.y, cam.transform.position.z * -1));
        }

        onComplete.Invoke();
        Destroy(flyingCoin.gameObject);
    }
}
