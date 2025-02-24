using System;
using UnityEngine;
using static Utils;

public class Cat : MonoBehaviour
{
    public Model modelCat { get; private set; }
    public View viewCat { get; private set; }
    public Controller controllerCat { get; private set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpDuration;
    public int _lifeCount = INITIAL_LIFE; 
    
    public Animator _anim { get; private set; }
    public Rigidbody catRigidBody;
    public StateMachine stateMachine;
    
    public Action OnJump;

    public float Speed => _speed;
    public float JumpForce => _jumpForce;
    public float JumpDuration => _jumpDuration;
    public int LifeCount => _lifeCount;
    

    private void Start()
    {
        catRigidBody = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

        InitializedMVC();
        InitializedStateMachine();
    }

    private void InitializedMVC()
    {
        modelCat = new Model(this);
        viewCat = new View(this);
        controllerCat = new Controller(this);
    }

    private void InitializedStateMachine()
    {
        stateMachine = gameObject.AddComponent<StateMachine>();

        stateMachine.AddState(CatState.Run, new RunState(this));
        stateMachine.AddState(CatState.Jump, new JumpState(this));
        stateMachine.AddState(CatState.Slide, new SlideState(this));
        stateMachine.AddState(CatState.TakeDamage, new TakeDamageState(this));
        stateMachine.AddState(CatState.Lose, new LoseState(this)); //lose o dead?
        stateMachine.AddState(CatState.Win, new WinState(this));

        stateMachine.ChangeState(CatState.Run);
    }

    private void Update()
    {
        stateMachine?.Update();
        controllerCat.ControllerUpdate();
    }

    /*public void TakeDamage()
    {
        _lifeCount--; 

        Debug.Log("Cat recibió daño, vidas restantes: " + _lifeCount);

        if (_lifeCount <= 0)
        {
            stateMachine.ChangeState(CatState.Lose);
            Debug.Log("Cat perdió todas sus vidas. Cambiando a estado Lose.");
            //TODO: ejecutar action OnLose en el state Lose (hacer que se dejen de mover todas las ROADS)
        }
        else
        {
            stateMachine.ChangeState(CatState.TakeDamage);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_OBSTACLE)) 
        {
            modelCat.TakeDamage();
        }
    }

    public void Win()
    {
    }

    public void Lose()
    {
    }
    
    private void OnDrawGizmos()
    {
        if (modelCat == null) return;

        float raycastDistance = 0.2f;
        Vector3 origin = new Vector3(transform.position.x, GetComponent<Collider>().bounds.min.y + 0.1f, transform.position.z);
        Vector3 direction = Vector3.down * raycastDistance;

        Gizmos.color = modelCat.IsGrounded() ? Color.green : Color.red;
        Gizmos.DrawLine(origin, origin + direction);
        Gizmos.DrawSphere(origin + direction, 0.05f);
    }

    public enum CatState
    {
        Run,
        Jump,
        Slide,
        TakeDamage,
        Lose,
        Win
    }
}