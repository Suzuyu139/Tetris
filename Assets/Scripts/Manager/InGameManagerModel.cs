using UnityEngine;
using R3;

public class InGameManagerModel : ModelBase
{
    CompositeDisposable _disposables = new CompositeDisposable();

    [SerializeField] float _dropInterval = 0.25f;
    public float DropInterval => _dropInterval;

    [SerializeField] float _nextKeyDownInterval = 0.02f;
    public float NextKeyDownInterval => _nextKeyDownInterval;

    [SerializeField] float _nextKeyLeftRightInterval = 0.25f;
    public float NextKeyLeftRightInterval => _nextKeyLeftRightInterval;

    [SerializeField] float _nextKeyRotateInterval = 0.25f;
    public float NextKeyRotateInterval => _nextKeyRotateInterval;

    [SerializeField] GameObject _gameOverPanel = null;
    public GameObject GameOverPanel => _gameOverPanel;

    float _nextDropTimer = 0.0f;
    public float NextDropTimer => _nextDropTimer;
    public void SetNextDropTimer(float nextDropTimer) => _nextDropTimer = nextDropTimer;

    float _nextKeyDownTimer = 0.0f;
    public float NextKeyDownTimer => _nextKeyDownTimer;
    public void SetNextKeyDownTimer(float nextKeyDownTimer) => _nextKeyDownTimer = nextKeyDownTimer;

    float _nextKeyLeftRightTimer = 0.0f;
    public float NextKeyLeftRightTimer => _nextKeyLeftRightTimer;
    public void SetNextKeyLeftRightTimer(float nextKeyLeftRightTimer) => _nextKeyLeftRightTimer = nextKeyLeftRightTimer;

    float _nextKeyRotateTimer = 0.0f;
    public float NextKeyRotateTimer => _nextKeyRotateTimer;
    public void SetNextKeyRotateTimer(float nextKeyRotateTimer) => _nextKeyRotateTimer = nextKeyRotateTimer;

    ReactiveProperty<bool> _isGameOverReactiveProperty = new ReactiveProperty<bool>(false);
    public ReadOnlyReactiveProperty<bool> GameOverReactiveProperty => _isGameOverReactiveProperty;
    public void SetIsGameOver(bool isGameOver) => _isGameOverReactiveProperty.Value = isGameOver;

    private void Awake()
    {
        _disposables.Add(_isGameOverReactiveProperty);
    }

    private void OnDestroy()
    {
        _disposables.Dispose();
    }
}
