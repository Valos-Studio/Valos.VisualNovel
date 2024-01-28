using Godot;

namespace Valos.VisualNovel.DataNodes;

[Tool]
[GodotClassName(nameof(DataNode))]
public partial class DataNode : Node
{
    [Export()] public Vector2 GridLocation { get; set; }
    [Export()] public Vector2 NodeName { get; set; }

    public DataNode()
    {
        GridLocation = Vector2.Zero;
    }
}