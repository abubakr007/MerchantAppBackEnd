using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Framework.AssemblyHelper
{
    public class AssemblyHelper
    {
        private static readonly List<Assembly> loadedAssemblies;
        private readonly string assemblyHeader;


        static AssemblyHelper()
        {
            loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic).ToList();
        }


        public AssemblyHelper(string nameSpace)
        {
            assemblyHeader = nameSpace;

            var loadedPaths = loadedAssemblies.Where(a => a.FullName.Contains(assemblyHeader))
                .Select(a => a.Location)
                .ToList();

            var referencedPaths = Directory
                .GetFiles(AppDomain.CurrentDomain.BaseDirectory, assemblyHeader + "*.dll", SearchOption.AllDirectories)
                .ToArray();

            var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase))
                .ToList();

            toLoad.ForEach(path =>
                loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));
        }


        private IList<Assembly> GetAllAssemblies()
        {
            var resault = loadedAssemblies.Where(a => a.FullName.Contains(assemblyHeader)).ToList();

            return resault;
        }


        public IList<Assembly> GetAssemblies(Type HasType)
        {
            var BaseClassName = HasType.Name;

            var resault = GetAllAssemblies();

            return GetAllAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.BaseType != null && a.BaseType.Name == BaseClassName)
                .Select(a => a.Assembly)
                .ToList();
        }


        public IList<Type> GetTypes(Type BaseType)
        {
            var BaseClassName = BaseType.Name;

            return GetAllAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.BaseType != null && a.BaseType.Name == BaseClassName && a.IsClass && !a.IsAbstract)
                .ToList();
        }


        public IList<Type> GetClassByInterface(Type baseInterFace)
        {
            var baseClassName = baseInterFace.Name;

            var result = GetAllAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.GetInterfaces().Any(b => b.Name == baseClassName) && a.IsClass && !a.IsAbstract)
                .ToList();

            return result;
        }


        public IList<object> GetInstanceByInterface(Type baseInterFace)
        {
            var baseClassName = baseInterFace.Name;

            return GetAllAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.GetInterfaces().Any(b => b.Name == baseClassName))
                .Distinct()
                .Select(Activator.CreateInstance)
                .ToList();
        }
    }
}
