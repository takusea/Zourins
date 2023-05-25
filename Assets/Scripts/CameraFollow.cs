using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 追跡する対象（船）
    public float smoothSpeed = 0.5f; // カメラの追跡速度

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
