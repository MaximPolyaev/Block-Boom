using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float force;
    public Vector2 gravityFactor;

    public GameObject renderObj;
    public GameObject dotObj;
    
    private const int _trajectoryLength = 10;
    private Vector3 _startPos;
    private Vector3 _endPos;
    private Vector3 _startPosAtMouse;
    private Vector3 _forceAtPlayer;

    private Rigidbody2D _rb;
    private GameObject[] _trajectoryDots;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _trajectoryDots = new GameObject[_trajectoryLength];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = transform.position;
            _startPosAtMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // for (int i = 0; i < _trajectoryLength; i++)
            // {
            //     _trajectoryDots[i] = Instantiate(dotObj, renderObj.transform);
            // }
        }
        if (Input.GetMouseButton(0))
        {
            _endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _endPos = _endPos - _startPosAtMouse;
            _endPos = _startPos + _endPos;

            _endPos.z = transform.position.z;
            _forceAtPlayer = _endPos - _startPos;
            _forceAtPlayer.z = transform.position.z;

            // for (int i = 0; i < _trajectoryLength; i++)
            // {
            //     Vector2 newPos2D = calculatePos(i * 0.1f);
            //     Vector3 newPos3D = new Vector3(newPos2D.x, newPos2D.y, _forceAtPlayer.z);
            //     _trajectoryDots[i].transform.position = newPos3D;
            // }
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            _rb.velocity = new Vector2(-_forceAtPlayer.x * force, -_forceAtPlayer.y * force);
            // for (int i = 0; i < _trajectoryLength; i++)
            // {
            //     Destroy(_trajectoryDots[i]);
            // }
        }
    }
    
    private Vector2 calculatePos(float elapsedTime)
    {
        return new Vector2(_endPos.x, _endPos.y) +
               new Vector2(-_forceAtPlayer.x * force, -_forceAtPlayer.y * force) * elapsedTime +
               0.5f * gravityFactor * elapsedTime * elapsedTime;
        
    }
}
