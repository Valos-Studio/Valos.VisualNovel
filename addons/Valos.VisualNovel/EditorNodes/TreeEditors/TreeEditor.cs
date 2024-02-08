using Godot;
using Valos.VisualNovel.EditorNodes.NodeEditors;
using Valos.VisualNovel.GameNodes.DialogueNodes;
using Valos.VisualNovel.GameNodes.LocationNodes;
using Valos.VisualNovel.GameNodes.ResponseNodes;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

[Tool]
public partial class TreeEditor : Control
{
    [Export()] public GraphEditor Graph { get; set; }
    [Export()] public NodeEditor Panels { get; set; }
    
    public override void _Ready()
    {
        Graph.NodeSelected += OnNodeSelected;
    }

    public void InitializeEditor()
    {
        FinalizeEditor();

        this.Graph.LoadNodes();
    }

    public void FinalizeEditor()
    {
        this.Panels.ClearEditors();

        this.Graph.ClearNodes();
    }

    public void OnNodeSelected(Node node)
    {
        if (node is DialogueNode dialogueNode)
        {
            this.Panels.CurrentTab = 1;
            
            this.Panels.DialogueEditor.SetModel(dialogueNode);
        }
        else if (node is ResponseNode responseNode)
        {
            this.Panels.CurrentTab = 2;
            
            this.Panels.ResponseEditor.SetModel(responseNode);
        }
        else if (node is LocationNode locationNode)
        {
            this.Panels.CurrentTab = 3;
            
            this.Panels.LocationEditor.SetModel(locationNode);
        }
        else
        {
            this.Panels.CurrentTab = 0;
        }
    }
}