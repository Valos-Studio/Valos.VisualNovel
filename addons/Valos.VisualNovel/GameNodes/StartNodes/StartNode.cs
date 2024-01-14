using Godot;
using Valos.VisualNovel.DataNodes;

namespace Valos.VisualNovel.GameNodes.StartNodes;

[Tool]
public partial class StartNode : GraphNode
{
    public StartData Model { get; set; }
}