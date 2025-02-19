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
        var velocity = _cat.catRigidBody.velocity;

        velocity = new Vector3(velocity.x, 0f, velocity.z);

        _cat.catRigidBody.velocity = velocity;

        _cat.catRigidBody.AddForce(Vector3.up * _cat.JumpForce, ForceMode.Impulse);
    }

    public bool IsGrounded()
    {
        return Physics.OverlapSphere(_cat.transform.position, 0.01f, _groundLayer).Length > 0;
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