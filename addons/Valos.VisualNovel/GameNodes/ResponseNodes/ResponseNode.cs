using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes.BaseNodes;

namespace Valos.VisualNovel.GameNodes.ResponseNodes;

[Tool]
public partial class ResponseNode : BaseNode
{
    public ResponseData Model { get; private set; }
    
    public void SetModel(ResponseData data)
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