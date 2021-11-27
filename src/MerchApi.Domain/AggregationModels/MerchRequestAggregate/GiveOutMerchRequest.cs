using System;

using MerchApi.Domain.AggregationModels.MerchPackAggregate;
using MerchApi.Domain.Events;
using MerchApi.Domain.Exceptions;
using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.MerchRequestAggregate
{
    /// <summary>
    /// Заявка на выдачу мерча
    /// </summary>
    public class GiveOutMerchRequest : Entity
    {
        /// <summary>
        /// Статус заявки
        /// </summary>
        public RequestStatus Status { get; private set; }

        /// <summary>
        /// Сотрудник
        /// </summary>
        public Employee Employee { get; private set; }

        /// <summary>
        /// Дата создания заявки
        /// </summary>
        public DateTime CreatedDate { get; private set; }

        /// <summary>
        /// Дата выдачи мерча
        /// </summary>
        public DateTime? IssueDate { get; private set; }

        /// <summary>
        /// Набор товаров в мерче
        /// </summary>
        public MerchPack MerchPack { get; private set; }

        private GiveOutMerchRequest(
            int id,
            Employee employee,
            RequestStatus requestStatus,
            MerchPack merchPack,
            DateTime createdDate,
            DateTime? issueDate = null)
        {
            Id = id;
            Employee = employee;
            MerchPack = merchPack;
            CreatedDate = createdDate;
            IssueDate = issueDate;
            Status = requestStatus;
        }

        public static GiveOutMerchRequest Create(
            int id,
            Employee employee,
            RequestStatus requestStatus,
            MerchPack merchPack,
            DateTime createdDate,
            DateTime? issueDate = null)
        {
            if (string.IsNullOrEmpty(employee.Email.Value))
            {
                throw new GiveOutMerchException("Email is invalid!");
            }

            return new GiveOutMerchRequest(id, employee, requestStatus, merchPack, createdDate, issueDate);
        }

        /// <summary>
        /// Выдаем мерч
        /// </summary>
        /// <param name="isAvailable">Доступен ли мерч на складе</param>
        /// <param name="issueDate">Дата выдачи мерча</param>
        /// <exception cref="GiveOutMerchException">Выбрасывается при неудачной попытке выдать мерч</exception>
        public void GiveOutMerch(bool isAvailable, DateTime issueDate)
        {
            if (!Equals(Status, RequestStatus.Created) && !Equals(Status, RequestStatus.InWork))
            {
                throw new GiveOutMerchException("Can't GiveOutMerch. Status is invalid");
            }

            if (isAvailable)
            {
                Status = RequestStatus.Done;
                IssueDate = issueDate;

                AddDomainEvent(new MerchRequestGivenOutDomainEvent(Employee, MerchPack));
            }
            else
            {
                Status = RequestStatus.InWork;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="GiveOutMerchException"></exception>
        public void DeclineMerch()
        {
            if (Equals(Status, RequestStatus.Decline) || Equals(Status, RequestStatus.Done))
            {
                throw new DeclineMerchException("Can't GiveOutMerch. Status is invalid");
            }

            Status = RequestStatus.Decline;
        }
    }
}