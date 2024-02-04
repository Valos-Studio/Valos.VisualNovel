using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes.BaseNodes;

namespace Valos.VisualNovel.GameNodes.StartNodes;

[Tool]
public partial class StartNode : GraphNode, ICleanable
{
    public StartData Model { get; private set; }
    protected bool IsModelValid { get; private set; }

    public StartNode()
    {
        IsModelValid = false;
    }

    protected virtual void SetModel()
    {
        IsModelValid = true;
    }

    public override void _Ready()
    {
        Dragged += OnDragged;
    }

    public void SetModel(StartData data)
    {
        if (data == null)
        {
            Clean();
        }

        Model = data;

        SetModel();
    }

    public void OnDragged(Vector2 from, Vector2 to)
    {
        if (IsModelValid)
        {
            Model.GridLocation = to;
        }
    }

    public virtual void Clean()
    {
        Model = null;

        IsModelValid = false;
    }
}