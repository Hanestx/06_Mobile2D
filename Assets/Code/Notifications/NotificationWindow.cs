using System;
using UnityEngine;
using Unity.Notifications.Android;
using Unity.Notifications.iOS;
using UnityEngine.UI;


namespace Mobile2D
{
    internal class NotificationWindow : MonoBehaviour
    {
        private const string AndroidNotificationID = "android_notification_id";

        [SerializeField] private Button _buttonNotification;

        private void Start()
        {
            _buttonNotification.onClick.AddListener(CreateNotification);
        }

        private void OnDestroy()
        {
            _buttonNotification.onClick.RemoveAllListeners();
        }

        private void CreateNotification()
        {
#if UNITY_ANDROID
            CreateAndroidNotification();
#elif UNITY_IOS
            CreateIOSNotification();
#endif
        }

        private void CreateAndroidNotification()
        {
            var androidChannel = new AndroidNotificationChannel
            {
                Id = AndroidNotificationID,
                Name = "Game Notifier",
                Importance = Importance.Default,
                EnableVibration = true
            };
            
            AndroidNotificationCenter.RegisterNotificationChannel(androidChannel);

            var androidNotification = new AndroidNotification
            {
                Color = Color.black,
                FireTime = DateTime.UtcNow + TimeSpan.FromSeconds(100)
            };

            AndroidNotificationCenter.SendNotification(androidNotification, AndroidNotificationID);
        }

        private void CreateIOSNotification()
        {
            var dataShowNotification = DateTime.UtcNow + TimeSpan.FromSeconds(100);
            var iOSNotification = new iOSNotification
            {
                Identifier = "ios_notification_id",
                Title = "Title notification",
                Body = "Body notification",
                ForegroundPresentationOption = PresentationOption.Sound | PresentationOption.Alert | PresentationOption.Badge,
                Data = dataShowNotification.ToString()
            };

            iOSNotificationCenter.ScheduleNotification(iOSNotification);
        }
    }
}