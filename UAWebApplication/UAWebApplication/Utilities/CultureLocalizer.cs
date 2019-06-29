﻿using Microsoft.Extensions.Localization;
using UAWebApplication.Resources;
using System.Reflection;

namespace UAWebApplication.Utilities
{
    public class CultureLocalizer
    {
        private readonly IStringLocalizer _localizer;
        public CultureLocalizer(IStringLocalizerFactory factory)
        {
            var type = typeof(ViewResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("ViewResource", assemblyName.Name);
        }

        // if we have formatted string we can provide arguments         
        // e.g.: @Localizer.Text("Hello {0}", User.Name)
        public LocalizedString Text(string key, params string[] arguments)
        {
            return arguments == null
                ? _localizer[key]
                : _localizer[key, arguments];
        }
    }
}
