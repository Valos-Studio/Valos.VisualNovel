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

        model.TitleChanged += ModelOnTitleChanged;

        PositionOffset = data.GridLocation;

        SetModel();
    }
    
    public void OnDragged(Vector2 from, Vector2 to)
    {
        if (IsModelValid)
        {
            Model.GridLocation = to;
        }
    }
    
    public void ModelOnTitleChanged(string newTitle)
    {
        Title = newTitle;
    }

    public override void Clean()
    {
        base.Clean();
        
        model.TitleChanged -= ModelOnTitleChanged;

        model = null;
    }
}