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

    public bool CheckPosition(GameObject block)
    {
        foreach (Transform item in block.transform)
        {
            Vector2 pos = Rounding.Round(item.position);

            if (!BoardOutCheck((int)pos.x, (int)pos.y))
            {
                return false;
            }

            if (BlockCheck((int)pos.x, (int)pos.y, block))
            {
                return false;
            }
        }
        return true;
    }

    bool BoardOutCheck(int x, int y)
    {
        return (x >= 0 && x < _width && y >= 0);
    }

    bool BlockCheck(int x, int y, GameObject block)
    {
        return (_grid[x, y] != null && _grid[x, y].parent != block.transform);
    }

    public void SaveBlockInGrid(GameObject block)
    {
        foreach (Transform item in block.transform)
        {
            Vector2 pos = Rounding.Round(item.position);
            _grid[(int)pos.x, (int)pos.y] = item;
        }
    }

    public void ClearAllRows()
    {
        for (int y = 0; y < _height; y++)
        {
            if (IsComplete(y))
            {
                ClearRow(y);
                ShiftRowsDown(y + 1);
                y--;
            }
        }
    }

    bool IsComplete(int y)
    {
        for (int x = 0; x < _width; x++)
        {
            if (_grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    void ClearRow(int y)
    {
        for (int x = 0; x < _width; x++)
        {
            if (_grid[x, y] != null)
            {
                Destroy(_grid[x, y].gameObject);
            }
            _grid[x, y] = null;
        }
    }

    void ShiftRowsDown(int startY)
    {
        for (int y = startY; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                if (_grid[x, y] != null)
                {
                    _grid[x, y - 1] = _grid[x, y];
                    _grid[x, y] = null;
                    _grid[x, y - 1].position += Vector3.down;
                }
            }
        }
    }

    public bool OverLimit(GameObject block)
    {
        foreach (Transform item in block.transform)
        {
            if (item.transform.position.y >= _height - _header)
            {
                return true;
            }
        }
        return false;
    }
}
