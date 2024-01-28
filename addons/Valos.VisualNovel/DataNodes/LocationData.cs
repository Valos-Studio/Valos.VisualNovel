using Godot;

namespace Valos.VisualNovel.DataNodes;

[Tool]
[GodotClassName(nameof(LocationData))]
public partial class LocationData : DataNode
{
    [Export()] public PackedScene Scene { get; set; }
}