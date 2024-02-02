using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes.Lists.Nodes;
using Valos.VisualNovel.NovelPanels.Lists.Connections;

namespace Valos.VisualNovel.GameNodes;

[Tool]
public partial class NovelPanelCode : Node
{
    public StartData StartData { get; set; }
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
            if (HasNode("StartData") == true)
            {
                StartData = GetNode<StartData>("StartData");
            }
            else
            {
                InitStartData();
            }
            
            if (HasNode(nameof(Dialogues)) == true)
            {
                Dialogues = GetNode<DialogueList>(nameof(Dialogues));
            }
            else
            {
                InitDialogueNode(nameof(Dialogues));
            }

            if (HasNode(nameof(Responses)) == true)
            {
                Responses = GetNode<ResponseList>(nameof(Responses));
            }
            else
            {
                InitResponseNode(nameof(Responses));
            }

            if (HasNode(nameof(Locations)) == true)
            {
                Locations = GetNode<LocationList>(nameof(Locations));
            }
            else
            {
                InitLocationNode(nameof(Locations));
            }
        }
    }

    private void InitStartData()
    {
        StartData = new StartData();

        this.AddChildDeferred(StartData, nameof(StartData));
    }
    
    private void InitDialogueNode(string name)
    {
        Dialogues = new DialogueList();

        this.AddChildDeferred(Dialogues, name);
    }
    
    private void InitResponseNode(string name)
    {
        Responses = new ResponseList();

        this.AddChildDeferred(Responses, name);
    }
    
    private void InitLocationNode(string name)
    {
        Locations = new LocationList();

        this.AddChildDeferred(Locations, name);
    }
}