using GutoriCorp.Data.Models;
using GutoriCorp.Models.BusinessViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GutoriCorp.Common.Enums;

namespace GutoriCorp.Data.Operations
{
    public class TicketData
    {
        private readonly ApplicationDbContext _context;

        public TicketData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(TicketViewModel ticket)
        {
            _context.Add(GetEntity(ticket));
            await _context.SaveChangesAsync();
        }

        public TicketViewModel Get(long id)
        {
            var paymentsQry = QueryAllData();
            return paymentsQry.FirstOrDefault(p => p.id == id);
        }

        private IQueryable<TicketViewModel> QueryAllData()
        {
            var paymentsQry = from tic in _context.Ticket
                              join veh in _context.Vehicle on tic.vehicle_id equals veh.id
                              join stat in _context.GeneralCatalogValues on tic.status_id equals stat.id
                              select new TicketViewModel
                              {
                                  id = tic.id,
                                  vehicle_id = tic.vehicle_id,
                                  status_id = tic.status_id,
                                  status = stat.title,
                                  ticket_date = tic.ticket_date,
                                  tlc_plate = tic.tlc_plate,
                                  vin_code = tic.vin_code,
                                  description = tic.description,
                                  occurrence_place = tic.occurrence_place,
                                  fine_amount = tic.fine_amount,
                                  ticket = tic.ticket,
                                  created_on = tic.created_on,
                                  created_by = tic.created_by,
                                  modified_on = tic.modified_on,
                                  modified_by = tic.modified_by
                              };
            return paymentsQry;
        }

        public TicketViewModel InitTicketForVehicle(int vehicleId)
        {
            var vehOp = new VehicleData(_context);
            var vehicle = vehOp.Get(vehicleId);

            var ticket = new TicketViewModel
            {
                vehicle_id = vehicle.id,
                tlc_plate = vehicle.tlc_plate,
                vin_code = vehicle.vin_code,
                vehicle = vehicle.ToString()
            };

            return ticket;
        }

        private static Ticket GetEntity(TicketViewModel ticketVm)
        {
            var ticket = new Ticket
            {
                vehicle_id = ticketVm.vehicle_id,
                tlc_plate = ticketVm.tlc_plate,
                vin_code = ticketVm.vin_code,
                ticket_num = ticketVm.ticket_num,
                description = ticketVm.description,
                occurrence_place = ticketVm.occurrence_place,
                ticket_date = ticketVm.ticket_date,
                fine_amount = ticketVm.fine_amount,
                ticket = ticketVm.ticket,
                created_on = DateTime.Now,
                created_by = ticketVm.created_by,
                modified_on = DateTime.Now,
                modified_by = ticketVm.modified_by,
                status_id = (short)GeneralStatus.Active
            };

            return ticket;
        }
    }
}
