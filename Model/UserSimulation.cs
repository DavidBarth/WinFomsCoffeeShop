namespace CoffeeShop.Model
{
    class UserSimulation
    {
        private User _user { get; set; }
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
}
