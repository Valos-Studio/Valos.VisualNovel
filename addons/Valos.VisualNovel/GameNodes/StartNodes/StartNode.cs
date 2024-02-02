using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes.BaseNodes;

namespace Valos.VisualNovel.GameNodes.StartNodes;

[Tool]
public partial class StartNode : GraphNode, ICleanable
{
    public StartData Model { get; private set; }

    public void SetModel(StartData data)
    {
        if (data == null) return;

        Model = data;

        Dragged += OnDragged;
    }

    public void OnDragged(Vector2 from, Vector2 to)
    {
        Model.GridLocation = to;
    }

    public void Clean()
    {
        Dragged -= OnDragged;

        Model = null;
    }
}