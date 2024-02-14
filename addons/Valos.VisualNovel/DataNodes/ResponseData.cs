using Godot;
using Godot.Collections;
using Valos.VisualNovel.GameNodes.ResponseNodes;

namespace Valos.VisualNovel.DataNodes;

[Tool]
[GodotClassName(nameof(ResponseData))]
public partial class ResponseData : DataNode
{
    [Export()] public PackedScene Player { get; set; }
    [Export()] public Dictionary<int, string> Responses { get; set; }

    public ResponseData() : base()
    {
        this.Responses = new Dictionary<int, string>();
        
        Title = nameof(ResponseNode);
    }
}