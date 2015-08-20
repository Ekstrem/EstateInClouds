namespace BusinessLogic.DomainLayer.BusinessProcess
{
    public class Landlord : Human, IBusinessProceessRole
    {
        public LandlordLegalOperationStatus TaxesPayment { get; set; }

        public int ProcentCoustForService
        {
            get { return (int)TaxesPayment; }
            set
            {
                try
                {
                    TaxesPayment = (LandlordLegalOperationStatus) value;
                }
                catch
                {
                    // ignored
                }
            }
        }

        public int MoneyCostForService { get; set; }
    }
}