using AutoMapper;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Multitenancy.Api.Contracts;

namespace Tiveriad.Multitenancy.Api.Mappings;
public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {
        CreateMap<Organization, OrganizationReaderModel>();
        CreateMap<OrganizationWriterModel, Organization>();
    }
}