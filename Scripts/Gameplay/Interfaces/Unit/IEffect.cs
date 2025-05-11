public interface IEffect
{
    void ApplyEffect();
    void Tick();
    int GetDurationLeft();
    IEffect Finish();
}
