using UnityEngine;
using Cysharp.Threading.Tasks;

public class BoardPresenter : PresenterBase
{
    [SerializeField] BoardModel _boardModel = null;
    [SerializeField] BoardView _boardView = null;

    private void Start()
    {
        Initialize().Forget();
    }

    protected override async UniTask Initialize()
    {
        _boardView.CreateBoard(_boardModel.Height, _boardModel.Width, _boardModel.Header);

        IsInitialized = true;

        await UniTask.CompletedTask;
    }

    public bool CheckPosition(GameObject block)
    {
        return _boardModel.CheckPosition(block);
    }

    public void SaveBlockInGrid(GameObject block)
    {
        _boardModel.SaveBlockInGrid(block);
    }

    public void ClearAllRows()
    {
        _boardModel.ClearAllRows();
    }

    public bool OverLimit(GameObject block)
    {
        return _boardModel.OverLimit(block);
    }
}
