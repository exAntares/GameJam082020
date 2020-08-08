using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Camera _camera;
    
    private Vector3? _lastKnownPos;

    void FixedUpdate() {
        if (Input.GetMouseButton(0)) {
            if (_lastKnownPos != null) {
                var moveDiffX = Input.mousePosition.x - _lastKnownPos.Value.x;
                var moveDiffY = Input.mousePosition.y - _lastKnownPos.Value.y;
                var speed = _speed * Time.fixedDeltaTime;
                var addPos = new Vector3(-moveDiffX * speed, 0, -moveDiffY * speed);
                transform.position += addPos;
            }
        }
            
        _lastKnownPos = Input.mousePosition;
    }
}
