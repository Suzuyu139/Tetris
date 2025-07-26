using UnityEngine;
using R3;

public class GameOverModel : ModelBase
{
    CompositeDisposable _disposables = new CompositeDisposable();

    ReactiveProperty<bool> _isGameOver = new ReactiveProperty<bool>(false);
    public ReadOnlyReactiveProperty<bool> IsGameOver => _isGameOver;
    public void SetIsGameOver(bool isGameOver) => _isGameOver.Value = isGameOver;

    private void Awake()
    {
        _disposables.Add(_isGameOver);
    }

    private void OnDestroy()
    {
        _disposables.Dispose();
    }
}
