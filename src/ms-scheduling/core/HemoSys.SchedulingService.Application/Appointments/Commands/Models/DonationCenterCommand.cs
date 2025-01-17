using HemoSys.SchedulingService.Domain.Appointments.ValueObjects;

namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models;

public record DonationCenterCommand(Guid Id, string Name) : ICommandToDomain<DonationCenterCommand, DonationCenter>
{
    public DonationCenterCommand() : this(Guid.Empty, string.Empty) { }
    
    public DonationCenter ToDomain(DonationCenterCommand? command)
        => command is null
        ? new DonationCenter()
        : new DonationCenter(command.Id, command.Name);

    public IList<DonationCenter> ToDomain(IList<DonationCenterCommand> commands)
        => commands.Select(ToDomain).ToList();
}