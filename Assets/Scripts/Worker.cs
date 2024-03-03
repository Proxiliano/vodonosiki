using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    [SerializeField] private float _bucketCurrentCapacity;
    [SerializeField] private float _bucketTotalCapacity;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed = 1f;
    
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    private IEnumerator RotateWorker()
    {
        float targetAngle = Random.Range(0f, 360f);
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion relativeRotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);
        Quaternion targetRotation = startRotation * relativeRotation;

        while (elapsedTime < 1f)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            elapsedTime += Time.deltaTime * _rotationSpeed;
            yield return null;
        }
        transform.rotation = targetRotation;
    }

    public void StartWorking()
    {
        RotateWorker();
    }

    public void GoToTank()
    {
    }
}
