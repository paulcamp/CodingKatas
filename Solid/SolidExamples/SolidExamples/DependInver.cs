using System.Collections.Generic;

namespace SolidExamples
{
    class DependInver
    {
        //high level modules should not rely on low level modules, both should depend on abstrations
        //abstractions should not depend on details
        //code credit https://exceptionnotfound.net/simply-solid-the-dependency-inversion-principle/
        
        public class Email
        {
            public string ToAddress { get; set; }
            public string Subject { get; set; }
            public string Content { get; set; }
            public void SendEmail()
            {
                //Send email
            }
        }

        public class Sms
        {
            public string PhoneNumber { get; set; }
            public string Message { get; set; }
            public void SendSms()
            {
                //Send sms
            }
        }

        public class Notification
        {
            readonly Email _email;
            readonly Sms _sms;
            public Notification()
            {
                _email = new Email();
                _sms = new Sms();
            }

            public void Send()
            {
                _email.SendEmail();
                _sms.SendSms();
            }
        }

        //In the above example, we are "new" ing up concrete implementations of the Email and Sms class inside our notification class,
        //which means the notification has a dependency on those concrete lower level classes.
        //a better arrangement is this:

        public interface IMessage
        {
            void SendMessage();
        }

        public class EmailInver : IMessage
        {
            public string ToAddress { get; set; }
            public string Subject { get; set; }
            public string Content { get; set; }
            public void SendMessage()
            {
                //Send email
            }
        }

        public class SmsInver : IMessage
        {
            public string PhoneNumber { get; set; }
            public string Message { get; set; }
            public void SendMessage()
            {
                //Send sms
            }
        }

        public class NotificationInver
        {
            private readonly ICollection<IMessage> _messages;

            //inversion of control, we pass in our interface types (constructed elsewhere, maybe in DI container)
            public NotificationInver(ICollection<IMessage> messages)
            {
                this._messages = messages;
            }
            public void Send()
            {
                foreach (var message in _messages)
                {
                    message.SendMessage();
                }
            }
        }
    }
}
