//using System;

//using MerchApi.Domain.Exceptions;
//using MerchApi.Domain.SharedKernel.Models;

//namespace MerchApi.Domain.AggregationModels.MerchAggregate
//{
//    /// <summary>
//    /// Мерч, который выдавался сотруднику
//    /// </summary>
//    public class MerchIssue : Entity
//    {
       
//        public MerchIssue(int employeeId, MerchType merchType, DateTime? issueDate)
//        {
//            EmployeeId = employeeId;
//            MerchType = merchType;
//            IssueDate = issueDate;
//            PrepareMerchPack();
//        }

//        private void PrepareMerchPack()
//        {
//            MerchPack = new MerchPack();

//            if (MerchType == MerchType.WelcomePack)
//            {
//                // какая-то логика заполнения мерча
//                MerchPack.Value.Add(new Item(0, "Блокнот"));
//            }
//            else
//            {
//                // какая-то другая логика заполнения мерча
//                MerchPack.Value.Add(new Item(MerchType.Id, MerchType.Name));
//            }
//        }

//        public void UpdateIssueDate(DateTime date)
//        {
//            if (date < DateTime.UtcNow)
//            {
//                throw new NegativeValueException("Дата должна быть больше текущей");
//            }
//            else
//            {
//                IssueDate = date;
//            }
//        }
//    }
//}
