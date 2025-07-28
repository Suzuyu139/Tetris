using UnityEngine;
using Cysharp.Threading.Tasks;

public class InGameUiPresenter : PresenterBase
{
    [SerializeField] InGameUiModel _inGameUiModel = null;
    [SerializeField] InGameUiView _inGameUiView = null;

    GameOverPresenter _gameOverPresenter = null;
    public GameOverPresenter GameOverUiPresenter => _gameOverPresenter;

    bool isAwakeInitialize = false;

    private void Awake()
    {
        _inGameUiView.SetCamera();
        isAwakeInitialize = true;
    }

    private void Start()
    {
        Initialize().Forget();
    }

    protected override async UniTask Initialize()
    {
        await UniTask.WaitUntil(() => isAwakeInitialize);

        _gameOverPresenter = Instantiate(_inGameUiModel.GameOverObj, this.transform).GetComponent<GameOverPresenter>();

        await UniTask.WaitUntil(() =>
        {
            return _gameOverPresenter.IsInitialized;
        });

        IsInitialized = true;
        await UniTask.CompletedTask;
    }
}
