using System;
using System.Collections.Generic;
using SaafiMobile.Core.Model;
namespace SaafiMobile.Core.Contracts.Repository
{
    public interface ISettingsRepository
    {
        List<Currency> GetAvailableCurrencies();
        Currency GetCurrencyById(int currencyId);

        string GetAboutContent();
    }
}
