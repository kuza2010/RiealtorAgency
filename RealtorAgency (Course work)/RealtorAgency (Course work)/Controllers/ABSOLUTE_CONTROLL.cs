using RealtorAgency__Course_work_.Controllers;
using System.Configuration;


namespace RealtorAgency__Course_work_
{
    public class ABSOLUTE_CONTROLL
    {
        //Поля 
        protected static ManagerRiealtorAgency mngRiealtorAgency;


        //Свойства
        public ManagerRiealtorAgency GetManager
        {
            get { return mngRiealtorAgency; }
        }


        //Методы
        public ABSOLUTE_CONTROLL()
        {
            mngRiealtorAgency = ManagerRiealtorAgency.getInstance();
        }

    }
}
