using UnityEngine;

public static class SortingLayerConstants
{
    public enum Layer
    {
        Default,
        InGameUi,
        Max,
    }

    public static int GetLayer(Layer layer)
    {
        return (int)layer;
    }
}
