using UnityEngine;
using Cysharp.Threading.Tasks;

public class InGameManagerPresenter : PresenterBase
{
    [SerializeField] SpawnerPresenter _spawnerPresenter = null;
    [SerializeField] BoardModel _boardPresenter = null;

    private void Start()
    {
        IsInitialized = true;
    }

    protected override async UniTask Initialize()
    {
        IsInitialized = true;
        await UniTask.CompletedTask;
    }
}
