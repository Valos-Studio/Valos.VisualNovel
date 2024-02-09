using System;
using Godot;

namespace Valos.VisualNovel.DataNodes;

[Tool]
[GodotClassName(nameof(DataNode))]
public partial class DataNode : Node
{
    [Signal]
    public delegate void TitleChangedEventHandler(string newTitle);
    [Export()] public String Title { get; set; }
    [Export()] public Vector2 GridLocation { get; set; }
    public DataNode()
    {
        GridLocation = Vector2.Zero;
    }
}