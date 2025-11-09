namespace Yulinti.UnityServices.ComponentServices {
    public interface IMoveInputQuery {
        System.Numerics.Vector2 Move { get; }
        bool Sprint { get; }
        bool Crouch { get; }
    }
}