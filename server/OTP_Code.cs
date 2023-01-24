using System;
using System.Net.Mail;
using System.Net;

namespace server
{
    public class OTP_module
    {
        Random random = new Random();
        static public bool Send_OTP_Code(string randomCode, string email_to)
        {
            /* @ Create new variable to hold the sender email, password of the sender, and the message is the code */
            String from, pass, messageBody;

            /* @ Input the information of Sender */
            from = "group4sendblackmailtou@gmail.com";
            pass = "bbsmmmsnfhealzte";
            messageBody = " your reset code is " + randomCode;

            /* @ Generate new email to send to the receiver */
            MailMessage email = new MailMessage();
            /* @ Input the information of the Receiver and the information for the email components*/
            email.From = new MailAddress(from);
            email.To.Add(email_to);
            email.Body = messageBody;
            email.Subject = "Password Reseting Code";

            /* @ Generate smtp server to send the verify email */
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.EnableSsl = true;
            SmtpServer.Port = 587;
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            /* @ Checking the app password of the google email and the email of the sender */
            SmtpServer.Credentials = new NetworkCredential(from, pass);

            try
            {
                SmtpServer.Send(email);
                //Console.WriteLine("Email Successfully Sent");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        static public bool Checking_OTP_code(string randomCode)
        {
            /* @ Checking the verify code 3 times or 
             * @ Else logout and start from beginning due to the security 
             */
            int count = 0;
            while (count >= 0)
            {
                if (count == 2)
                {
                    count = -1;
                    Console.WriteLine("You input wrong too many times. You will be transfer to login...\n");
                    break;
                }
                Console.WriteLine("Please enter the verify code be sent to your email\n");
                Console.WriteLine("Or enter Exit to Exit, Return to Return\n");
                string verify_code_input = Console.ReadLine();
                if (verify_code_input.CompareTo("Return") == 0)
                {
                    // set the flag to -1 value to escapse while loop
                    // Write Function here
                    count = -1;
                }
                if (verify_code_input.CompareTo("Exit") == 0)
                {
                    // set the flag to -1 value to escapse while loop
                    // Write Function here
                    count = -1;
                }
                if (verify_code_input.CompareTo(randomCode) == 0)
                {
                    Console.WriteLine("Change password failed\n");
                    return true;
                }
                else { int times_input_left = 2 - count; Console.WriteLine("Wrong Verify code, u have only" + times_input_left.ToString()); count++; }
            }
            return false;
        }
    }
}