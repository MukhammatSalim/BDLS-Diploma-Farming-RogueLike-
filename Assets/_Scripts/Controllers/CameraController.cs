using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;

    void Update() {
        transform.position = Target.position + Offset;
    }
}
