using Godot;
using Valos.VisualNovel.GameNodes.DialogueNodes;

namespace Valos.VisualNovel.DataNodes;

[Tool]
[GodotClassName(nameof(DialogueData))]
public partial class DialogueData : DataNode
{
    [Export()] public PackedScene Character { get; set; }

    public DialogueData() : base()
    {
        Title = nameof(DialogueNode);
    }
}