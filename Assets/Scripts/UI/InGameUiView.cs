using UnityEngine;
using UnityEngine.Rendering;

public class InGameUiView : ViewBase
{
    [SerializeField] Canvas _canvas = null;

    public void SetCamera()
    {
        _canvas.worldCamera = Camera.main;
        _canvas.sortingOrder = SortingLayerConstants.GetLayer(SortingLayerConstants.Layer.InGameUi);
    }
}
