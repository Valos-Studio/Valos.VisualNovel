using Godot;
using Valos.VisualNovel.GameNodes.BaseNodes;
using Valos.VisualNovel.GameNodes.DialogueNodes;

namespace Valos.VisualNovel.EditorNodes.NodeEditors;

[Tool]
public partial class NodeEditor : TabContainer
{
    public void SetNodeForEdit(BaseNode node)
    {
        Control tabControl = GetCurrentTabControl();

        switch (CurrentTab)
        {
            case 1:
                DialogueEditor editor = tabControl as DialogueEditor;
                editor.SetModel(node as DialogueNode);
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                return;
        }
    }
}