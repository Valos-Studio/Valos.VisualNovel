using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes.BaseNodes;

namespace Valos.VisualNovel.GameNodes.LocationNodes;

[Tool]
public partial class LocationNode : BaseNode
{
    public LocationData Model { get; set; }

    public override void _Ready()
    {
        Dragged += OnDragged;
    }

    public void OnDragged(Vector2 from, Vector2 to)
    {
        Model.GridLocation = to;
    }
    
    public override void Clean()
    {
        Dragged -= OnDragged;
        
        Model = null;
    }
}