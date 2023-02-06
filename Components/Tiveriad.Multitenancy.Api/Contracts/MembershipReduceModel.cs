using System;
using System.ComponentModel.DataAnnotations;

namespace Tiveriad.Multitenancy.Api.Contracts;
public class MembershipReduceModel
{
    [MaxLength(24)]
    public string Id { get; set; }
}