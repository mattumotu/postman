namespace Postman.Interfaces
{
    /// <summary>
    /// An <see cref="IPostman"/> sends <see cref="IEnvelope"/>
    /// </summary>
    public interface IPostman
    {
        /// <summary>
        /// Send the specified <see cref="IEnvelope"/>
        /// </summary>
        /// <param name="env">the <see cref="IEnvelope"/> to be sent</param>
        void Send(IEnvelope env);
    }
}