using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using DDCities.Data;

namespace DDCities.Business
{
    public class NotificationService
    {
        public void SendMail()
        {
            var email = new MailMessage("noreply@ddcities.com", "srichaitanya.kandikonda@gmail.com");
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("wjin1210@gmail.com", "Eds@hp666666")
            };

            // set up the Gmail server

            // draft the email
            var fromAddress = new MailAddress("wjin1210@gmail.com");
            email.CC.Add(fromAddress);
            email.Subject = "Free ride today.";
            email.Body =
                "Hi Sri, I know you are suffering from commuting 3 hours every work day, let's change it. Would you like free ride today.";
            smtp.Send(email);
        }

        public void NotifyMatchedDriverSchedule(string receiverEmail, IEnumerable<DriverSchedule> schedules)
        {
            var email = GetMailMessage();
            email.To.Add(new MailAddress(receiverEmail));
            email.Subject = "Found Driver Schedules";
            email.Body = BuildDriverScheduleTable(schedules);
            SendMail(email);
        }

        public void NotifyMatchedRideRequest(string receiverEmail, IEnumerable<RideRequest> rideRequests)
        {
            var email = GetMailMessage();
            email.To.Add(new MailAddress(receiverEmail));
            email.Subject = "Found Ride Requests";
            email.Body = BuildRideRequestTable(rideRequests);
            SendMail(email);
        }

        private string BuildDriverScheduleTable(IEnumerable<DriverSchedule> schedules)
        {
            var contentBuilder = new StringBuilder();
            contentBuilder.AppendLine("<h4>The following driver's schedule meet your requirements:</h4><br>");
            contentBuilder.Append("<table>");
            foreach (var schedule in schedules)
            {
                contentBuilder.Append("<tr>");
                contentBuilder.AppendFormat("<td>{0} {1}</td><td>{2} {3} {4}</td><td>{5}</td><td>{6}</td>",
                    schedule.User.FirstName, schedule.User.LastName, schedule.Car.Model, schedule.Car.Type,
                    schedule.Car.Year, schedule.LeaveAfter,
                    schedule.LeaveBefore);
                contentBuilder.Append("</tr>");
            }
            contentBuilder.Append("</table>");
            return contentBuilder.ToString();
        }

        private string BuildRideRequestTable(IEnumerable<RideRequest> rideRequests)
        {
            var contentBuilder = new StringBuilder();
            contentBuilder.AppendLine("<h4>The following riders' requests have been found:</h4><br>");
            contentBuilder.Append("<table>");
            foreach (var ride in rideRequests)
            {
                contentBuilder.Append("<tr>");
                contentBuilder.AppendFormat("<td>{0} {1}</td><td>{2} {3} {4}</td><td>{5}</td><td>{6}</td>",
                    ride.User.FirstName, ride.User.LastName, ride.LeaveAfter,
                    ride.LeaveBefore,
                    ride.Address.ToDisplayAddress(), ride.Address1.ToDisplayAddress());
                contentBuilder.Append("</tr>");
            }
            contentBuilder.Append("</table>");
            return contentBuilder.ToString();
        }

        private MailMessage GetMailMessage()
        {
            var email = new MailMessage();
            // set up the Gmail server
            var bccAddress = new MailAddress("wjin1210@gmail.com");
            var fromAddress = new MailAddress("noreply@ddcities.com");
            email.From = fromAddress;
            email.Bcc.Add(bccAddress);
            return email;
        }

        private void SendMail(MailMessage mail)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("wjin1210@gmail.com", "Eds@hp666666")
            };
            smtp.Send(mail);
        }
    }
}