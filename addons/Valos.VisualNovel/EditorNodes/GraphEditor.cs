using Godot;

namespace Valos.VisualNovel.addons.Valos.VisualNovel.EditorNodes;

[Tool]
public partial class GraphEditor : GraphEdit
{
    [Export()] public PopupMenu GraphMenu { get; set; }

    public override void _Ready()
    {
        GuiInput += OnGuiInput;
    }

    public void OnGuiInput(InputEvent @event)
    {
        if (@event is InputEventMouse eventMouse)
        {
            if (eventMouse.ButtonMask == MouseButtonMask.Right)
            {
                GraphMenu.Position = (Vector2I)GetGlobalMousePosition() + GetWindow().Position;

                GraphMenu.Show();
            }
        }
    }
}