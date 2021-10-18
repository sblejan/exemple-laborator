using Lucrarea2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Lucrarea2.Models.Cos;
using static Lucrarea2.Program;

namespace Lucrarea2
{
    public static class CosOperation
    {
        public static ICos ValidatedCos(Func<ProdusID, bool> checkProdusExists, UnvalidatedCos produse, CosDetails cosDetails)
        {
            List<ValidatedProduse> validatedCos = new();
            bool isValidList = true;
            string invalidReson = string.Empty;
            foreach (var unvalidatedProduse in produse.ProduseList)
            {

                List<ProdusDatasheet> listaProduse = new();
                listaProduse.Add(new(1112, 50, 1500));
                listaProduse.Add(new(1113, 50, 2500));
                listaProduse.Add(new(1114, 50, 3500));
                listaProduse.Add(new(1115, 50, 4500));
                listaProduse.Add(new(1116, 50, 5500));
                listaProduse.Add(new(1117, 50, 6500));
                listaProduse.Add(new(1118, 50, 7500));

                if (!ProdusID.TryParseProdusID(unvalidatedProduse.ProdusID, out ProdusID produsID))
                {
                    invalidReson = $"Invalid ProductsID  ({unvalidatedProduse.ProdusID}, {unvalidatedProduse.ProdusCantitate})";
                    isValidList = false;
                    break;
                }
                else
                {
                    foreach (var produs in listaProduse)
                    {
                        if (produs.getid() == Int32.Parse(produsID.ToString()))
                        {
                            isValidList = true;
                            break;
                        }
                    }
                }

                if (!ProdusCantitate.TryParseProdusCantitate(unvalidatedProduse.ProdusCantitate, out ProdusCantitate produsCantitate))
                {
                    invalidReson = $"Invalid ProdusCantitate  ({unvalidatedProduse.ProdusID}, {unvalidatedProduse.ProdusCantitate})";
                    isValidList = false;
                    break;
                }
                else
                {
                    foreach (var produs in listaProduse)
                    {
                        if (produs.getid() == Int32.Parse(produsID.ToString()))
                        {
                            int cantitate = produs.getstoc();
                            if (cantitate > Int32.Parse(produsCantitate.ToString()))
                            {
                                produs.setstoc(cantitate - Int32.Parse(produsCantitate.ToString()));
                            }
                        }
                    }
                }

                if (!PaymentAddress.TryParsePaymentAddress(produse.CosDetails.PaymentAddress.ToString(), out PaymentAddress adresa))
                {
                    invalidReson = $"Invalid Address  ({produse.CosDetails.PaymentAddress.ToString()})";
                    isValidList = false;
                    break;
                }

                ValidatedProduse validatedProduse = new(produsID, produsCantitate);
                validatedCos.Add(validatedProduse);

            }

            if (isValidList)
            {
                return new ValidatedCos(validatedCos, cosDetails);
            }
            else
            {
                return new InvalidatedCos(produse.ProduseList, invalidReson);
            }

        }


        public static ICos PublishCos(ICos Cos) => Cos.Match(
            whenUnvalidatedCos: unvalidaTedCos => unvalidaTedCos,
            whenInvalidatedCos: invalidCos => invalidCos,
            whenValidatedCos: validatedCos => validatedCos,
            whenCosPlatit: cosPlatit => cosPlatit
            // {
            //  StringBuilder csv = new();

            // cosPlatit.ProduseList.Aggregate(csv, (export, produsList) => export.AppendLine($"{produsList.ProdusID.Value}, {produsList.ProdusCantitate.Value}, {cosPlatit.CosDetails.PaymentAddress}"));

            // PublishedCos publishedCos = new(cosPlatit, csv.ToString(), DateTime.Now);

            // return publishedCos;
            );
    }
}
