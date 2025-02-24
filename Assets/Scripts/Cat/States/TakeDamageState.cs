using UnityEngine;
using static Utils;

public class TakeDamageState : State
{
    private Cat _cat;

    public TakeDamageState(Cat cat) => _cat = cat;
    
    public override void OnEnter()
    {
        string obstacleTag = _cat.GetLastObstacle(); 

        Debug.Log("Entrando en TakeDamage. Último obstáculo: " + obstacleTag);

        switch (obstacleTag)
        {
            case TAG_OBSTACLE_CENTER:
                _cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DAMAGE_ONE);
                break;
            case TAG_OBSTACLE_LOW:
                _cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DAMAGE_TWO);
                break;
            case TAG_OBSTACLE_HIGH:
                _cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DAMAGE_THREE);
                break;
            default:
                _cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DAMAGE_ONE);
                break;
        }
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
    }
}