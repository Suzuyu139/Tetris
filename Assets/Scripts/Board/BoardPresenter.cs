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
}
