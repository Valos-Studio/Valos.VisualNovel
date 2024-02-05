using System;
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
        Graph.ClearNodes();
        
        Graph.LoadNodes();
    }
    
    public void FinalizeEditor()
    {
        Graph.ClearNodes();
    }

    public void OnNodeSelected(Node node)
    {
        String type = node.GetType().Name;

        switch (type)
        {
            case nameof(DialogueNode):
                Panels.CurrentTab = 1;
                break;
            case nameof(ResponseNode):
                Panels.CurrentTab = 2;
                break;
            case nameof(LocationNode):
                Panels.CurrentTab = 3;
                break;
            default:
                Panels.CurrentTab = 0;
                break;
        }
    }
}