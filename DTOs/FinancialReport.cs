using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class FinancialReport
    {
        private int idFinancialReport {  get; set; }
        private DateTime date {  get; set; }
        private float total {  get; set; }
        private float totalCost {  get; set; }
        private float totalProfit {  get; set; }
        private float totalTaxes {  get; set; }
        private float totalExpenses {  get; set; }
        private float totalIncome {  get; set; }
        private float totalServices {  get; set; }
        private float totalPackages {  get; set; }
        private float totalBookings {  get; set; }
        private float totalOther {  get; set; }
    }
}
