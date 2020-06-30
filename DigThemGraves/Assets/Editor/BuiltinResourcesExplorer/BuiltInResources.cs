using System.Linq;
using UnityEngine;

public static class BuiltInResources
{
    public static Texture FindByName(string name)
    {
        return Resources.FindObjectsOfTypeAll<Texture>()
            .Where(t => t.name == name)
            .First();
    }
}
