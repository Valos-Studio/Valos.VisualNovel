using Godot;
using Valos.VisualNovel.DataNodes;

namespace Valos.VisualNovel.GameNodes.BaseNodes;

[Tool]
public partial class BaseNode : GraphNode, ICleanable
{
    public DataNode Model { get; set; }

    public override void _Ready()
    {
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