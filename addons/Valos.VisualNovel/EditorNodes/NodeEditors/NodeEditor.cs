using Godot;
using Valos.VisualNovel.EditorNodes.Components;

namespace Valos.VisualNovel.EditorNodes.NodeEditors;

[Tool]
public partial class NodeEditor : TabContainer
{
    private NameEditor nameEditor;

    public override void _Ready()
    {
        nameEditor = GetNode<NameEditor>("%NameEditor");

        TabSelected += OnTabSelected;
    }


    public void OnTabSelected(long tab)
    {
        if (tab > 0)
        {
            Control tabControl = GetCurrentTabControl();
            // tabControl.e
        }
    }
}