using System;

using MerchApi.Domain.Exceptions;
using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.MerchAggregate
{
    /// <summary>
    /// Запрос на выдачу мерча
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

        public GiveOutMerchRequest() : base()
        {
            Id = 0;
            Status = RequestStatus.Draft;
        }

        public GiveOutMerchRequest(int employeeId, MerchType merchType) : this()
        {
            EmployeeId = employeeId;
            Status = RequestStatus.Created;
            MerchType = merchType;
        }

        /// <summary>
        /// Создаем заявку для конкретного сотрудника
        /// </summary>
        public void Create(int employeeId, MerchType merchType)
        {
            if (Status != RequestStatus.Draft)
            {
                throw new Exception("Incorrect request status");
            }

            EmployeeId = employeeId;
            MerchType = merchType;
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
                throw new RequestStatusException($"Request in done. Change status unavailable");

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