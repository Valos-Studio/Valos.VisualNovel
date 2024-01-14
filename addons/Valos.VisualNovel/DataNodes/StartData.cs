using Godot;

namespace Valos.VisualNovel.DataNodes;

[Tool]
[GodotClassName(nameof(StartData))]
public partial class StartData : Node
{
    [Export()]public Vector2 GridLocation { get; set; }

    public StartData()
    {
        GridLocation = Vector2.Zero;
    }
}