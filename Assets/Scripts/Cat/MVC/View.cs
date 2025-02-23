
public class View
{
    private Cat _cat;
    public View(Cat cat) => _cat = cat;
    
    public void PLAY_ANIM(string anim, bool value)
    {
        _cat._anim.SetBool(anim, value);
    }
    
    public void PLAY_ANIM_TRIGGER(string anim) //Solo para Death, win o lose
    {
        _cat._anim.SetTrigger(anim);
    }
}