using Modul11.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modul11.Services
{
    public interface IStorage
    {
        /// <summary>
        /// Получение сессии пользователя по идентификатору
        /// </summary>
        Session GetSession(long chatId);
    }
}
