using Godot;
using Valos.VisualNovel.DataNodes;

namespace Valos.VisualNovel.EditorNodes.Components;

[Tool]
public partial class NameEditor : Control
{
    private LineEdit name;

    private DataNode dataNode;

    public override void _Ready()
    {
        name = GetNode<LineEdit>("%LineEdit");

        name.TextChanged += NameOnTextChanged;
    }

    public void SetModel(DataNode node)
    {
        name.Text = node.Title;

        this.dataNode = node;
    }

    public void Clear()
    {
        this.dataNode = null;

        this.name.Text = null;
    }

    public void NameOnTextChanged(string newText)
    {
        if (this.dataNode != null)
        {
            this.dataNode.Title = newText;
        }
    }
}