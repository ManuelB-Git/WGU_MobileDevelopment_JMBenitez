
using Plugin.LocalNotification;


namespace WGU_MobileDevelopment_JMBenitez.Services
{
    public static class NotificationService
    {
        public static async void ScheduleNotification()
        {

            if (await LocalNotificationCenter.Current.AreNotificationsEnabled() == false)
            {
                await LocalNotificationCenter.Current.RequestNotificationPermission();
            }
            var notification = new NotificationRequest
            {
                NotificationId = 100,
                Title = "Test Notification",
                Description = "This is a test notification",
                ReturningData = "Dummy data",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(10)
                }
            };
            await LocalNotificationCenter.Current.Show(notification);
        }
    }
}
