using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace DigThemGraves
{
    public class CopyObjectFactory<D> : IObjectFactory<D> where D : new()
    {
        private static IEnumerable<(FieldInfo SourceField, FieldInfo DestinationField)> fieldMapping;
        private static BindingFlags bindingFlags = BindingFlags.NonPublic |
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.Static;
        private object target;

        public CopyObjectFactory(object target)
        {
            this.target = target;
            if (fieldMapping is null)
            {
                fieldMapping = typeof(D).GetFields(bindingFlags)
                    .Where(f => f.IsDefined(typeof(FillFromFileAttribute), false))
                    .Select(f => (SourceField: target.GetType().GetField(f.GetCustomAttribute<FillFromFileAttribute>(false).SourceFieldName, bindingFlags),
                                  DestinationField: f));
#if UNITY_EDITOR
                if (fieldMapping.Count() == 0)
                {
                    Debug.LogWarning($"Couldn't find any matching fields in given object of class {target.GetType()}. " +
                        $"Check if proper names are being used, in the constructor of {typeof(FillFromFileAttribute)}, at definition of {typeof(D)}.");
                }
#endif
            }
        }

        public D Create()
        {
            D grave = new D();

            foreach (var (SourceField, DestinationField) in fieldMapping)
            {
                var value = SourceField.GetValue(target);
                DestinationField.SetValue(grave, value);
            }
            return grave;
        }
    }
}
