using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes.Lists.Nodes;
using Valos.VisualNovel.NovelPanels.Lists.Connections;

namespace Valos.VisualNovel.GameNodes;

[Tool]
public partial class NovelPanelCode : Node
{
    public StartData StartNode { get; set; }
    public DialogueList Dialogues { get; set; }
    public ResponseList Responses { get; set; }
    public LocationList Locations { get; set; }
    public ConnectionList ConnectionList { get;}
    
    public NovelPanelCode()
    {
        ConnectionList = new ConnectionList();
    }

    public override void _Ready()
    {
        if (Engine.IsEditorHint())
        {
            InitStartData();
            
            InitDialogueNode();
            
            InitResponseNode();

            InitLocationNode();
        }
    }

    private void InitStartData()
    {
        if (HasNode(nameof(StartNode)) == true)
        {
            StartNode = GetNode<StartData>(nameof(StartNode));
        }
        else
        {
            StartNode = new StartData();

            this.AddChildDeferred(StartNode, nameof(StartNode));
        }
    }
    
    private void InitDialogueNode()
    {
        if (HasNode(nameof(Dialogues)) == true)
        {
            Dialogues = GetNode<DialogueList>(nameof(Dialogues));
        }
        else
        {
            Dialogues = new DialogueList();

            this.AddChildDeferred(Dialogues, nameof(Dialogues));
        }
    }
    
    private void InitResponseNode()
    {
        if (HasNode(nameof(Responses)) == true)
        {
            Responses = GetNode<ResponseList>(nameof(Responses));
        }
        else
        {
            Responses = new ResponseList();

            this.AddChildDeferred(Responses, nameof(Responses));  
        }
    }
    
    private void InitLocationNode()
    {
        if (HasNode(nameof(Locations)) == true)
        {
            Locations = GetNode<LocationList>(nameof(Locations));
        }
        else
        {
            Locations = new LocationList();

            this.AddChildDeferred(Locations, nameof(Locations));
        }
    }
}