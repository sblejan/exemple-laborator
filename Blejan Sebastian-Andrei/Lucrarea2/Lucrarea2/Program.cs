using Lucrarea2.Models;
using static Lucrarea2.Domanin.Models.PublishCosCommand;
using System;
using System.Collections.Generic;
using static Lucrarea2.Models.CosPublishedEvent;
using static Lucrarea2.CosOperation;
using Lucrarea2.Domanin.Models;

namespace Lucrarea2
{
    class Program
    {

        static void Main(string[] args)
        {

            string answer = ReadValue("Incepeti Cumparaturile?[Y/N]");
            if (answer.Contains("Y"))
            {
                var listOfCoss = ReadProduse().ToArray();
                PublishCosCommand command = new(listOfCoss);
                PublishCosWorkflow workflow = new PublishCosWorkflow();
                var result = workflow.Execute(command, (registrationNumber) => true);

                result.Match(
                        whenExamCossPublishFaildEvent: @event =>
                        {
                            Console.WriteLine($"Publish failed: {@event.Reason}");
                            return @event;
                        },
                        whenExamCossPublishScucceededEvent: @event =>
                        {
                            Console.WriteLine($"Publish succeeded.");
                            Console.WriteLine(@event.Csv);
                            return @event;
                        }
                    );

                Console.WriteLine("Hello World!");

            }
            else Console.WriteLine("BYE!");

        }

        private static List<UnvalidatedProduse> ReadProduse()
        {
            List<UnvalidatedProduse> listOfProduse = new();
            object answer = null;
            do
            {
                answer = ReadValue("adaugati produs?[Y/N]: ");

                if (answer.Equals("Y"))
                {
                    var ProdusID = ReadValue("ProdusID: ");
                    if (string.IsNullOrEmpty(ProdusID))
                    {
                        break;
                    }

                    var ProdusCantitate = ReadValue("ProdusCantitate: ");
                    if (string.IsNullOrEmpty(ProdusCantitate))
                    {
                        break;
                    }
                    UnvalidatedProduse toAdd = new(ProdusID, ProdusCantitate);
                    listOfProduse.Add(toAdd);
                }

            } while (!answer.Equals("N"));

            return listOfProduse;
        }

        public static CosDetails ReadDetails()
        {
            PaymentState paymentState;
            PaymentAddress paymentAddress;
            CosDetails cosDetails;

            string answer = ReadValue("Finalizezi Comanda?[Y/N]");

            if (answer.Contains("Y"))
            {

                var Address = ReadValue("Adresa: ");
                if (string.IsNullOrEmpty(Address))
                {
                    paymentAddress = new PaymentAddress("");
                }
                else
                {
                    paymentAddress = new PaymentAddress(Address);
                }
                var payment = ReadValue("Platesti?[Y/N] ");
                if (payment.Contains("Y"))
                {
                    paymentState = new PaymentState(1);
                }
                else
                {
                    paymentState = new PaymentState(0);
                }
            }
            else
            {
                paymentAddress = new PaymentAddress("");
                paymentState = new PaymentState(0);
            }
            cosDetails = new CosDetails(paymentAddress, paymentState);
            return cosDetails;
        }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

    }
}
