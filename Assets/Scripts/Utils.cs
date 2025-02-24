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
    public const float JUMP_FORCE = 10f;

    //ANIMATOR PARAMETERS
    public const string PARAM_BOOL_RUN = "IsRunning";
    public const string PARAM_BOOL_JUMP = "IsJumping";
    public const string PARAM_BOOL_SLIDE = "IsSliding";
    public const string PARAM_BOOL_DEAD = "IsDead";
    
    public const string PARAM_TRIGGER_DAMAGE_ONE = "TakeDamageOne";
    public const string PARAM_TRIGGER_DAMAGE_TWO = "TakeDamageTwo";
    public const string PARAM_TRIGGER_DAMAGE_THREE = "TakeDamageThree";
    
    public const string PARAM_TRIGGER_DEAD_ONE = "DeadOne";
    public const string PARAM_TRIGGER_DEAD_TWO = "DeadTwo";
    public const string PARAM_TRIGGER_DEAD_THREE = "DeadThree";
    public const string PARAM_TRIGGER_DEAD_FOUR = "DeadFour";
    
    public const string PARAM_TRIGGER_DEAD_WIN = "Win";
    
    //AXIS RAW
    public const string AXIS_RAW_HORIZONTAL = "Horizontal";
    public const string AXIS_RAW_VERTICAL = "Vertical";
}