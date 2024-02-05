using Godot;

namespace Valos.VisualNovel.EditorNodes.Components;

public partial class NameEditor : Control
{
    public string Value
    {
        get => value.Text;
    }

    private LineEdit value;

    public override void _Ready()
    {
        value = GetNode<LineEdit>("LineEdit");
    }
}