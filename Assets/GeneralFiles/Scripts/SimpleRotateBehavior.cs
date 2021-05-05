using System.Collections;
using UnityEngine;

public class SimpleRotateBehavior : MonoBehaviour
{
    [SerializeField][Range(-100.0f, 100.0f)] private float rotationSpeed = 0;

    private Transform cachedTransform;

    private void Awake()
    {
        cachedTransform = transform;
    }

    private void Start()
    {
        StartCoroutine(RotateObject());
    }

    private IEnumerator RotateObject()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            cachedTransform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
        }
    }
}

