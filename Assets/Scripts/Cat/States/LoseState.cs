using UnityEngine;
using static Utils;

public class LoseState : State
{
    private Cat _cat;

    public LoseState(Cat cat) => _cat = cat;

    public override void OnEnter()
    {
        string obstacleTag = _cat.GetLastObstacle(); 

        Debug.Log("Entrando en LoseState. Último obstáculo: " + obstacleTag);

        switch (obstacleTag)
        {
            case TAG_OBSTACLE_CENTER:
                _cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DEAD_CENTER);
                break;
            case TAG_OBSTACLE_LOW:
                _cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DEAD_LOW);
                break;
            case TAG_OBSTACLE_HIGH:
                _cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DEAD_HIGH);
                break;
            case TAG_OBSTACLE_FALL:
                _cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DEAD_FALL);
                break;
            default:
                _cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DEAD_CENTER);
                break;
        }

        //TODO: Action OnLose para ejecutar OnLoose en las clases correspondientes?
        //_cat.OnLose?.Invoke(); // Detener los Roads al morir
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
    }
}