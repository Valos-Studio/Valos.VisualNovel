using Godot;

namespace Valos.VisualNovel;

public static class Validator
{
    public static bool IsValid(GodotObject node)
    {
        if (node != null && GodotObject.IsInstanceValid(node) && !node.IsQueuedForDeletion())
        {
            return true;
        }
        
        return false;
    }
}