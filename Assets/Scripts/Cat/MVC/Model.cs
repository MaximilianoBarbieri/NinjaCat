using System.Collections;
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
        float moveDirection = ItemManager.IsReverseControls ? -input : input;
        float moveAmount = moveDirection * _cat.Speed * Time.deltaTime;

        Vector3 raycastOrigin = _cat.transform.position;
        Vector3 raycastDirection = new Vector3(moveDirection, 0, 0);
        float raycastDistance = Mathf.Abs(moveAmount) + 0.1f;

        if (!Physics.Raycast(raycastOrigin, raycastDirection, raycastDistance, LayerMask.GetMask("Wall")))
            _cat.transform.Translate(new Vector3(moveAmount, 0, 0));
    }

    public void Jump()
    {
        if (!IsGrounded()) return; 

        var velocity = _cat.catRigidBody.velocity;
        velocity = new Vector3(velocity.x, 0f, velocity.z);
        _cat.catRigidBody.velocity = velocity;

        _cat.catRigidBody.AddForce(Vector3.up * _cat.JumpForce, ForceMode.Impulse);
    }

    public bool IsGrounded()
    {
        float raycastDistance = 0.5f;
        Vector3 origin = new Vector3(_cat.transform.position.x, _cat.GetComponent<Collider>().bounds.min.y + 0.1f,
            _cat.transform.position.z);

        return Physics.Raycast(origin, Vector3.down, raycastDistance, _groundLayer);
    }


    public void TakeDamage()
    {
        _cat._lifeCount--;

        UIManager.OnRefreshLife?.Invoke(_cat._lifeCount);
        
        if (_cat._lifeCount <= 0)
        {
            Debug.Log("Cat perdió todas sus vidas. Cambiando a estado Lose.");
            _cat.stateMachine.ChangeState(Cat.CatState.Lose);
        }
        else
        {
            Debug.Log("Cat recibio daño, vidas restantes: " + _cat._lifeCount);
            _cat.StartCoroutine(InvulnerabilityRoutine());
        }
    }
    
    private IEnumerator InvulnerabilityRoutine()
    {
        _cat.IsInvulnerable = true;

        float blinkDuration = 2f;
        float blinkInterval = 0.1f;
        float elapsedTime = 0f;
        
        SkinnedMeshRenderer[] meshes = _cat.viewTransform.GetComponentsInChildren<SkinnedMeshRenderer>();

        if (meshes.Length == 0)
        {
            Debug.LogError("No se encontraron Renderers en View.");
            yield break;
        }
        
        while (elapsedTime < blinkDuration)
        {
            foreach (SkinnedMeshRenderer mesh in meshes)
            {
                mesh.enabled = !mesh.enabled;
            }
        
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }

        // Al terminar hacerlas tods visibles
        foreach (SkinnedMeshRenderer mesh in meshes)
        {
            mesh.enabled = true;
        }

        _cat.IsInvulnerable = false;
    }


    public void ChangeToSlideCollider()
    {
        _cat.catCollider.height = _cat.originalHeight / 2.5f; 
        _cat.catCollider.center =
            new Vector3(_cat.catCollider.center.x, _cat.originalCenter.y / 2.5f, _cat.catCollider.center.z);
    }

    public void ResetCollider()
    {
        _cat.catCollider.height = _cat.originalHeight;
        _cat.catCollider.center = _cat.originalCenter;
    }
}