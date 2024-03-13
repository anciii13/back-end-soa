using Explorer.Blog.API.Public;
using Explorer.Blog.Core.Domain;
using Explorer.Blog.Core.Mappers;
using Explorer.Blog.Core.UseCases;
using Explorer.Blog.Infrastructure.Database;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Explorer.Blog.Infrastructure;

public static class BlogStartup
{
    public static IServiceCollection ConfigureBlogModule(this IServiceCollection services)
    {
        // Registers all profiles since it works on the assembly
        services.AddAutoMapper(typeof(BlogProfile).Assembly);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }
    
    private static void SetupCore(IServiceCollection services)
    {
        //services.AddScoped<IBlogPostCommentService, BlogPostCommentService>();
        services.AddScoped<IBlogPostService, BlogPostService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudRepository<BlogPost>), typeof(CrudDatabaseRepository<BlogPost, BlogContext>));

        //services.AddScoped(typeof(ICrudRepository<BlogPostComment>), typeof(CrudDatabaseRepository<BlogPostComment, BlogContext>));

        services.AddDbContext<BlogContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("blog"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "blog")));

    }
}