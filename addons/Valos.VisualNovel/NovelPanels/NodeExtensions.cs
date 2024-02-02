using Godot;

namespace Valos.VisualNovel.GameNodes;

[Tool]
public static class NodeExtension
{
    public static void AddChildDeferred(this Node node, Node child, string name)
    {
        node.CallDeferred(Node.MethodName.AddChild, child);

        child.SetDeferred(Node.PropertyName.Owner, node);

        child.SetDeferred(Node.PropertyName.Name, name);
    }
}