using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes.BaseNodes;

namespace Valos.VisualNovel.GameNodes.LocationNodes;

[Tool]
public partial class LocationNode : BaseNode
{
    public LocationData Model { get; set; }

    public void SetModel(LocationData data)
    {
        if (data == null) return;

        Model = data;

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