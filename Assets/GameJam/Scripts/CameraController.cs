using System;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [Serializable]
    private struct CameraConstrain {
        public Vector2 xMinMax;
        public Vector2 zMinMax;
    }
    
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _sensitivity = 1.0f;
    [SerializeField] private CameraConstrain _zoomOutConstrain;
    [SerializeField] private CameraConstrain _zoomInConstrain;
    
    [SerializeField] private float _minFov = 1;
    [SerializeField] private float _maxFov = 5;
    
    private Vector3? _lastKnownPos;

    void FixedUpdate() {
        var size= _camera.orthographicSize;
        size += Input.GetAxis("Mouse ScrollWheel") * -_sensitivity;
        size = Mathf.Clamp(size, _minFov, _maxFov);
        _camera.orthographicSize = size;
        
        if (Input.GetMouseButton(0)) {
            if (_lastKnownPos != null) {
                var moveDiffX = Input.mousePosition.x - _lastKnownPos.Value.x;
                var moveDiffY = Input.mousePosition.y - _lastKnownPos.Value.y;
                var speed = _speed * Time.fixedDeltaTime;
                var addPos = new Vector3(-moveDiffX * speed, 0, -moveDiffY * speed);
                transform.position += addPos;
            }
        }

        ClampPos(size, _minFov, _maxFov);
        _lastKnownPos = Input.mousePosition;
    }

    private void ClampPos(float size, float minSize, float maxSize) {
        var constrain = GetConstrain(size, minSize, maxSize);
        var currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, constrain.xMinMax.x, constrain.xMinMax.y);
        currentPos.z = Mathf.Clamp(currentPos.z, constrain.zMinMax.x, constrain.zMinMax.y);
        transform.position = currentPos;
    }

    private CameraConstrain GetConstrain(float size, float minSize, float maxSize) {
        float t = (size - minSize) / (maxSize - minSize);
        var xMinMax = _zoomOutConstrain.xMinMax * t + _zoomInConstrain.xMinMax * (1 - t);
        var zMinMax = _zoomOutConstrain.zMinMax * t + _zoomInConstrain.zMinMax * (1 - t);
        return new CameraConstrain {xMinMax = xMinMax, zMinMax = zMinMax};
    }
}
