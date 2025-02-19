using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public Model modelCat { get; private set; }
    public View viewCat { get; private set; }
    public Controller controllerCat { get; private set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpDuration;

    public float Speed => _speed;
    public float JumpForce => _jumpForce;
    public float JumpDuration => _jumpDuration;

    public Rigidbody catRigidBody;

    public StateMachine stateMachine;
    
    public Action OnJump;

    //private float _lifeCount;
    //public float LifeCount => _lifeCount;
    private void Start()
    {
        catRigidBody = GetComponent<Rigidbody>();

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
        stateMachine.AddState(CatState.TakeDamage, new TakeDamageState(this));
        stateMachine.AddState(CatState.Lose, new LoseState(this));
        stateMachine.AddState(CatState.Win, new WinState(this));

        stateMachine.ChangeState(CatState.Run);
    }

    private void Update()
    {
        stateMachine?.Update();

        controllerCat.ControllerUpdate();
    }

    public void Win()
    {
    }

    public void Lose()
    {
    }

    public enum CatState
    {
        Run,
        Jump,
        TakeDamage,
        Lose,
        Win
    }
}