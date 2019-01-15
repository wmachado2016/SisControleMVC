

using SimpleInjector;
using WM.SisControleMvc.Application.Interfaces;
using WM.SisControleMvc.Application.Services;
using WM.SisControleMvc.Domain.Interfaces;
using WM.SisControleMvc.Domain.Services;
using WM.SisControleMvc.Infra.Data.Repository;

namespace WM.SisControleMvc.Infra.CrossCutting.IoC
{
    public class SimpleInjectBootstraper
    {
        public static void Register(Container container)
        {
            //App
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);

            //Domain
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);

            //Data
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
        }
    }
}
