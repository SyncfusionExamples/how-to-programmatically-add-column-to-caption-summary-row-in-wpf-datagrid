using Syncfusion.UI.Xaml.Utility;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace SfDataGridDemo
{
    public class SalesInfoViewModel : NotificationObject
    {       
        ObservableCollection<SalesByYear> yearlySalesDetails;
        public ObservableCollection<SalesByYear> YearlySalesDetails
        {
            get { return yearlySalesDetails; }
            set { yearlySalesDetails = value; }
        }
        public SalesInfoViewModel()
        {
            yearlySalesDetails = new ObservableCollection<SalesByYear>();
            this.GenerateSalesDetails();
        }
        private void GenerateSalesDetails()
        {
            Random q1 = new Random();
            Random q2 = new Random();
            Random q3 = new Random();
            Random q4 = new Random();

            Random y = new Random(2001);          
            for (int i= 0;i< CustomerID.Count();i++)
            {
                var salesDetails = new SalesByYear() { Name = CustomerID[i], QS1 = q1.Next(1000, 2000), QS2 = q2.Next(2000, 3000), QS3 = q3.Next(3000, 4000), QS4 = q4.Next(4000, 5000) };
                salesDetails.Total = salesDetails.QS1 + salesDetails.QS2 + salesDetails.QS3 + salesDetails.QS4;
                salesDetails.Year = y.Next(2001,2019);
                yearlySalesDetails.Add(salesDetails);
            }
        }

        string[] CustomerID = new string[]
        {
            "ALFKI",
            "FRANS",
            "MEREP",
            "FOLKO",
            "SIMOB",
            "WARTH",
            "VAFFE",
            "FURIB",
            "SEVES",
            "LINOD",
            "RISCU",
            "PICCO",
            "BLONP",
            "WELLI",
            "FOLIG"
        };

    }
}
