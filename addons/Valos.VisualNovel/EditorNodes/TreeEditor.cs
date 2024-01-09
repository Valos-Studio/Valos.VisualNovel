using Godot;

namespace Valos.VisualNovel.EditorNodes;

public partial class TreeEditor : Control
{
    [Export()] public GraphEdit Graph { get; set; }
}