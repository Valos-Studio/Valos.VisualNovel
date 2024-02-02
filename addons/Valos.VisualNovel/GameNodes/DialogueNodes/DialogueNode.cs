using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes.BaseNodes;

namespace Valos.VisualNovel.GameNodes.DialogueNodes;

[Tool]
public partial class DialogueNode : BaseNode
{
    public DialogueData Model { get; private set; }
    
    public void SetModel(DialogueData data)
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