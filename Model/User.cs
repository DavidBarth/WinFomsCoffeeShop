using CoffeeShop.Enum;

namespace CoffeeShop.Model
{
    class User
    {
        private UserRole _userRole = UserRole.Simple;

        public UserRole Role
        {
            get
            {
                return _userRole;
            }

            internal set
            {
                _userRole = value;
            }
        }
    }
}
