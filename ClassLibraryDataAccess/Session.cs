using ClassLibraryModel;
using System;

namespace ClassLibraryDataAccess
{
    public static class Session
    {
        private static bool _loggedIn;
        private static ModelUser _currentUser;

        public static bool LoggedIn
        {
            get => _loggedIn;
            set
            {
                if (_loggedIn != value)
                {
                    _loggedIn = value;
                    OnSessionStateChanged?.Invoke();
                }
            }
        }

        public static ModelUser CurrentUser
        {
            get => _currentUser;
            set
            {
                if (_currentUser != value)
                {
                    _currentUser = value;
                    OnSessionStateChanged?.Invoke();
                }
            }
        }

        public static event Action OnSessionStateChanged;
    }
}
