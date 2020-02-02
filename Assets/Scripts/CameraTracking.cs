using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    private Transform playerTransform;
    Camera cameraComponent;
    public float viewPortMarginX = 0.3f;
    public float viewPortMarginY = 0.3f;
    public float cameraMoveSpeed = 1.0f;

    void Start()
    {
        cameraComponent = GetComponent<Camera>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 viewPosition = cameraComponent.WorldToViewportPoint(playerTransform.position);

        Vector3 targetPosition = transform.position;

        if (viewPosition.x > 1.0f - viewPortMarginX)
        {
            float shiftAmount = playerTransform.position.x - GetIntersection(1.0f - viewPortMarginX, 0.5f).x;
            targetPosition += Vector3.right * shiftAmount;
        }

        if (viewPosition.x < viewPortMarginX)
        {
            float shiftAmount = playerTransform.position.x - GetIntersection(viewPortMarginX, 0.5f).x;
            targetPosition += Vector3.right * shiftAmount;
        }

        if (viewPosition.y > 1.0f - viewPortMarginY)
        {
            float shiftAmount = playerTransform.position.z - GetIntersection(0.5f, 1.0f - viewPortMarginY).z;
            targetPosition += Vector3.forward * shiftAmount;
        }

        if (viewPosition.y < viewPortMarginY)
        {
            float shiftAmount = playerTransform.position.z - GetIntersection(0.5f, viewPortMarginY).z;
            targetPosition += Vector3.forward * shiftAmount;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraMoveSpeed);
    }

    Vector3 GetIntersection(float viewportX, float viewportY)
    {
        Plane worldPlane = new Plane(Vector3.up, playerTransform.position);
        Vector3 rayOrigin = cameraComponent.ViewportToWorldPoint(new Vector3(viewportX, viewportY));
        Ray ray = new Ray(rayOrigin, transform.forward);
        float rayIntersect = 0.0f;
        worldPlane.Raycast(ray, out rayIntersect);
        return ray.GetPoint(rayIntersect);
    }
}
