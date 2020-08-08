using System;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Vector2 _xMinMax;
    [SerializeField] private Vector2 _zMinMax;
    
    private Vector3? _lastKnownPos;

    void FixedUpdate() {
        if (Input.GetMouseButton(0)) {
            if (_lastKnownPos != null) {
                var moveDiffX = Input.mousePosition.x - _lastKnownPos.Value.x;
                var moveDiffY = Input.mousePosition.y - _lastKnownPos.Value.y;
                var speed = _speed * Time.fixedDeltaTime;
                var addPos = new Vector3(-moveDiffX * speed, 0, -moveDiffY * speed);
                transform.position += addPos;
                ClampPos();
            }
        }
            
        _lastKnownPos = Input.mousePosition;
    }

    private void ClampPos() {
        var currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, _xMinMax.x, _xMinMax.y);
        currentPos.z = Mathf.Clamp(currentPos.z, _zMinMax.x, _zMinMax.y);
        transform.position = currentPos;
    }
}
