using Mapster;

namespace Application.Mappings
{
    /// <summary>
    /// Configuração global do Mapster.
    /// Registra todas as configurações de mapeamento do projeto.
    /// </summary>
    public class MapsterConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Configurações globais
            config.Default.PreserveReference(true); // Evita loops infinitos em relacionamentos
            config.Default.IgnoreNullValues(false); // Mapeia valores null
            
            // Registra configurações específicas
            new UserMappingConfig().Register(config);
			new PharmacyMappingConfig().Register(config);
        }
    }
}
