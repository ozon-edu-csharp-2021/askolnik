using System;

using MerchApi.Domain.Exceptions;
using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.MerchAggregate
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
        public int EmployeeId { get; private set; }

        /// <summary>
        /// Тип выданного мерча
        /// </summary>
        public MerchType MerchType { get; private set; }

        /// <summary>
        /// Дата выдачи мерча
        /// </summary>
        public DateTime? IssueDate { get; private set; }

        /// <summary>
        /// Набор товаров в мерче
        /// </summary>
        public MerchPack MerchPack { get; private set; }

        protected GiveOutMerchRequest()
        {
            Status = RequestStatus.Draft;
        }

        public GiveOutMerchRequest(int employeeId, MerchType merchType) : this()
        {
            EmployeeId = employeeId > 0 ? employeeId : throw new Exception("EmploeeId must be more 0");
            MerchType = merchType ?? throw new Exception("MerchType must be not null");
        }

        /// <summary>
        /// Создаем заявку для конкретного сотрудника
        /// </summary>
        public void Register()
        {
            if (Status != RequestStatus.Draft)
            {
                throw new Exception("Incorrect request status");
            }

            Status = RequestStatus.Created;
        }

        /// <summary>
        /// Смена статуса у заявки
        /// </summary>
        /// <param name="status">Статус запроса</param>
        /// <exception cref="RequestStatusException">Исключение при неверном запросе</exception>
        public void ChangeStatus(RequestStatus status)
        {
            if (Status.Equals(RequestStatus.Done))
                throw new RequestStatusException($"Request is done. Change status unavailable");

            Status = status;
        }

        /// <summary>
        /// Завершить работу по заявке
        /// </summary>
        public void Complete()
        {
            if (Status != RequestStatus.InWork)
            {
                throw new Exception("Incorrect request status");
            }

            Status = RequestStatus.Done;
        }
    }
}