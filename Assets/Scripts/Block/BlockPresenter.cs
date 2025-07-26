using UnityEngine;
using Cysharp.Threading.Tasks;

public class BlockPresenter : PresenterBase
{
    [SerializeField] BlockModel _blockModel = null;
    [SerializeField] BlockView _blockView = null;

    private void Start()
    {
        Initialize().Forget();
    }

    protected override async UniTask Initialize()
    {
        IsInitialized = true;
        await UniTask.CompletedTask;
    }

    public void Move(BlockModel.MoveDirection direction)
    {
        switch (direction)
        {
            case BlockModel.MoveDirection.Up:
                _blockView.MoveUp();
                break;
            case BlockModel.MoveDirection.Down:
                _blockView.MoveDown();
                break;
            case BlockModel.MoveDirection.Left:
                _blockView.MoveLeft();
                break;
            case BlockModel.MoveDirection.Right:
                _blockView.MoveRight();
                break;
            default:
                break;
        }
    }

    public void Rotate(BlockModel.Rotate rotate)
    {
        if (!_blockModel.CanRotate)
        {
            return;
        }

        switch (rotate)
        {
            case BlockModel.Rotate.Right:
                _blockView.RotateRight();
                break;
            case BlockModel.Rotate.Left:
                _blockView.RotateLeft();
                break;
            default:
                break;
        }
    }
}
