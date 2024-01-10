using Godot;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

[Tool]
public partial class GraphEditor : GraphEdit
{
    [Export()] public PopupMenu GraphMenu { get; set; }

    public override void _Ready()
    {
        PopupRequest += OnPopupRequest;

        ConnectionToEmpty += OnConnectionToEmpty;
    }

    public void OnConnectionToEmpty(StringName fromNode, long fromPort, Vector2 releasePosition)
    {
        ShowPopup();
    }

    public void OnPopupRequest(Vector2 position)
    {
        ShowPopup();
    }

    private void ShowPopup()
    {
        GraphMenu.Position = (Vector2I)GetGlobalMousePosition() + GetWindow().Position;

        GraphMenu.Show();
    }
}