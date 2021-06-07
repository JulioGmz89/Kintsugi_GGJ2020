using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Target;
    public float minModifier = 7;
    public float maxModifier = 11;

    Vector2 _velocity = Vector2.zero;
    bool _isFollowing = false;

    void Start()
    {
        
    }

    public void StartFollowing()
    {
        _isFollowing = true;
    }

    void Update()
    {
        if (_isFollowing)
        {

            transform.position = Vector2.SmoothDamp(transform.position, Target.position, ref _velocity, Time.deltaTime * Random.Range(minModifier, maxModifier));
        }
    }
}
