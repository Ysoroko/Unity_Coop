using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] public bool start = false;
    [SerializeField] AnimationCurve curve;
    [SerializeField] float duration = 1f;
    [SerializeField] Camera camera_to_shake;

    // Update is called once per frame
    void Update()
    {
        if (start) {
            start = false;
            StartCoroutine(Shaking());
        }
    }
    public IEnumerator Shaking() {
        Vector3 startPosition = camera_to_shake.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime <duration) {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime/duration);
            camera_to_shake.transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        camera_to_shake.transform.position = startPosition;
    }   
}
