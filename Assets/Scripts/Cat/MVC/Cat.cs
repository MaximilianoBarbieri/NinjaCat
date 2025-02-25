using UnityEngine;
using static Utils;

public class Cat : MonoBehaviour
{
    public Model modelCat { get; private set; }
    public View viewCat { get; private set; }
    public Controller controllerCat { get; private set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    public int _lifeCount = INITIAL_LIFE; 
    private int _coins; 
    
    public Animator _anim { get; private set; }
    public Rigidbody catRigidBody;
    public StateMachine stateMachine;
    
    public CapsuleCollider catCollider { get; private set; }
    public float originalHeight { get; private set; }
    public Vector3 originalCenter { get; private set; }
    
    private string lastObstacleTag;
    
    public float Speed => _speed;
    public float JumpForce => _jumpForce;
    public int LifeCount
    {
        get => _lifeCount;
        set => _lifeCount = value;
    }

    public int Coins
    {
        get => _coins;
        set => _coins = value;
    }
    
    public void SetLastObstacle(string obstacleTag) => lastObstacleTag = obstacleTag;
    public string GetLastObstacle() => lastObstacleTag;
    

    private void Start()
    {
        catRigidBody = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        catCollider = GetComponent<CapsuleCollider>();
        originalHeight = catCollider.height;
        originalCenter = catCollider.center;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(LAYER_OBSTACLE))
        {
            SetLastObstacle(other.tag);
            modelCat.TakeDamage(other.tag);
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