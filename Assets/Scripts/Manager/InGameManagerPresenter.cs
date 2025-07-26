using UnityEngine;
using Cysharp.Threading.Tasks;
using R3.Triggers;
using R3;

public class InGameManagerPresenter : PresenterBase
{
    [SerializeField] InGameManagerModel _inGameManagerModel = null;
    [SerializeField] SpawnerPresenter _spawnerPresenter = null;
    [SerializeField] BoardPresenter _boardPresenter = null;

    [SerializeField] GameOverPresenter _gameOverPresenter = null;

    BlockPresenter _activeBlockPresenter = null;

    private void Start()
    {
        Initialize().Forget();
    }

    protected override async UniTask Initialize()
    {
        _spawnerPresenter.transform.position = Rounding.Round(_spawnerPresenter.transform.position);

        _inGameManagerModel.SetNextKeyDownTimer(Time.time + _inGameManagerModel.NextKeyDownInterval);
        _inGameManagerModel.SetNextKeyLeftRightTimer(Time.time + _inGameManagerModel.NextKeyLeftRightInterval);
        _inGameManagerModel.SetNextKeyRotateTimer(Time.time + _inGameManagerModel.NextKeyRotateInterval);

        GameStart();

        _inGameManagerModel.IsGameOverReactiveProperty.Subscribe(OnIsGameOver).AddTo(gameObject);
        this.UpdateAsObservable().Subscribe(OnUpdate).AddTo(gameObject);

        IsInitialized = true;
        await UniTask.CompletedTask;
    }

    void OnUpdate(Unit unit)
    {
        BlockMove();
    }

    void OnIsGameOver(bool isGameOver)
    {
        if (!isGameOver)
        {
            return;
        }

        _gameOverPresenter.SetIsGameOver(isGameOver);
    }

    void GameStart()
    {
        _activeBlockPresenter = _spawnerPresenter.SpawnBlock();
    }

    void BlockMove()
    {
        if (Time.time > _inGameManagerModel.NextDropTimer)
        {
            _activeBlockPresenter.Move(BlockModel.MoveDirection.Down);
            _inGameManagerModel.SetNextKeyDownTimer(Time.time + _inGameManagerModel.NextKeyDownInterval);
            _inGameManagerModel.SetNextDropTimer(Time.time + _inGameManagerModel.DropInterval);
            if (!_boardPresenter.CheckPosition(_activeBlockPresenter.gameObject))
            {
                if (_boardPresenter.OverLimit(_activeBlockPresenter.gameObject))
                {
                    GameOver();
                }
                else
                {
                    BottomBoard();
                }
            }
        }
    }

    void BottomBoard()
    {
        _activeBlockPresenter.Move(BlockModel.MoveDirection.Up);
        _boardPresenter.SaveBlockInGrid(_activeBlockPresenter.gameObject);
        _activeBlockPresenter = _spawnerPresenter.SpawnBlock();
        _inGameManagerModel.SetNextKeyDownTimer(Time.time);
        _inGameManagerModel.SetNextKeyLeftRightTimer(Time.time);
        _inGameManagerModel.SetNextKeyRotateTimer(Time.time);
        _boardPresenter.ClearAllRows();
    }

    void GameOver()
    {
        _activeBlockPresenter.Move(BlockModel.MoveDirection.Up);
        _inGameManagerModel.SetIsGameOver(true);
    }
}
