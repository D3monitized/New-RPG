using UnityEngine; 

[CreateAssetMenu(fileName = "New Void Event", menuName = "Game Events/Void Event")]
public class VoidEvent : BaseGameEvent<Void>
{
    public void Invoke() => Invoke(new Void());
}
