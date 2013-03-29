namespace Chicago
{
    internal sealed class Job
    {
        public Job(string login, string password)
        {
            Login = login;
            Password = password;
        }

        /// <summary>
        ///     Login info
        /// </summary>
        public string Login { get; private set; }

        /// <summary>
        ///     Login info
        /// </summary>
        public string Password { get; private set; }

        public bool IsSuccessful { get; set; }
    }
}