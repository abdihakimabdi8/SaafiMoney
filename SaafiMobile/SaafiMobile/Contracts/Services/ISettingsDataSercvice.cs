using SaafiMobile.Core.Model;
using System;
using System.Collections.Generic;

namespace SaafiMobile.Core.Contracts.Services
{
    public interface ISettingsDataService
    {
        List<Currency> GetCurrencies();
        Currency GetActiveCurrency();
        void SetActiveCurrency(Currency currency);
        string GetAboutContent();
    }
}
