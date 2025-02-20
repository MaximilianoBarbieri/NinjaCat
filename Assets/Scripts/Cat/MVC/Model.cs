using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Model
{
    private Cat _cat;

    public bool isGround => IsGrounded();
    public bool isJumping;

    private readonly int _groundLayer = LayerMask.GetMask("Ground");

    public Model(Cat cat) => _cat = cat;

    public void Move(float input) => _cat.transform.Translate(new Vector3(input * _cat.Speed * Time.deltaTime, 0, 0));

    public void Jump()
    {
        if (!IsGrounded()) return; // Evita que salte si no está en el suelo

        var velocity = _cat.catRigidBody.velocity;
        velocity = new Vector3(velocity.x, 0f, velocity.z);
        _cat.catRigidBody.velocity = velocity;

        _cat.catRigidBody.AddForce(Vector3.up * _cat.JumpForce, ForceMode.Impulse);
    }

    public bool IsGrounded()
    {
        float raycastDistance = 0.2f;
        Vector3 origin = new Vector3(_cat.transform.position.x, _cat.GetComponent<Collider>().bounds.min.y + 0.1f, _cat.transform.position.z);

        return Physics.Raycast(origin, Vector3.down, raycastDistance, _groundLayer);
    }


    private void TakeDamage()
    {
    }

    private void CollectPowerUp()
    {
    }

    private void CollectNerf()
    {
    }
    
    
}