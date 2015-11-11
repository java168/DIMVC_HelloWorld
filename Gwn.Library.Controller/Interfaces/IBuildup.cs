using System;
using Microsoft.Practices.Unity;

namespace Gwn.Library.Controller.Interfaces
{
    public interface IBuildUp : IDisposable
    {
        void Initialize();
        void BuildUp(IUnityContainer container);
        void RegisterTypes(IUnityContainer container);
    }
}
