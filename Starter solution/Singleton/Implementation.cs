namespace SingletonProject
{
    /// <summary>
    /// Singleton
    /// </summary>
  public class Project
    {
        private static Project? _instance;

        /// <summary>
        /// Instance
        /// </summary>
        public static Project Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Project();
                }
                return _instance;
            }
        }

        protected Project()
        {

        }
 

        /// <summary>
        /// SingletonOperation
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            Console.WriteLine($"Message to log: {message}");
        }

    }
}
