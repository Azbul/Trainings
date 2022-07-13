using System;
using System.Linq;

namespace Incapsulation.EnterpriseTask
{
    public class Enterprise
    {
        public Enterprise(Guid guid, string name, string inn, DateTime establDate)
        {
            this.Guid = guid;
            Name = name;
            Inn = inn;
            EstablishDate = establDate;
        }

        public Guid Guid { get; }

        public string Name { get; set; }

        private const int _innLength = 10;
        private string _inn;

        public string Inn
        {
            get { return _inn; }
            set
            {
                if (value.Length != _innLength || !value.All(z => char.IsDigit(z)))
                    throw new ArgumentException();
                _inn = value;
            }
        }

        public DateTime EstablishDate { get; set; }

        public TimeSpan ActiveTimeSpan => DateTime.Now - EstablishDate;

        public double GetTotalTransactionsAmount()
        {
            DataBase.OpenConnection();
            var amount = 0.0;
            foreach (Transaction t in DataBase.Transactions().Where(z => z.EnterpriseGuid == Guid))
                amount += t.Amount;
            return amount;
        }
    }
}
