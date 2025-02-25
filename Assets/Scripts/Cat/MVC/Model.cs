using UnityEngine;
using static Utils;

public class Model
{
    private Cat _cat;

    public bool isGround => IsGrounded();
    public bool isJumping;

    private readonly int _groundLayer = LayerMask.GetMask(LAYER_GROUND);

    public Model(Cat cat) => _cat = cat;

    public void Move(float input)
    {
        _cat.transform.Translate(
            new Vector3((ItemManager.IsReverseControls
                ? -input
                : input) * _cat.Speed * Time.deltaTime, 0, 0));
    }

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
        Vector3 origin = new Vector3(_cat.transform.position.x, _cat.GetComponent<Collider>().bounds.min.y + 0.1f,
            _cat.transform.position.z);

        return Physics.Raycast(origin, Vector3.down, raycastDistance, _groundLayer);
    }


    public void TakeDamage(string obstacleTag)
    {
        _cat._lifeCount--;

        UIManager.OnRefreshLife?.Invoke(_cat._lifeCount);

        Debug.Log("Cat recibió daño, vidas restantes: " + _cat._lifeCount);

        if (_cat._lifeCount <= 0)
        {
            _cat.stateMachine.ChangeState(Cat.CatState.Lose);
            Debug.Log("Cat perdió todas sus vidas. Cambiando a estado Lose.");
        }
        else
        {
            _cat.stateMachine.ChangeState(Cat.CatState.TakeDamage);
        }
    }

    public void ChangeToSlideCollider()
    {
        _cat.catCollider.height = _cat.originalHeight / 2f; // Reducir a la mitad
        _cat.catCollider.center =
            new Vector3(_cat.catCollider.center.x, _cat.originalCenter.y / 2f,
                _cat.catCollider.center.z); // Ajustar la posición
    }

    public void ResetCollider()
    {
        _cat.catCollider.height = _cat.originalHeight;
        _cat.catCollider.center = _cat.originalCenter;
    }

    private void CollectPowerUp()
    {
    }

    private void CollectNerf()
    {
    }
}