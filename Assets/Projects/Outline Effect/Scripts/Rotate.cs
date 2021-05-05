using System.Collections;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField][Range(-100.0f, 100.0f)] private float rotationSpeed = 0;

    private Transform cachedTransform;
    private bool isActive = false;

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
            if (isActive)
            {
                cachedTransform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
            }
        }
    }

    public void SetStatus(bool isActive)
    {
        this.isActive = isActive;
    }
}

