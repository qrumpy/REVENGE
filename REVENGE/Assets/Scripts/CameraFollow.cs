using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 cameraOffset;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.1f;

    public Vector3 minPosition; // Minimum s�n�rlar
    public Vector3 maxPosition; // Maksimum s�n�rlar

    void Start()
    {
        // targetObject yoksa, sahnedeki "Player" tagli objeyi bul
        if (targetObject == null)
        {
            targetObject = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void LateUpdate()
    {
        if (targetObject == null)
        {
            return; // targetObject yoksa hi�bir �ey yapma
        }

        Vector3 targetPosition = targetObject.transform.position + cameraOffset;
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // S�n�rlar� kontrol et
        smoothPosition.x = Mathf.Clamp(smoothPosition.x, minPosition.x, maxPosition.x);
        smoothPosition.y = Mathf.Clamp(smoothPosition.y, minPosition.y, maxPosition.y);

        transform.position = smoothPosition;
    }
}
