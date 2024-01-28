
using Godot;

namespace Valos.VisualNovel.DataNodes;

[Tool]
[GodotClassName(nameof(ResponseData))]
public partial class ResponseData : DataNode
{
    [Export()] public PackedScene Scene { get; set; }
}