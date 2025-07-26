using UnityEngine;
using Cysharp.Threading.Tasks;
using R3;

public class GameOverPresenter : PresenterBase
{
    [SerializeField] GameOverModel _gameOverModel = null;
    [SerializeField] GameOverView _gameOverView = null;
    
    private void Start()
    {
        Initialize().Forget();
    }

    protected override async UniTask Initialize()
    {
        _gameOverView.GameOverButtonObservable.Subscribe(PushRetryButton).AddTo(gameObject);
        _gameOverModel.IsGameOver.Subscribe(GameOver).AddTo(gameObject);
        
        IsInitialized = true;
        await UniTask.CompletedTask;
    }

    void PushRetryButton(Unit unit)
    {

    }

    void GameOver(bool isGameOver)
    {
        if (!isGameOver)
        {
            return;
        }

        _gameOverView.ChangeGameOverObjActive(isGameOver);
    }

    public void SetIsGameOver(bool isGameOver)
    {
        _gameOverModel.SetIsGameOver(isGameOver);
    }
}
