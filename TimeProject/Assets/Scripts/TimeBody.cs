using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    private bool _isRewinding;
    [SerializeField] private float rewindDuration = 5f;
    
    List<PointInTime> _pointsInTime;
    Rigidbody _rb;

    private void Start()
    {
        _pointsInTime = new List<PointInTime>();
        _rb = GetComponent<Rigidbody>();
    } 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if (_isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    private void Record()
    {
        if (_pointsInTime.Count > Mathf.Round(rewindDuration / Time.fixedDeltaTime))
        {
            _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
        }
        _pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    private void Rewind()
    {
        if (_pointsInTime.Count > 0)
        {
            PointInTime pointInTime = _pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            _pointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    private void StartRewind()
    {
        _isRewinding = true;
        _rb.isKinematic = true;
    }

    private void StopRewind()
    {
        _isRewinding = false;
        _rb.isKinematic = false;
    }
}
