using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPos;
    void Start()
    {
        initialPos = transform.position;
    }

    //every new pos picked up in new loop
    //once loop is finished the camera should be back to initial position
    //the camera moving from point to point will showcase camera shaking
    public void Play()
    {
        StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while(elapsedTime < shakeDuration)
        {
            transform.position = initialPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            //placeholder
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPos;
    }
}
