using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes.BaseNodes;

namespace Valos.VisualNovel.GameNodes.DialogueNodes;

[Tool]
public partial class DialogueNode : BaseNode
{
    public DialogueData Model
    {
        get => model;
    }

    private DialogueData model;

    public override void _Ready()
    {
        Dragged += OnDragged;
    }

    public void SetModel(DialogueData data)
    {
        if (data == null)
        {
            base.Clean();
        }

        model = data;

        SetModel();
    }

    public void OnDragged(Vector2 from, Vector2 to)
    {
        if (IsModelValid)
        {
            Model.GridLocation = to;
        }
    }

    public override void Clean()
    {
        base.Clean();

        model = null;
    }
}