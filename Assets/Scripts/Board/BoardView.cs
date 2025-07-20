using UnityEngine;

public class BoardView : ViewBase
{
    [SerializeField] Transform _emptySpriteTf = null;

    public void CreateBoard(int height, int width, int header)
    {
        if (!_emptySpriteTf)
        {
            return;
        }

        for (int y = 0; y < height - header; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Transform clone = Instantiate(_emptySpriteTf, new Vector3(x, y, 0), Quaternion.identity);
                clone.SetParent(this.transform);
            }
        }
    }
}
