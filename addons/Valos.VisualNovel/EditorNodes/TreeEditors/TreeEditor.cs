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
        if (node is DialogueNode)
        {
            Panels.CurrentTab = 1;
        }
        else if (node is ResponseNode)
        {
            Panels.CurrentTab = 2;
        }
        else if (node is LocationNode)
        {
            Panels.CurrentTab = 3;
        }
        else
        {
            Panels.CurrentTab = 0;
        }
    }
}