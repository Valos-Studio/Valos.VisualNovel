using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes.BaseNodes;

namespace Valos.VisualNovel.GameNodes.StartNodes;

[Tool]
public partial class StartNode : GraphNode, ICleanable
{
    public StartData Model { get; set; }

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
        
        GD.PrintErr("Clean Start Node");
        Dragged -= OnDragged;
        
        Model = null;
    }
}