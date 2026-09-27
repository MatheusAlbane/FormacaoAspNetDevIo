using AutoMapper;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        // Instalado Install-Package AutoMapper no projeto MVC
        // No global.asax.cs, no método Application_Start() adicione a linha AutoMapperConfig.RegisterMappings();
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DomainToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }

    }
}