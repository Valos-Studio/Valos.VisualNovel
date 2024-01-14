using System;
using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.EditorNodes.NodeEditors;
using Valos.VisualNovel.GameNodes.DialogueNodes;

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

    public void AddStartNode(StartData data)
    {
        
    }

    public void OnNodeSelected(Node node)
    {
        String type = node.GetType().Name;

        switch (type)
        {
            case nameof(DialogueNode):
                Panels.CurrentTab = 1;
                break;
            default:
                Panels.CurrentTab = 0;
                break;
        }
    }

    public void ClearNodes()
    {
        Graph.ClearNodes();
    }
}