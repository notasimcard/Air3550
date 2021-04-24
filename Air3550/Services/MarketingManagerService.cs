﻿using Air3550.Data;
using Air3550.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air3550.Services
{
    public class MarketingManagerService
    {

        /// <summary>
        /// Update which plane to use. Only Marketing manager can do it.
        /// </summary>
        /// <param name="employee">employee making change</param>
        /// <param name="model">plane model to use</param>
        public static void UpdateFlightDate(Employee employee, int flightId, int planeModel)
        {
            if (employee.Type != EmployeeType.MARKETING_MANAGER)
            {
                return;
            }
            using var db = new AppDBContext();
            var flight = db.Flights.Find(flightId);
            if (flight != null && db.Planes.Find(planeModel) != null)
            {
                flight.PlaneModel = planeModel;
                db.Flights.Update(flight);
                db.SaveChanges();
            }
        }
    }
}
