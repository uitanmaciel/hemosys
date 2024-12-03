namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models.Abstracts;

public class LocationCommand
{
    public string Name { get; set; } = null!;
    public AddressCommand Address { get; set; } = null!;
    
    public LocationCommand() { }
    
    public Location ToDomain(LocationCommand? command)
    {
        if (command is null)
            return new Location();

        return new Location(
            command.Name,
            AddressCommand.ToDomain(command.Address));
    }
    
    public IList<Location> ToDomain(IList<LocationCommand> commands)
    {
        return commands.Select(ToDomain).ToList();
    }
}