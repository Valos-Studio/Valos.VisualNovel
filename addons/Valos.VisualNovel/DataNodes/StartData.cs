using Godot;

namespace Valos.VisualNovel.DataNodes;

[Tool]
[GodotClassName(nameof(StartData))]
public partial class StartData : Node
{
    public Vector2 Location { get; set; }

    public StartData()
    {
        Location = Vector2.Zero;
    }
}