using Godot;
using Valos.VisualNovel.GameNodes.LocationNodes;

namespace Valos.VisualNovel.DataNodes;

[Tool]
[GodotClassName(nameof(LocationData))]
public partial class LocationData : DataNode
{
    [Export()] public PackedScene Scene { get; set; }
    public LocationData() : base()
    {
        Title = nameof(LocationNode);
    }
}