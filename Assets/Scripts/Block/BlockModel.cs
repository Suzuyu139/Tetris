using UnityEngine;

public class BlockModel : ModelBase
{
    public enum MoveDirection
    {
        Up,
        Left,
        Right,
        Down
    }

    public enum Rotate
    {
        Right,
        Left,
    }

    [SerializeField] bool _canRotate = true;
    public bool CanRotate => _canRotate;
}
