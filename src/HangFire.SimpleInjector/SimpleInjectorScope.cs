using System;
using SimpleInjector;

namespace Hangfire.SimpleInjector
{
    internal class SimpleInjectorScope : JobActivatorScope
    {
        private readonly Container _container;
        private readonly Scope _scope;

        public SimpleInjectorScope(Container container, Scope scope)
        {
            _container = container;
            _scope = scope;
        }

        public override object Resolve(Type type)
        {
            return _container.GetInstance(type);
        }

        public override void DisposeScope()
        {
            _scope.Dispose();
        }
    }
}