using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Model
{
    private Cat _cat;

    private bool _isJumping;
    private readonly int _groundLayer = LayerMask.GetMask("Ground");

    public Model(Cat cat) => _cat = cat;

    private void Move(float input) => _cat.transform.Translate(new Vector3(input * _cat.Speed * Time.deltaTime, 0, 0));

    public void JumpHandler(Vector3 dir)
    {
        _cat.transform.Translate(dir * _cat.JumpForce * Time.deltaTime);
    }

    public bool TouchGround()
    {
        return Physics.Raycast(_cat.transform.position, Vector3.down, 0.2f, _groundLayer);
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