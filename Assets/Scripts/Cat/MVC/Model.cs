using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Model
{
    private Cat _cat;

    public bool isGround => IsGrounded();

    private readonly int _groundLayer = LayerMask.GetMask("Ground");

    public Model(Cat cat) => _cat = cat;

    private void Move(float input) => _cat.transform.Translate(new Vector3(input * _cat.Speed * Time.deltaTime, 0, 0));

    public void Jump()
    {
        _cat.catRigidBody.velocity =
            new Vector3(_cat.catRigidBody.velocity.x, 0f,
                _cat.catRigidBody.velocity.z); // Resetea la velocidad en Y para un salto consistente
        _cat.catRigidBody.AddForce(Vector3.up * _cat.JumpForce, ForceMode.Impulse);
    }

    public bool IsGrounded()
    {
        return Physics.OverlapSphere(_cat.transform.position, 0.1f, _groundLayer).Length > 0;
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