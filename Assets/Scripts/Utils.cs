public static class Utils
{
    //TAGS
    public const string TAG_PLAYER = "Player";
    public const string TAG_GROUND = "Ground";
    public const string TAG_OBSTACLE_CENTER = "ObstacleCenter";
    public const string TAG_OBSTACLE_LOW = "ObstacleLow";
    public const string TAG_OBSTACLE_HIGH = "ObstacleHigh";
    public const string TAG_OBSTACLE_FALL = "ObstacleFall";
    
    //LAYERS
    public const string LAYER_GROUND = "Ground";
    public const string LAYER_OBSTACLE = "Obstacle";

    //PARAMETERS
    public const int INITIAL_LIFE = 3;
    public const int MAX_LIFECOUNT = 3;
    public const float JUMP_FORCE = 8f;
    
    //STATES CLASS
    internal const string STATE_RUN = "RunState";
    internal const string STATE_JUMP = "JumpState";
    internal const string STATE_FALL = "FallState";
    internal const string STATE_SLIDE = "SlideState";
    internal const string STATE_WIN = "WinState";
    internal const string STATE_LOSE = "LoseState";
    internal const string STATE_DAMAGE = "TakeDamageState";
    internal const string NO_STATE = "No hay estado";

    //ANIMATOR PARAMETERS
    public const string PARAM_BOOL_RUN = "IsRunning";
    public const string PARAM_BOOL_JUMP = "IsJumping";
    public const string PARAM_BOOL_SLIDE = "IsSliding";
    public const string PARAM_BOOL_DEAD = "IsDead";
    
    public const string PARAM_TRIGGER_DEAD_CENTER = "DeadCenter";
    public const string PARAM_TRIGGER_DEAD_LOW = "DeadLow";
    public const string PARAM_TRIGGER_DEAD_HIGH = "DeadHigh";
    public const string PARAM_TRIGGER_DEAD_FALL = "DeadFall";
    
    public const string PARAM_TRIGGER_DEAD_WIN = "Win";
    
    //AXIS RAW
    public const string AXIS_RAW_HORIZONTAL = "Horizontal";
    public const string AXIS_RAW_VERTICAL = "Vertical";
    
    //NAMES
    public const string NAME_SPAWNPOINT = "SpawnItemPoint";
}