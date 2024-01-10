using Godot;

namespace Valos.VisualNovel.EditorNodes;

[Tool]
public partial class GraphEditor : GraphEdit
{
    [Export()] public PopupMenu GraphMenu { get; set; }

    public override void _Ready()
    {
        PopupRequest += OnPopupRequest;
    }

    public void OnPopupRequest(Vector2 position)
    {
        GraphMenu.Position = (Vector2I)GetGlobalMousePosition() + GetWindow().Position;

        GraphMenu.Show();
    }
}