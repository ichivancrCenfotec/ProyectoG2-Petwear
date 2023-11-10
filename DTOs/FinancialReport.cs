using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class FinancialReport : BaseDTO
    {
        public int IdFinancialReport {  get; set; }
        public DateTime Date {  get; set; }
        public float Total {  get; set; }
        public float TotalCost {  get; set; }
        public float TotalProfit {  get; set; }
        public float TotalTaxes {  get; set; }
        public float TotalExpenses {  get; set; }
        public float TotalIncome {  get; set; }
        public float TotalServices {  get; set; }
        public float TotalPackages {  get; set; }
        public float TotalBookings {  get; set; }
        public float TotalOther {  get; set; }
    }
}
