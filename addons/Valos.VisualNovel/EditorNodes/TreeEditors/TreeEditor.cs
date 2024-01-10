using Godot;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

public partial class TreeEditor : Control
{
    [Export()] public GraphEdit Graph { get; set; }
}