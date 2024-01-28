using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class BounceThreeTimes : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Collider2D _collider;

    private PhysicsMaterial2D _material;

    [SerializeField] private int groundedSensitivity;
    [SerializeField] private float targetBounciness;
    [SerializeField] private LayerMask layerMask;

    private readonly List<Vector2> _raycastOrigins = new();

    private Action OnLand;

    private int _bounceCounter;

    private Vector2 _lastVelocity;
    
    private bool IsGrounded
    {
        get;
        set;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _material = _rb.sharedMaterial;

        OnLand += OnLandEvent;
    }

    private void FixedUpdate()
    {
        bool wasGrounded = IsGrounded;

        IsGrounded = false;
        
        _raycastOrigins.Clear();
        
        var bounds = _collider.bounds;

        var bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        var bottomRight = new Vector2(bounds.max.x, bounds.min.y);

        for (var i = 0; i < groundedSensitivity; i++)
        {
            var origin = bottomLeft + (bottomRight - bottomLeft) / (groundedSensitivity - 1) * i;
            origin.y += 0.05f;
            _raycastOrigins.Add(origin);
        }

        foreach (var hit in _raycastOrigins.Select(origin => Physics2D.Raycast(origin, Vector2.down, 0.2f, layerMask)).Where(hit => hit))
        {
            //Debug.Log($"Hit {hit.collider.gameObject.name}");
            IsGrounded = true;
        }

        if (!wasGrounded && IsGrounded)
        {
            _lastVelocity = _rb.velocity;
            OnLand?.Invoke();
        }
    }

    private void OnLandEvent()
    {
        Debug.Log($"LAND {_bounceCounter}");
        if (_bounceCounter < 2)
        {
            _rb.AddForce(-_lastVelocity * targetBounciness, ForceMode2D.Impulse);
            _bounceCounter++;
        }
        else
        {
            _rb.velocity = Vector2.zero;
            Debug.Log("HALT");
            //Do Grow Stuff
            _bounceCounter = 0;
        }
    }

    private void OnDrawGizmos()
    {
        foreach (var origin in _raycastOrigins)
        {
            Gizmos.DrawRay(origin, Vector2.down);
        }
    }
    
    
}
