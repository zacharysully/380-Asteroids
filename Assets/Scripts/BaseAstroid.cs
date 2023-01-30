using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAstroid : MonoBehaviour
{
    [SerializeField]
    protected int pointValue;
    [SerializeField]
    protected float moveSpeed;
    protected Vector3 moveDirection;
    protected Rigidbody rb;

    public void InitializeAstroid(Vector2 direction)
    {
        moveDirection = new Vector3(direction.x, 0, direction.y);
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(moveDirection, ForceMode.VelocityChange);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
