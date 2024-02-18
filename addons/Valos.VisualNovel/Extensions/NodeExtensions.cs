using Godot;

namespace Valos.VisualNovel.Extensions;

[Tool]
public static class NodeExtension
{
    public static async void WaitNextFrame(this Node node)
    {
        // await node.ToSignal(node.GetTree(), "process_frame");
    }
    
    public static T NodeInitializer<T>(this Node main, string name) where T : Node, new()
    {
        T node;

        if (main.HasNode(name) == true)
        {
            node = main.GetNode<T>(name);
        }
        else
        {
            node = new T();

            node.AddChildDeferred(node, name);
        }

        return node;
    }
    
    private static void AddChildDeferred(this Node node, Node child, string name)
    {
        child.SetDeferred(Node.PropertyName.Owner, node);

        child.SetDeferred(Node.PropertyName.Name, name);
        
        node.CallDeferred(Node.MethodName.AddChild, child);
    }

    public static void AddChildDeferred(this Node node, Node child, Node owner)
    {
        node.CallDeferred(Node.MethodName.AddChild, child, true);

        child.SetDeferred(Node.PropertyName.Owner, owner);
    }

    public static void AddChildDeferred(this Node node, Node child, Node owner, string name)
    {
        node.CallDeferred(Node.MethodName.AddChild, child);

        child.SetDeferred(Node.PropertyName.Owner, owner);

        child.SetDeferred(Node.PropertyName.Name, name);
    }
}