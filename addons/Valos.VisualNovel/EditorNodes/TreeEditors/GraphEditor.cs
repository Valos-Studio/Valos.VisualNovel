using System;
using System.Threading.Tasks;
using Godot;
using Valos.VisualNovel.EditorNodes.Menus;
using Valos.VisualNovel.GameNodes.BaseNodes;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

[Tool]
public partial class GraphEditor : GraphEdit
{
    [Export()] public GraphMenu GraphMenu { get; set; }

    public override void _Ready()
    {
        InitializeSignals();
    }



    private void DeleteNode(StringName nodeName)
    {
        try
        {
            BaseNode node = GetNode<BaseNode>(nodeName.ToString());

            if (Validator.IsValid(node) == true)
            {
                // node.OnDeleteRequest();

                RemoveChild(node);
            }
        }
        catch (Exception e)
        {
            GD.PrintErr(e);
        }
    }

    private async Task<GraphNode> ShowPopup(Vector2 gridPosition)
    {
        this.GraphMenu.Position = (Vector2I)GetGlobalMousePosition() + GetWindow().Position;

        this.GraphMenu.Show();

        Variant[] result = await ToSignal(this.GraphMenu, nameof(GraphMenu.AddNode));

        if (result.Length > 0)
        {
            return AddSelectionNode((long)result[0].Obj, gridPosition);
        }

        return null;
    }

    private GraphNode AddSelectionNode(long selection, Vector2 gridPosition)
    {
        GraphNode node = this.GraphMenu.GetGraphNode((GraphMenuSelection)selection);

        AddNewGraphNode(node, gridPosition);

        return node;
    }

    public void AddNewGraphNode(GraphNode graphNode, Vector2 gridPosition)
    {
        this.AddChild(graphNode, true);

        graphNode.Owner = this.Owner;

        graphNode.PositionOffset = (gridPosition + this.ScrollOffset) / this.Zoom;
    }
}