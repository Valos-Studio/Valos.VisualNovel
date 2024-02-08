using Godot;

namespace Valos.VisualNovel.EditorNodes.Components;

[Tool]
public partial class NameEditor : Control
{
    public string NameValue
    {
        get => name.Text;
        set => this.name.Text = value;
    }

    private LineEdit name;

    public override void _Ready()
    {
        name = GetNode<LineEdit>("%LineEdit");
    }
}