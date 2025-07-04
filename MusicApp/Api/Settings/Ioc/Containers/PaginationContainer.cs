using MusicApp.Domain.Entities;
using MusicApp.Domain.EntitiesValidation;
using MusicApp.Domain.Handler.Validation.Interface;
using MusicApp.Infra.Interfaces.Pagination;
using MusicApp.Infra.Pagination;

namespace MusicApp.Api.Settings.Ioc.Containers;

public static class PaginationContainer
{
    public static IServiceCollection AddPaginationContainer(this IServiceCollection services) =>
        services
            .AddScoped<IPaginationQueryService<Album>, PaginationQueryService<Album>>()
            .AddScoped<IPaginationQueryService<Artist>, PaginationQueryService<Artist>>()
            .AddScoped<IPaginationQueryService<ArtistFollow>, PaginationQueryService<ArtistFollow>>()
            .AddScoped<IPaginationQueryService<Playlist>, PaginationQueryService<Playlist>>()
            .AddScoped<IPaginationQueryService<PlaylistFollow>, PaginationQueryService<PlaylistFollow>>()
            .AddScoped<IPaginationQueryService<User>, PaginationQueryService<User>>()
            .AddScoped<IPaginationQueryService<Audio>, PaginationQueryService<Audio>>()
            .AddScoped<IPaginationQueryService<Image>, PaginationQueryService<Image>>()
            .AddScoped<IPaginationQueryService<Music>, PaginationQueryService<Music>>()
            .AddScoped<IPaginationQueryService<Like>, PaginationQueryService<Like>>()
            .AddScoped<IPaginationQueryService<PlaylistMusic>, PaginationQueryService<PlaylistMusic>>()
            ;
}