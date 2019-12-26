namespace Bank.BLL.Service.Base
{
    /// <summary>
    /// Interface IGenerationIdAccount.
    /// </summary>
    /// <typeparam name="T"> Parameter type.</typeparam>
    public interface IGenerationIdAccount
    {
        /// <summary>
        /// Generation Id Account.
        /// </summary>
        /// <returns>Id Account.</returns>
        public string GenerationId();
    }
}
