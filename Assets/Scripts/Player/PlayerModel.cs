using UnityEngine;
using R3;

public class PlayerModel : ModelBase
{
    CompositeDisposable _disposables = new CompositeDisposable();

    public struct PlayerInputData
    {
        float _move;
        bool _isDown;
        bool _isDrop;
        float _rotate;

        public float Move => _move;
        public float Rotation => _rotate;
        public bool IsDown => _isDown;
        public bool IsDrop => _isDrop;

        public void SetMove(float move) => _move = move;
        public void SetRotate(float rotate) => _rotate = rotate;
        public void SetIsDown(bool isDown) => _isDown = isDown;
        public void SetIsDrop(bool isDrop) => _isDrop = isDrop;
    }

    ReactiveProperty<PlayerInputData> _playerInput = new();
    public ReadOnlyReactiveProperty<PlayerInputData> PlayerInput => _playerInput;
    public void SetPlayerInput(PlayerInputData input) => _playerInput.OnNext(input);

    private void Awake()
    {
        _disposables.Add(_playerInput);
    }

    private void OnDestroy()
    {
        _disposables.Dispose();
    }
}
