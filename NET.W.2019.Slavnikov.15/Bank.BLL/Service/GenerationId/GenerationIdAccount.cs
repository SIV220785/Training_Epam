using System;
using Bank.BLL.Service.Base;

namespace Bank.BLL.Service.GenerationId
{
    public class GenerationIdAccount : IGenerationIdAccount
    {
        public string GenerationId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
