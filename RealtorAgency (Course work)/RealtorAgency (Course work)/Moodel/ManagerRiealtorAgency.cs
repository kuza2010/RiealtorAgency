using System.Configuration;

namespace RealtorAgency__Course_work_
{
    public class ManagerRiealtorAgency
    {
        //Поля 
        private RiealtorAgencyDB riealtorAgency = null;
        private static ManagerRiealtorAgency manager = null;

        //Свойства
        public RiealtorAgencyDB Agency
        {
            get
            {
                return riealtorAgency;
            }
        }


        //МЕтоды
        private ManagerRiealtorAgency ()
        {
            riealtorAgency = new RiealtorAgencyDB(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public static ManagerRiealtorAgency getInstance ()
        {
            if (manager == null)
                manager = new ManagerRiealtorAgency();
            return manager;
        }

    }

}
