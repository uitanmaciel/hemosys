using HemoSys.SchedulingService.Application.Appointments.Commands.Models;
using HemoSys.SchedulingService.Application.Appointments.Enums;
using HemoSys.SchedulingService.Web.Appointments.Models;

namespace HemoSys.SchedulingService.Web.Appointments.Requests;

public sealed class AppointmentCreateRequest : 
    AppointmentModel, 
    IRequestToCommand<AppointmentCreateRequest, AppointmentCreateCommand>
{
    public AppointmentCreateCommand ToCommand(AppointmentCreateRequest? request)
    {
        if(HasNotifications)
            return new AppointmentCreateCommand();

        return new AppointmentCreateCommand
        {
            Id = Guid.Empty,
            Donor = Donor!.ToCommand(Donor),
            Location = Location!.ToCommand(Location),
            ScheduledDate = ScheduledDate,
            StatusTypes = AppointmentStatusTypes.New,
            LastAppointment = request!.LastAppointmentDate,
            Notes = request.Notes
        };
    }

    public IList<AppointmentCreateCommand> ToCommand(IList<AppointmentCreateRequest> requests)
    {
        return requests.Select(ToCommand).ToList();
    }
}