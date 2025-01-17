namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models;

public record DonorCommand(
    Guid Id,
    string Name,
    string? BloodType,
    double Weight,
    string Gender,
    DateTime BirthDate) : ICommandToDomain<DonorCommand, Donor>
{
    public DonorCommand() : this(Guid.Empty, string.Empty, string.Empty, 0, string.Empty, DateTime.MinValue) { }
    
    public Donor ToDomain(DonorCommand? command)
        => command is null
        ? new Donor()
        : new Donor(
            command.Id, 
            command.Name, 
            command.BloodType!, 
            command.Weight, 
            command.Gender, 
            command.BirthDate);

    public IList<Donor> ToDomain(IList<DonorCommand> commands)
        => commands.Select(ToDomain).ToList();
}