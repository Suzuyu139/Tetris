using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerInputPresenter : PresenterBase
{
    [SerializeField] PlayerModel _playerModel = null;

    PlayerModel.PlayerInputData _inputData = new PlayerModel.PlayerInputData();

    private void Start()
    {
        Initialize().Forget();
    }

    protected override async UniTask Initialize()
    {
        IsInitialized = true;
        await UniTask.CompletedTask;
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.action.phase == InputActionPhase.Started)
        {
            return;
        }

        var value = context.ReadValue<Vector2>();

        _inputData.SetMove(value.x);

        _playerModel.SetPlayerInput(_inputData);
    }
}
