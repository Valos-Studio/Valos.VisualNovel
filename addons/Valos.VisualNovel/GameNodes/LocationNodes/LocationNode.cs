using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes.BaseNodes;
using Valos.VisualNovel.GameNodes.Lists.Nodes;

namespace Valos.VisualNovel.GameNodes.LocationNodes;

[Tool]
public partial class LocationNode : BaseNode
{
    public StartData StartNode { get; set; }
    public DialogueList Dialogues { get; set; }
    public ResponseList Responses { get; set; }
    
    public LocationData Model
    {
        get => model;
    }

    private LocationData model;
    
    public override void _Ready()
    {
        if (Engine.IsEditorHint())
        {
            StartNode = this.NodeInitializer<StartData>(nameof(StartNode));

            Dialogues = this.NodeInitializer<DialogueList>(nameof(Dialogues));

            Responses = this.NodeInitializer<ResponseList>(nameof(Responses));
            
            Dragged += OnDragged;
        }
    }

    public void SetModel(LocationData data)
    {
        if (data == null)
        {
            base.Clean();
            
            return;
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
    
    private void InitializeProperties(LocationData data)
    {
        PositionOffset = data.GridLocation;

        Title = data.Title;
    }
}