using Practical_24.Application.DTOs.Payments;
using Practical_24.Application.Interfaces;
using Practical_24.Domain.Entities;
using Practical_24.Domain.Factories;
using Practical_24.Domain.Interfaces;
using Practical_24.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Practical_24.Domain.Exceptions;

namespace Practical_24.Application.Services
{
    public class PaymentService(IUnitOfWork uow, PaymentMethodFactoryProvider provider, IMapper mapper) : IPaymentService
    {
        public async Task<Payment> ProcessPaymentAsync(Payment payment, int fail, CancellationToken token = default)
        {
            var paymentMethod = provider.Create(payment.PaymentType);

            var currentAttempt = 0;

            while(payment.Status != PaymentStatus.Succeeded && payment.Status != PaymentStatus.Failed)
            {
                payment.StartProcessing();

                currentAttempt++;

                var shouldSucceed = currentAttempt > fail;

                if(shouldSucceed)
                {
                    payment.MarkSucceeded();
                    await uow.SaveChangesAsync(token);
                    return mapper.Map<Payment>(payment);
                }

                try
                {
                    payment.RegisterFailedAttempt();
                    await uow.SaveChangesAsync(token);

                }
                catch(PaymentFailedException)
                {
                    await uow.SaveChangesAsync(token);
                }

                var delay = payment.GetNextRetryDelay();

                if(delay > TimeSpan.Zero){
                    await Task.Delay(delay, token);
                }
            }

            return payment;
        }
    }
}
