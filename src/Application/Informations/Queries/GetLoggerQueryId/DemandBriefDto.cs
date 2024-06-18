using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Informations.Queries.GetLoggerQueryId;

public class DemandBriefDto
{
    public int demandId { get; set; }

    public string? Name { get; set; }
    public DateTime Date { get; set; }
    public int Unit { get; set; }
    public double Amount { get; set; }
    public double Balance { get; set; }
    public int SendId { get; set; }

    public string? Sms { get; set; }
    public string? Email { get; set; }
    public string? PushNotifacation { get; set; }
    public bool Done { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Demand, DemandBriefDto>();
            CreateMap<Information, DemandBriefDto>();
        }
    }
}
