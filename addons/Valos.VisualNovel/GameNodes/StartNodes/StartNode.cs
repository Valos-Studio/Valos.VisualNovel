using Godot;
using Valos.VisualNovel.DataNodes;

namespace Valos.VisualNovel.GameNodes.StartNodes;

[Tool]
public partial class StartNode : GraphNode
{
    public StartData Model { get; set; }

    public override void _Ready()
    {
        Dragged += OnDragged;
    }

    public void OnDragged(Vector2 from, Vector2 to)
    {
        GD.PrintErr("Draging this shit");
        
        GD.PrintErr(Model.Name);
        
        Model.GridLocation = to;
    }
}