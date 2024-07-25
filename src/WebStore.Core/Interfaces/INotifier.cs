using WebStore.Domain.Notifications;

namespace WebStore.Domain.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
