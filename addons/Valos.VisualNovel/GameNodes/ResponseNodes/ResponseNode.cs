using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes.BaseNodes;

namespace Valos.VisualNovel.GameNodes.ResponseNodes;

[Tool]
public partial class ResponseNode : BaseNode
{
    public ResponseData Model
    {
        get => model;
    }

    private ResponseData model;

    public override void _Ready()
    {
        Dragged += OnDragged;
    }

    public void SetModel(ResponseData data)
    {
        if (data == null)
        {
            base.Clean();
        }

        model = data;
        
        model.TitleChanged += ModelOnTitleChanged;
        
        InitializeProperties(data);
        
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
    
    private void InitializeProperties(ResponseData data)
    {
        PositionOffset = data.GridLocation;

        Title = data.Title;
    }
}