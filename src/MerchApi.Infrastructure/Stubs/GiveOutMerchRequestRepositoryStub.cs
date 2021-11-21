using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MerchApi.Domain.AggregationModels.MerchPackAggregate;
using MerchApi.Domain.AggregationModels.MerchRequestAggregate;

namespace MerchApi.Infrastructure.Stubs
{
    public class GiveOutMerchRequestRepositoryStub : IGiveOutMerchRequestRepository
    {
        public Task<GiveOutMerchRequest> CreateAsync(GiveOutMerchRequest itemToCreate, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(itemToCreate);
        }

        public Task<IReadOnlyList<GiveOutMerchRequest>> FindByEmployeeEmailAsync(string employeeEmail, CancellationToken cancellationToken = default)
        {
            var response = new List<GiveOutMerchRequest>();

            switch (employeeEmail)
            {
                case "test@test.ru":
                    var type1 = MerchType.WelcomePack;
                    response.Add(GiveOutMerchRequest.Create(1, Employee.Create(Email.Create(employeeEmail)), RequestStatus.Created, new MerchPack(type1, GetSkus(type1)), DateTime.UtcNow));
                    break;

                case "test2@test.ru":
                    var type2 = MerchType.VeteranPack;
                    response.Add(GiveOutMerchRequest.Create(2, Employee.Create(Email.Create(employeeEmail)), RequestStatus.Created, new MerchPack(type2, GetSkus(type2)), DateTime.UtcNow));
                    break;
            }

            return Task.FromResult<IReadOnlyList<GiveOutMerchRequest>>(response);
        }

        public Task<GiveOutMerchRequest> UpdateAsync(GiveOutMerchRequest itemToUpdate, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(itemToUpdate);
        }

        private static List<Sku> GetSkus(MerchType merchType)
        {
            var skus = new List<Sku>();

            if (merchType == MerchType.WelcomePack)
            {
                skus.AddRange(new List<Sku>() { Sku.Create(1), Sku.Create(2) });
            }

            if (merchType == MerchType.ProbationPeriodEndingPack)
            {
                skus.AddRange(new List<Sku>() { Sku.Create(3) });
            }

            if (merchType == MerchType.ConferenceListenerPack)
            {
                skus.AddRange(new List<Sku>() { Sku.Create(4), Sku.Create(5) });
            }

            if (merchType == MerchType.ConferenceSpeakerPack)
            {
                skus.AddRange(new List<Sku>() { Sku.Create(6), Sku.Create(7), Sku.Create(8) });
            }

            if (merchType == MerchType.VeteranPack)
            {
                skus.AddRange(new List<Sku>() { Sku.Create(9), Sku.Create(10) });
            }

            return skus;
        }
    }
}