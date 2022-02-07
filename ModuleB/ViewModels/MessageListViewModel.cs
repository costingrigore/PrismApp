using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Mvvm;
using PrismApp.Core.Events;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        private ObservableCollection<string> _messages = new ObservableCollection<string>();
        public ObservableCollection<string> Messages { 
            get { return _messages; } 
            set { SetProperty(ref _messages, value); } 
        }

        private MessageSentEvent _event;

        private bool _isSubscribed = true;

        public bool IsSubscribed
        {
            get { return _isSubscribed; }
            set
            {
                SetProperty(ref _isSubscribed, value);
                HandleSubscribed(_isSubscribed);
            }
        }
        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            _event = eventAggregator.GetEvent<MessageSentEvent>();//.Subscribe(OnMessageReceived,
                                                         // ThreadOption.PublisherThread, false,
                                                         // message => message.Contains("Brian"));
            HandleSubscribed(true);
        }

        private void OnMessageReceived(string message)
        {
            Messages.Add(message);
        }


        private void HandleSubscribed(bool isSubscribed)
        {
            if (isSubscribed)
                _event.Subscribe(OnMessageReceived);
            else
                _event.Unsubscribe(OnMessageReceived);
        }

    }
}
