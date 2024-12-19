using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Web.Mvc;
using MovieApplicationMVC.Models;
using Newtonsoft.Json;

namespace MovieApplicationMVC.Controllers
{
    public class TicketController : Controller
    {
        private readonly HttpClient _httpClient;

        public TicketController()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:49681/api/tickets/") };
        }

        // Create ticket after payment
        // Create ticket after payment
        public ActionResult CreateAfterPayment(string bookingId, string showTimeId, string seatNumber)
        {
            try
            {
                Console.WriteLine($"BookingId: {bookingId}, ShowTimeId: {showTimeId}, SeatNumber: {seatNumber}");

                // Create ticket object without TicketId
                var ticket = new Ticket
                {
                    BookingId = bookingId,
                    ShowTimeId = showTimeId,
                    SeatNumber = seatNumber // Ensure seatNumber matches expected format
                };

                // Call the backend API
                var response = _httpClient.PostAsJsonAsync("CreateAfterPayment", ticket).Result;

                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error creating ticket.");

                return RedirectToAction("Tickets", new { bookingId });
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Ticket", "CreateAfterPayment"));
            }
        }


        // Display tickets by booking
        public ActionResult Tickets(string bookingId)
        {
            try
            {
                var response = _httpClient.GetAsync($"GetByBooking/{bookingId}").Result;

                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error fetching tickets.");

                var tickets = JsonConvert.DeserializeObject<List<Ticket>>(response.Content.ReadAsStringAsync().Result);

                return View(tickets);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Ticket", "Tickets"));
            }
        }

    
        
    }
}
