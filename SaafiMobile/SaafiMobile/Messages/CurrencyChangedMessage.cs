using MvvmCross.Plugins.Messenger;
using SaafiMobile.Core.Model;

namespace SaafiMobile.Core.Messages
{
    public class CurrencyChangedMessage : MvxMessage
    {
        public CurrencyChangedMessage(object sender) : base(sender)
        {
        }

        public Currency NewCurrency { get; set; }
    }
}