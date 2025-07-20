using UnityEngine;

public class BoardModel : ModelBase
{
    [SerializeField] int _height = 30;
    public int Height => _height;

    [SerializeField] int _width = 10;
    public int Width => _width;

    [SerializeField] int _header = 8;
    public int Header => _header;

    Transform[,] _grid = null;
    public Transform[,] Grid => _grid;

    private void Awake()
    {
        _grid = new Transform[_width, _height];
    }
}
