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

    public static void AddChildDeferred(this Node node, Node child, Node owner)
    {
        node.CallDeferred(Node.MethodName.AddChild, child, true);

        child.SetDeferred(Node.PropertyName.Owner, node);
    }

    public static void AddChildDeferred(this Node node, Node child, Node owner, string name)
    {
        node.CallDeferred(Node.MethodName.AddChild, child);

        child.SetDeferred(Node.PropertyName.Owner, owner);

        child.SetDeferred(Node.PropertyName.Name, name);
    }
}