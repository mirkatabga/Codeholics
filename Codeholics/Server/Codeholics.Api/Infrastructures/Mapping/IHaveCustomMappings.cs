namespace Codeholics.Api.Infrastructures.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration config);
    }
}