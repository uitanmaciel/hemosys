namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models.Abstracts;

public class DonorCommand
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? BloodType { get; set; }
    public double Weight { get; set; }
    public string Gender { get; set; } = null!;
    public DateTime BirthDate { get; set; }

    public Donor ToDomain(DonorCommand? command)
    {
        if (command is null)
            return new Donor();

        return new Donor(
            command.Id,
            command.Name,
            command.BloodType,
            command.Weight,
            command.Gender,
            command.BirthDate);
    }
    
    public IList<Donor> ToDomain(IList<DonorCommand> commands)
    {
        return commands.Select(ToDomain).ToList();
    }
}