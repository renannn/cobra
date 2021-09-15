using Cobra.Infrastructure.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Cobra.Infrastructure.Setup
{
    public static class RazorPagesSetup
    {
        public static IServiceCollection AddCustomRazorPages(this IServiceCollection services)
        {
            services.AddRazorPages(options =>
            {
                // Administração
                options.Conventions.AddAreaFolderApplicationModelConvention("Administracao", "/DatabaseConnections", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("adm-database-connections"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("Administracao", "/Regras", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("adm-regras"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("Administracao", "/Usuario", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("adm-usuario"));
                });

                // CRM
                options.Conventions.AddAreaFolderApplicationModelConvention("CRM", "/Clientes", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("crm-clientes"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("CRM", "/Importacao", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("crm-importacao"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("CRM", "/Marca", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("crm-marca"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("CRM", "/Modelo", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("crm-modelo"));
                });

                //Dominios
                options.Conventions.AddAreaFolderApplicationModelConvention("Dominios", "/Banco", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("dominio-banco"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("Dominios", "/Categoria", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("dominio-categoria"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("Dominios", "/Database", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("dominio-database"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("Dominios", "/Estado", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("dominio-estados"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("Dominios", "/Extensao", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("dominio-extensao"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("Dominios", "/Forma Pagamento", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("dominio-forma-pagamento"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("Dominios", "/Tipo de Coluna", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("dominio-tipo-coluna"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("Dominios", "/Tipo de Email", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("dominio-tipo-email"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("Dominios", "/Tipo de Endereco", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("dominio-tipo-endereco"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("Dominios", "/Tipo de Logradouro", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("dominio-tipo-logradouro"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("Dominios", "/Tipo de Pessoa", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("dominio-tipo-pessoa"));
                });

                options.Conventions.AddAreaFolderApplicationModelConvention("Dominios", "/Tipo de Telefone", cOption =>
                {
                    cOption.Filters.Add(new RazorPageFeatureGate("dominio-tipo-telefone"));
                });
            });
            return services;
        }
    }
}
